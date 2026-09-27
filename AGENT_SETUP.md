# Agent setup and integration guide

Read the student's request, the Unity project's existing instructions, this guide,
[README.md](README.md), [INTEGRATION.md](INTEGRATION.md),
[RECORDING.md](RECORDING.md), [STUDENT_GIT.md](STUDENT_GIT.md) and the relevant source
before changing the project. Integrate, build and verify the starter for the
student's actual setup. Explain routine compatible adaptations and carry them
out as part of the task, rather than seeking approval for every command.

## Inspect first

- Locate the Unity project root and clone. Inspect scenes, scripts, assets,
  existing instructions, local changes and any previous integration. Do not
  assume a blank project or overwrite student work.
- Read `ProjectSettings/ProjectVersion.txt`, `Packages/manifest.json` and relevant
  rendering/input settings. Identify the installed editor and render pipeline.
- Identify OS, CPU architecture, available Python interpreters and environments.
  Check package compatibility before selecting the interpreter.
- Check camera availability, OS permissions, camera index, bridge processes and
  UDP ports. Determine whether the editor is open or in Play mode.
- Inspect supplied runtime scripts and scene references. Choose to reuse the
  reference scene, integrate components into an existing scene, or build a new
  integration according to the student's request. Briefly explain the approach
  and proceed with the compatible setup work.

## Adapt to the project

The source setup used Unity 6000.6.0f1, URP, Python 3.14, MediaPipe 0.10.35 and
OpenCV 4.14.0.94 on Apple Silicon. These identify the source environment; they do
not establish compatibility on every machine. Prefer the existing Unity version
when compatible. Diagnose errors before changing editor versions.

URP is the easiest match for a new project. For an existing Built-in/HDRP project,
adapt materials and relevant code to its pipeline, or explain a necessary
migration; do not silently replace global rendering settings. Prefer the supplied
Python pins. Resolve actual incompatibilities with a suitable interpreter or a
documented and tested dependency change. Use package metadata or official
reference documentation when compatibility is uncertain.

Check these implementation assumptions:

- Both the camera launcher and performance recorder resolve `../DigiPhantStarter/Tracking` relative to
  `Application.dataPath`. It expects `.venv/bin/python` on macOS/Linux or
  `.venv/Scripts/python.exe` on Windows. Adapt the imported launcher if the actual
  layout differs, recording the relative path; keep tracking outside Assets.
- Editor setup tools use `Assets/Elephant` and `Assets/DigiPhant`. If relocating
  assets, update those tools too and preserve metadata/reference integrity.
- Inspect scene creation and validation tools before running them. They can open
  or replace scenes and write assets. Use saved copies or a disposable project
  for checks that would disturb the student's work.
- The vendor controller and Animator can conflict with custom joint rotation.
  The reference scene disables vendor control and manages locomotion animation.
  Preserve or explicitly replace this ownership when integrating elsewhere.
- Automatic bridge launch works in the Editor. Built players need a separately
  launched bridge. Avoid competing processes and clean up processes you start.

Keep original vendor assets and a recoverable reference scene. Use
`Assets/StudentWork` for new scenes/scripts; adapt imported scripts where needed
without introducing duplicate class names. Clone files and imported copies do not
synchronize automatically. Do not regenerate metadata for existing assets.

## Verify and hand over

Check Python imports/dependencies and supplied tests, Unity compilation, scene
references and materials, then camera/preview, assignment, neutral calibration
and one elephant response. Check tracking loss and recovery. Start solo if
necessary, then test the group's three-person mapping when people are available.
Integrate the recording component and Python encoder as well: test a short take
while driving the rig, then verify MP4 export, playback and visible camera/elephant
content. This requires a real Game view; do not claim it passed from encoder tests.
Help the student locate the MP4 for Drive upload; do not claim an automatic upload.
Prepare their own lightweight Git project using STUDENT_GIT.md and document how
to restore omitted heavy assets. Record a fresh-checkout reconstruction check.

Report static checks, automated tests and live observations separately. If camera,
GUI or performers are unavailable, finish independent work and list exact checks
still needed. Request OS permissions through the relevant platform. Do not start
a second Unity instance on the same project or claim unperformed checks passed.

Create or update `DIGIPHANT_SETUP.md` in the student's project root recording:

- Actual OS, editor, render pipeline, Python and dependency versions.
- Starter URL/commit, clone and imported asset paths, and environment location.
- Scene to open, launch method, camera index, group size and chosen mappings.
- Calibration, stop/restart and tracking recovery instructions.
- Changed files/settings and reasons, verification results and limitations.

