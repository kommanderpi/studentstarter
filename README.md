# DigiPhant student starter

Use your coding agent to integrate real-world movement tracking and a rigged
elephant into your own Unity project. The repository provides assets, tracking
software and a reference Unity implementation. Your agent should inspect your
project and computer, then integrate, build and adapt the components to your setup.
Work in groups of three; assignment deliverables are provided separately.

## 1. Create or choose your Unity project

Create a project in Unity Hub or use your existing project. Universal 3D / URP is
the easiest starting point because the supplied materials use URP. Open a new
project once so Unity creates its directories. For an existing project, let your
agent inspect its version, rendering and existing work before changing settings.

You do not need to reproduce the instructor's machine. The reference environment
was Unity 6000.6.0f1 with Python 3.14 on an Apple Silicon Mac. Your agent should
check compatibility and select the appropriate local setup. Windows and other
configurations still need validation on the actual computer.

## 2. Clone the repository, or ask your agent to clone it

Clone beside `Assets`, not inside it. In Terminal or PowerShell:

```text
cd "PATH_TO_YOUR_UNITY_PROJECT"
git clone https://github.com/kommanderpi/studentstarter.git DigiPhantStarter
```

Or give your agent this instruction:

> Locate my Unity project root, containing Assets, Packages and ProjectSettings.
> Clone https://github.com/kommanderpi/studentstarter.git into a directory named
> DigiPhantStarter beside Assets. If already cloned, inspect and reuse it without
> overwriting local work. Keep the clone outside Assets.

Expected layout:

```text
MyUnityProject/
  Assets/
  Packages/
  ProjectSettings/
  DigiPhantStarter/
    README.md
    AGENT_SETUP.md
    INTEGRATION.md
    Elephant/
    Elephant.meta
    DigiPhant/
    DigiPhant.meta
    Tracking/
```

This name/location matches the reference camera launcher. If you cloned elsewhere,
ask your agent to reconcile the location or adapt the launcher before running it.
Cloning downloads the components; it does not import them or install dependencies.

## 3. Ask your agent to inspect and integrate

Open your agent in the **Unity project root**, so it can inspect both the existing
project and cloned files. Give it this prompt:

> Inspect my Unity project, this computer's setup, and the cloned DigiPhantStarter
> repository. Read DigiPhantStarter/README.md, AGENT_SETUP.md and INTEGRATION.md,
> plus the relevant scripts and existing project instructions. Integrate the
> elephant and motion tracking into my project, adapting or building components
> as needed for my Unity version, render pipeline, OS, Python environment and
> camera. Reuse the supplied implementation where appropriate and preserve my
> existing work. Carry out setup and integration, verify what you can, then help
> me test live control. Explain the data path and record the actual setup, changes,
> test results and remaining checks in DIGIPHANT_SETUP.md at my project root.
> Also integrate recording following RECORDING.md and prepare my own lightweight
> project repository following STUDENT_GIT.md. Keep videos on Drive.

The agent's detailed instructions and Mac/Windows command examples are in
[AGENT_SETUP.md](AGENT_SETUP.md). Students do not have to perform a fixed sequence
of copy and installation commands manually. You may need to grant camera access,
open the editor, or perform movements for tests the agent cannot do alone.

By the end, you should know which scene to open, how to start tracking, how to
calibrate and reset it, what each person controls, and what has actually been
verified on your computer. Ask your agent to explain anything you cannot connect
to the physical performance or collected data.

## What the agent can reuse

| Component | Contents |
| --- | --- |
| `Elephant/` and `Elephant.meta` | Rigged elephant, animations, textures, materials, prefab, vendor scripts and demo scene |
| `DigiPhant/` and `DigiPhant.meta` | Reference scene, stage materials, receiver, camera preview, calibration, mapping, rig control, locomotion and editor tools |
| `Tracking/bridge.py` | Webcam capture, MediaPipe, performer assignment, movement signals, skeleton display and local UDP output |
| `Tracking/pose_landmarker_full.task` | Bundled pose model |
| `Tracking/encode_recording.py` | Exports timestamped Game view frames as an MP4 |
| `Tracking/requirements.txt` and tests | Pinned direct dependencies and Python checks |
| `INTEGRATION.md` | Message format, ports, signals, calibration and tracking behaviour |
| `asset-checksums.json` | Fingerprints of supplied Unity assets and pose model |

The reference scene is `DigiPhant/Scenes/DigiPhant.unity` in the clone, normally
imported as `Assets/DigiPhant/Scenes/DigiPhant.unity`. It is an example to run and
adapt, not a requirement to replace your existing scene. Unity project settings
and package manifests are deliberately left to your project. Unity, Git, Python
and installed dependency binaries are not bundled. Package installation needs
internet; camera processing and communication run locally.

## Try the reference controls after integration

Your agent should give instructions matching your final scene. For the unchanged
reference scene:

1. Press Play. Unity launches the local bridge and shows the camera preview.
2. Use Test sliders to explore the rig, or choose Camera for live control.
3. Select the performer count and Full body or Seated / upper body.
4. Click Set neutral pose (10 seconds), get into position and hold still.
5. Test one control at a time, then a collective action. Stop Play to stop the
   bridge Unity launched. An independently started bridge must be stopped separately.

The reference supports solo testing and three-person performance. Full-body mode
needs hips and feet visible for its default controls; seated mode uses shoulders
and hands. The [reference usage guide](DigiPhant/README.md) explains roles and
controls. Calibration, mappings and camera framing may change as you adapt them.

## Record your performance

After calibration, click **Record performance** to capture the Game view with the
camera preview and elephant together. Stop and save, check the resulting MP4, then
upload it to your team's Drive folder. See [RECORDING.md](RECORDING.md) for paths,
limitations and recovery. The recorder saves locally; Drive upload is separate.

## Git and student adaptations

Submit your own Unity project through a separate Git repository. Follow
[STUDENT_GIT.md](STUDENT_GIT.md) to include your scenes, adapted scripts, metadata,
package configuration and setup guide while excluding heavy supplied assets,
models, virtual environments, recordings and Unity caches. Recover shared assets
from the recorded starter commit. Put the checked video on Drive and link it from
your project README.

The starter clone is its own repository, normally ignored by the outer student
project repository. Preserve any modified Python source or reproducible patches
in your own version history. Pulling instructor updates does not update imported
assets automatically; reconcile changes with your adapted copies. Do not push
student adaptations to the instructor repository unless asked.
