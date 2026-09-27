# Tracking-to-Unity integration contract

The supplied Python bridge performs pose estimation and converts landmarks into
six signals. The included DigiPhant Unity scripts provide a reference receiver,
interface, calibration, mapping, rig control and locomotion. Students can adapt
these components or implement their own. The reference also includes Game view
recording and a Python MP4 exporter; see [RECORDING.md](RECORDING.md). Begin with [AGENT_SETUP.md](AGENT_SETUP.md)
to inspect and adapt to the actual project. Trial logging remains student work.
MediaPipe estimates pose; your design gives those movements meaning.

## Processes and ports

Everything runs on the same computer using IPv4 loopback (`127.0.0.1`). With the
default `--port 5055`:

| Port | Owner | Purpose |
| --- | --- | --- |
| 5055 | Unity receiver | Receive UTF-8 JSON tracking datagrams from Python; send configuration commands back from this same socket |
| 5056 | Python bridge | Send tracking and preview data; receive Unity commands |
| 5057 | Optional Unity preview receiver | Receive individual JPEG datagrams from Python |

Changing `--port` changes all three ports together: base, base+1 and base+2.
Unity must bind its command-sending socket to the base port: Python checks the
source address and port before accepting commands. Do not use an unrelated
ephemeral-port socket for commands. Run only one bridge per port set.

## Tracking packet: Python to Unity

Each JSON datagram contains a complete current snapshot, not a partial update:

```json
{
  "version": 1,
  "performerCount": 3,
  "upperBodyOnly": false,
  "people": [
    {
      "slot": 1,
      "values": [0.0, 0.0, -1.0, -1.0, 0.0, 0.5],
      "confidence": [0.9, 0.9, 0.8, 0.8, 0.9, 0.9]
    }
  ]
}
```

This example contains only P1; P2 and P3 are missing and must not retain fresh
confidence from an older packet. `people: []` means no assigned performers.
Slots range from 1 to 4. The six values are finite, body-relative measurements
clamped to [-3, 3]; they are not calibrated control values, angles or metres.
Confidence combines the minimum landmark visibility and presence for each input.

| Index | Signal | Full-body measurement | Upper-body measurement |
| --- | --- | --- | --- |
| 0 | LeftHandHeight | Shoulder midpoint Y minus left wrist Y, divided by torso length | Same difference divided by shoulder width |
| 1 | RightHandHeight | Shoulder midpoint Y minus right wrist Y, divided by torso length | Same difference divided by shoulder width |
| 2 | LeftFootLift | Hip midpoint Y minus left ankle Y, divided by torso length | Copy of left-hand height |
| 3 | RightFootLift | Hip midpoint Y minus right ankle Y, divided by torso length | Copy of right-hand height |
| 4 | Lean | Shoulder midpoint X minus hip midpoint X, divided by torso length | Left shoulder Y minus right shoulder Y, divided by shoulder width |
| 5 | ArmSpread | Absolute wrist X separation divided by twice torso length | Absolute wrist X separation divided by twice shoulder width |

Image Y increases downward. Height increases when a wrist or ankle rises relative
to its reference. Body-part left/right means the person's own left/right. These
are normalized image-coordinate measurements; aspect ratio and camera viewpoint
affect their interpretation. They are not shared-world 3D coordinates.

The bridge does not send raw landmarks or timestamps in this protocol. Add a
monotonic reception timestamp to Unity logs. If your research question requires
capture timestamps or raw landmarks, extend and document the protocol with your
agent rather than claiming those fields already exist.

## Unity to Python commands

Send UTF-8 JSON from `127.0.0.1:5055` to `127.0.0.1:5056`:

```json
{"version":1,"performerCount":3,"upperBodyOnly":true}
```

Resend the desired settings periodically, for example every half second, because
UDP delivery is not guaranteed. Compare returned `performerCount` and
`upperBodyOnly` with the desired settings before accepting data for calibration.
Changing either mode or count resets Python's position-based identity assignment;
Unity must clear its baseline and stop movement until recalibrated.