Keep this report local to the student project. Do not push student changes to the
instructor's repository unless explicitly asked. Assignment deliverables are
provided separately; do not invent assessment requirements.

## Reference commands after inspection

These commands illustrate a fresh import using the conventional folder layout.
Use only the steps needed for the inspected project and selected integration.
Adapt paths and interpreter commands to your findings; do not repeat an import
or create a duplicate environment merely to follow the examples.

1. Locate the Unity project root: it must contain `Assets`, `Packages` and
   `ProjectSettings`, with `DigiPhantStarter` beside them. Run the commands below
   from that root. Confirm the operating system, Python version and interpreter
   path before choosing commands. Python 3.14 is the source setup version, not
   a universal requirement. Select an interpreter compatible with the dependencies
   on this OS and architecture; verify and record the choice. Adapt the example
   commands to that interpreter.
2. Stop Play mode and preserve unsaved work before changing assets. Use the
   existing editor for refresh and compilation when possible; closing it is
   optional unless the operation requires it. Check both `Assets/Elephant`
   and `Assets/Elephant.meta`, plus `Assets/DigiPhant` and `Assets/DigiPhant.meta`.
   If any exists, inspect it and preserve existing
   work: reuse an identical complete import; report differences or an incomplete
   import and reconcile differences without overwriting student changes. Avoid
   duplicate script classes and asset GUIDs. Run the copy commands only when neither
   destination for that asset folder or its metadata exists.
3. Copy the entire source `Elephant` directory, including all nested `.meta`
   files, and its sibling `Elephant.meta`. Also copy the entire `DigiPhant`
   directory and its sibling `DigiPhant.meta`. Do not move sources or regenerate
   metadata. Keep `Tracking` outside `Assets`.

macOS, for a fresh asset import:

```sh
cp -R DigiPhantStarter/Elephant Assets/Elephant
cp DigiPhantStarter/Elephant.meta Assets/Elephant.meta
cp -R DigiPhantStarter/DigiPhant Assets/DigiPhant
cp DigiPhantStarter/DigiPhant.meta Assets/DigiPhant.meta
```

Windows PowerShell, for a fresh asset import:

```powershell
Copy-Item -LiteralPath .\DigiPhantStarter\Elephant -Destination .\Assets\Elephant -Recurse
Copy-Item -LiteralPath .\DigiPhantStarter\Elephant.meta -Destination .\Assets\Elephant.meta
Copy-Item -LiteralPath .\DigiPhantStarter\DigiPhant -Destination .\Assets\DigiPhant -Recurse
Copy-Item -LiteralPath .\DigiPhantStarter\DigiPhant.meta -Destination .\Assets\DigiPhant.meta
```

4. For a fresh unchanged import, verify matching source and destination files.
   For existing or adapted files, record intentional differences; checksums are
   provenance checks, not a reason to revert student work.
   The `Elephant/`, `DigiPhant/` and their root `.meta` entries in `asset-checksums.json` provide
   SHA-256 hashes; destination paths are those entries prefixed with `Assets/`.
   Confirm `Assets/Elephant/Prefabs/Elephant.prefab` and its metadata are present.
5. Create `DigiPhantStarter/Tracking/.venv` using the selected Python interpreter.
   If it already exists, check its interpreter and reuse it if suitable; do not
   overwrite or delete an existing environment without resolving any mismatch.
   Run the environment-creation command below only when `.venv` does not exist.
   Install dependencies using that environment's Python, then verify imports
   and dependency consistency. Stop on an error and diagnose it before continuing.

macOS:

```sh
python3.14 -m venv DigiPhantStarter/Tracking/.venv
DigiPhantStarter/Tracking/.venv/bin/python -m pip install -r DigiPhantStarter/Tracking/requirements.txt
DigiPhantStarter/Tracking/.venv/bin/python -m pip check
DigiPhantStarter/Tracking/.venv/bin/python -c "import sys, cv2, mediapipe; print(sys.executable); print('MediaPipe', mediapipe.__version__, 'OpenCV', cv2.__version__)"
```

Windows PowerShell:

```powershell
py -3.14 -m venv .\DigiPhantStarter\Tracking\.venv
& .\DigiPhantStarter\Tracking\.venv\Scripts\python.exe -m pip install -r .\DigiPhantStarter\Tracking\requirements.txt
& .\DigiPhantStarter\Tracking\.venv\Scripts\python.exe -m pip check
& .\DigiPhantStarter\Tracking\.venv\Scripts\python.exe -c "import sys, cv2, mediapipe; print(sys.executable); print('MediaPipe', mediapipe.__version__, 'OpenCV', cv2.__version__)"
```

