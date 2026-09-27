# Record the collective performance

The reference scene can record the Unity Game view while the team drives the rig.
The video shows the live camera/skeleton preview on the left and the elephant on
the right, including the visible controls. This is a single combined recording;
you do not need to synchronize two separate videos. No microphone audio is recorded.

## Record and save

1. Use the updated Unity scripts and `Tracking/encode_recording.py`. Ask your agent
   to reconcile these with any adapted copies in your project; pulling the starter
   does not automatically update files already copied into Assets.
2. Run the scene, choose Camera and the group size, and calibrate. Make sure the
   camera preview shows all performers and that individual movements drive the rig.
3. Keep the Game view visible, preferably at 1280×720 or larger. Confirm the camera
   panel and elephant are both visible. Click **Record performance** above the
   controls, then perform. The recording does not interrupt control of the rig.
4. Click **Stop recording and save**. Wait for the Saved message. The encoder runs
   separately, so Unity remains available while it creates the video.
5. Find `Recordings/<date-time-id>/performance.mp4` in your Unity project root.
   Open it and check the beginning, end and an action involving each performer.
   Stopping Play also finishes capture and launches export, which may finish after
   the editor has left Play mode. Prefer the explicit Stop button so you can see
   whether export succeeded.

Capture targets 10 frames per second at up to 1280×720. It may be slower on some
computers. Frame timestamps preserve elapsed performance time: the exporter holds
the last captured image across gaps rather than speeding up playback. This is
screen evidence, not a high-speed movement measurement. The camera panel uses the
existing compressed preview and will have lower detail than the original webcam.
If performance suffers, shorten the take or reduce the Game view size.

Unity's end-of-frame capture requires a visible Game view. Avoid switching to Scene
view, pausing the editor, minimizing Unity or resizing the Game view during a take.
The current recorder is Editor-only. Ask your agent to adapt recording if your
project has a different UI, launcher path, or built-player workflow.

## Save the final video to Drive

Recordings are initially saved locally. Upload the checked MP4 to your team's
Google Drive folder, for example `TeamName_P2/Recordings/`. Use a descriptive name
such as `TeamName_P2_FinalPerformance.mp4`. The app does not log into Drive or
upload automatically. Your agent can help locate the file, but you control the
Drive account and sharing destination.

Check that the uploaded video plays and that your instructor can view it. Put the
Drive video link in your project's README or submission index. Keep recordings
out of Git. A Drive link to an inaccessible file is not a complete submission.

## Recovery and intermediate files

Each session retains JPEG frames, a timestamp log (`frames.jsonl`) and metadata
(`session.json`) beside the MP4. They allow export to be retried without repeating
the performance. They can be removed after verifying the final MP4 and its Drive
upload; do not submit the frame sequence unless requested.

If export fails, the interface keeps the session path. From the Unity project root:

macOS:

```sh
DigiPhantStarter/Tracking/.venv/bin/python DigiPhantStarter/Tracking/encode_recording.py --session "Recordings/SESSION_FOLDER"
```

Windows PowerShell:

```powershell
& .\DigiPhantStarter\Tracking\.venv\Scripts\python.exe .\DigiPhantStarter\Tracking\encode_recording.py --session "Recordings/SESSION_FOLDER"
```

Replace SESSION_FOLDER with the saved session name. Export uses OpenCV from the
existing tracking environment; no new Python dependency is required. It writes
MP4 with the `mp4v` codec. If the destination player cannot play it, ask your agent
to transcode a copy to H.264 MP4 and check that copy before uploading. Codec and
camera operation must be tested on the actual student machine.

An abrupt crash before session metadata is saved may need manual recovery from
the frame log; normal Stop recording or leaving Play mode writes that metadata.