To reset identity assignment explicitly:

```json
{"version":1,"performerCount":3,"upperBodyOnly":true,"reset":true}
```

Send reset once per user action, not in the periodic configuration message.
Pressing R in the Python preview also resets identities; clear Unity calibration
after doing so. Assignment requires enough visible detections and initially
sorts them left-to-right. Tracking thereafter uses hip centers in full-body mode
or shoulder centers in upper-body mode. It does not recognize clothing or faces.

The bridge's final shutdown notification is a minimal version-1 packet with an
empty `people` array. Treat an empty snapshot or tracking timeout as loss of input,
including if mode metadata is absent on shutdown.

## Camera preview

Python draws skeletons and labels onto the camera frame before encoding it.
Assigned performers have coloured skeletons; unassigned detections appear grey.
The image is unmirrored. Confidence filtering can leave incomplete skeletons.

Preview datagrams are complete JPEG images of at most 8,000 bytes, sent at most
ten times per second to the preview port. Dimensions are at most 320×240 and may
be reduced to fit the byte limit. Decode the newest received JPEG on Unity's main
thread and preserve its aspect ratio. Discard stale preview frames. The preview
is optional; the Python window is sufficient for initial integration.

## Suggested integration and verification sequence

1. Receive JSON and display performer count, slots, six values and confidence.
2. Reject malformed packets, unknown versions, invalid slots, non-finite values,
   incorrect array lengths and settings that do not match your chosen mode.
3. Timestamp arrivals and clear confidence for missing people. Stop or fade
   controls when tracking is older than a chosen timeout; 0.5 seconds is a useful
   starting point to test. Keep all Unity object access on the main thread.
4. Provide a visible ten-second neutral countdown with cancellation. At its end,
   require fresh, sufficiently confident inputs for every active mapping, then
   save their values. Explain failed calibration instead of using missing data.
5. Compute `current value - neutral value`, apply sensitivity and inversion,
   clamp to a chosen control range, and smooth before driving the rig.
6. Inspect the rig's rest pose and local bone axes. Drive one joint first, with
   limits, and verify that neutral restores its baseline. Avoid accumulated
   rotations and conflicts with Animator or the vendor controller.
7. Add three-person mappings, tracking recovery, diagnostics and data logging.
   Test actual people crossing, disappearing, and changing formation.

Record your choices for confidence thresholds, smoothing and limits and explain
how you tested them. A moving skeleton alone does not demonstrate a reliable
digital twin.

## Possible starting roles

| Role | Input | Elephant response |
| --- | --- | --- |
| P1 | Left/right foot lifts; hand raises in seated mode | Front legs |
| P2 | Left/right foot lifts; hand raises in seated mode | Rear legs |
| P2 | Lean; shoulder tilt in seated mode | Tail sway |
| P3 | Lean; shoulder tilt in seated mode | Head turn |
| P3 | Right hand height | Trunk curl |
| P3 | Hand separation | Ears |

These roles match the supplied three-person reference mapping. The reference
also maps P1 left-hand height to travel and P1 lean to steering. Decide whether
to keep or change travel, how conflicting inputs combine, and how each student
contributes.

## References and provenance

- MediaPipe Pose Landmarker Python guide:
  https://ai.google.dev/edge/mediapipe/solutions/vision/pose_landmarker/python
- Included model source:
  https://storage.googleapis.com/mediapipe-models/pose_landmarker/pose_landmarker_full/float16/latest/pose_landmarker_full.task
- Original elephant documentation: `Elephant/Elephant_readme.txt`.
- `asset-checksums.json` records SHA-256 hashes of the distributed model and
  elephant and DigiPhant files, including import metadata. The source model URL uses `latest`;
  the checksum identifies the actual bundled version.

The elephant remains a third-party asset with its existing terms. This starter
does not grant a new license to it or relicense third-party software or models.