6. Verify that `Tracking/pose_landmarker_full.task` matches its entry in
   `asset-checksums.json`. It is already supplied; no model download is needed.
   Run the Python checks below, then help the student perform the live
   camera test below. Report installation checks separately from camera
   and Unity checks; an import succeeding does not prove the webcam works.

Do not copy another person's `.venv`, install dependencies globally, or install
MediaPipe into Unity's Package Manager. These commands invoke the environment
directly, so shell activation is unnecessary. Keep the dependency pins unless
a diagnosed compatibility issue requires a documented change.

Open or refresh Unity and wait for import and script compilation to finish. For the
reference integration, open `Assets/DigiPhant/Scenes/DigiPhant.unity`. Duplicate
it before experimenting. Alternatively, create your own scene and drag
`Assets/Elephant/Prefabs/Elephant.prefab` into it, then add your own integration.
Preserve both folders' `.meta` files when sharing your project.

The vendor `Elephant` component uses keyboard input and controls animation.
The supplied DigiPhant scene already disables the vendor controller on its instance.
Disable it on your scene instance when implementing your own movement control.
Decide explicitly whether your rig driver or Animator owns each bone; they can
otherwise overwrite each other. Keep your new scripts and scenes in a separate
folder such as `Assets/StudentWork`.

## Camera test

macOS:

```sh
DigiPhantStarter/Tracking/.venv/bin/python DigiPhantStarter/Tracking/bridge.py --people 1 --upper-body-only
```

Windows PowerShell:

```powershell
& .\DigiPhantStarter\Tracking\.venv\Scripts\python.exe .\DigiPhantStarter\Tracking\bridge.py --people 1 --upper-body-only
```

Allow camera access if prompted. A separate preview window should show your
skeleton and P1 label. Keep your shoulders and hands visible in upper-body mode.
Click the preview window and press **Q** to quit or **R** to reset identities.

For the group, use `--people 3`. Remove `--upper-body-only` for full-body tracking
with visible hips and feet. Use `--camera 1` if the default camera is wrong.
Assigned performers start left-to-right in the unmirrored image. A grey skeleton
means detected but unassigned; initial assignment waits for the chosen group size.

The camera test works without a Unity receiver. The supplied DigiPhant scene
provides a reference receiver and elephant controls. Keep the Python preview
visible for the independent camera test; Unity uses `--no-window` automatically
when it launches its own bridge and displays the preview.

## Reference scene, recording and adaptation

Quit a separately launched bridge with Q before trying Unity's automatic launch.
Open `Assets/DigiPhant/Scenes/DigiPhant.unity` and press Play. The example starts
Python from `DigiPhantStarter/Tracking/.venv` and displays its camera preview.
Choose the group size, Full body or Seated / upper body, then Camera. Click
**Set neutral pose (10 seconds)**, get into position, and hold still. Test one
control at a time. Use Record performance / Stop recording and save to capture
the combined Game view; follow RECORDING.md to verify export and upload to Drive.
Test sliders also let you explore the rig without live tracking.

The automatic launcher expects the clone to be named `DigiPhantStarter` beside
`Assets`. If the layout differs, adapt the launcher path and commands together. Keep
tracking outside Assets and avoid machine-specific absolute paths. Auto-launch is Editor-only; built
players require a separately started bridge. Camera permissions still apply.

Read the usage guide at `Assets/DigiPhant/README.md` and
[INTEGRATION.md](INTEGRATION.md), then give your agent this task:

> Inspect the supplied DigiPhant Unity integration and explain how tracking data
> reaches the elephant. Help me run the reference scene, verify one control and
> duplicate it for our group. Then help us adapt our performer assignments and
> mappings. Make one testable change at a time, preserve the original example,
> and place our new scenes and scripts under Assets/StudentWork.

Alternatively, ask your agent to create your own receiver and scene from the
protocol, using the supplied implementation as a reference. Your group still
needs to understand its measurements, collect trial data, design a collective
performance and substantiate its revisions.

## Python checks

From the Unity project root on macOS:

```sh
DigiPhantStarter/Tracking/.venv/bin/python -m unittest discover -s DigiPhantStarter/Tracking -p 'test_*.py'
```

On Windows PowerShell:

```powershell
& .\DigiPhantStarter\Tracking\.venv\Scripts\python.exe -m unittest discover -s .\DigiPhantStarter\Tracking -p 'test_*.py'
```

These test feature extraction, performer matching, and local preview transport.
They do not verify your Unity connection or real camera performance.
