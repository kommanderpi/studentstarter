# DigiPhant student starter

Integrate real-world movement tracking with a rigged elephant in your own Unity
project. Work in groups of three; use your coding agent to build and test the
Unity integration. See [deliverables.md](deliverables.md) for the exercise.

## What is included

- `Elephant/` and `Elephant.meta`: the supplied elephant asset package, unchanged,
  including its rig, animations, prefab, textures, materials, vendor scripts and
  vendor demo scene.
- `Tracking/bridge.py`: webcam capture, MediaPipe pose detection, performer
  assignment, movement measurements, skeleton preview, and local UDP output.
- `Tracking/pose_landmarker_full.task`: the actual pose model, already included.
- `Tracking/requirements.txt` and tests: pinned direct Python dependencies.
- `DigiPhant/` and `DigiPhant.meta`: custom Unity runtime and editor scripts, the
  DigiPhant example scene, stage materials and usage guide.
- Explicit setup instructions below and the [integration contract](INTEGRATION.md).

This is a starter for a project you create yourself, including a reference
integration you can run, inspect and adapt. It includes the receiver, calibration
UI, rig control and locomotion, but no Unity project settings or package manifest.
You can also build your own integration using the same tracking contract.

Unity, Git, Python and Python dependency binaries are installed on each computer;
they are not bundled. Setup needs internet for package installation. The included
pose model avoids an initial model download. Camera processing runs locally.

## 1. Create your own Unity project

Install Git, Python and Unity Hub. Create a new **Universal 3D / URP** project in
Unity Hub; the supplied elephant materials use URP. Choose a folder you can find,
such as `Documents/MyElephantProject`. Open it once, then close the editor while
copying assets.

The source setup used Unity **6000.6.0f1**, Python **3.14**, MediaPipe **0.10.35**,
and OpenCV **4.14.0.94** on an Apple Silicon Mac. Python 3.14 is the reference
interpreter for the commands below. Windows instructions are provided but have
not been validated on a Windows machine. Have your agent diagnose installation
errors before changing dependency versions, and record any changes.

## 2. Clone this starter into the project root

The starter repository is https://github.com/kommanderpi/studentstarter.
Clone it into your Unity project using the commands below.

Open Terminal on macOS or PowerShell on Windows. Change into your new Unity
project folder, using your actual path:

```text
cd "PATH_TO_YOUR_UNITY_PROJECT"
git clone https://github.com/kommanderpi/studentstarter.git DigiPhantStarter
```

Clone beside `Assets`, **not inside `Assets`**. The Python environment and model
should stay outside Unity's asset importer. The result should be:

```text
MyElephantProject/
  Assets/
  Packages/
  ProjectSettings/
  DigiPhantStarter/
    README.md
    Elephant/
    Elephant.meta
    DigiPhant/
    DigiPhant.meta
    Tracking/
```

Keep the cloned directory named `DigiPhantStarter` to match the commands below.
If you already cloned it there, do not clone another copy.

## 3. Import the Unity assets and install tracking

Give your agent this task:

> Read DigiPhantStarter/README.md. Follow section 3 to inspect this computer,
> copy the Elephant and DigiPhant assets into my Unity project, create a local Python environment,
> install the specified dependencies and verify the installation. Preserve all
> asset metadata and existing work. Explain what you changed and report any
> checks you could not complete. Then help me run the camera test in section 4.

### Instructions for the agent

1. Locate the Unity project root: it must contain `Assets`, `Packages` and
   `ProjectSettings`, with `DigiPhantStarter` beside them. Run the commands below
   from that root. Confirm the operating system, Python version and interpreter
   path before choosing commands. Use Python 3.14 as the reference version; if it
   is unavailable, explain the installation needed rather than silently using a
   different interpreter.
2. Ensure Unity is closed before copying the asset. Check both `Assets/Elephant`
   and `Assets/Elephant.meta`, plus `Assets/DigiPhant` and `Assets/DigiPhant.meta`.
   If any exists, inspect it and preserve existing
   work: reuse an identical complete import; report differences or an incomplete
   import before replacing anything. Run the copy commands only when neither
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

4. Verify that all source files have matching destination paths and contents.
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
   Run the Python checks in section 6, then help the student perform the live
   camera test in section 4. Report installation checks separately from camera
   and Unity checks; an import succeeding does not prove the webcam works.

Do not copy another person's `.venv`, install dependencies globally, or install
MediaPipe into Unity's Package Manager. These commands invoke the environment
directly, so shell activation is unnecessary. Keep the dependency pins unless
a diagnosed compatibility issue requires a documented change.

Reopen Unity and wait for import and script compilation to finish. For the
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

## 4. Test the camera independently

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

## 5. Run and adapt the reference integration

Quit a separately launched bridge with Q before trying Unity's automatic launch.
Open `Assets/DigiPhant/Scenes/DigiPhant.unity` and press Play. The example starts
Python from `DigiPhantStarter/Tracking/.venv` and displays its camera preview.
Choose the group size, Full body or Seated / upper body, then Camera. Click
**Set neutral pose (10 seconds)**, get into position, and hold still. Test one
control at a time. Test sliders also let you explore the rig without live tracking.

The automatic launcher expects the clone to be named `DigiPhantStarter` beside
`Assets`. Do not move its Tracking directory. Auto-launch is Editor-only; built
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

## 6. Run the supplied Python checks

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

## Git and updates

The starter clone is a separate Git repository inside your project. If your group
also uses Git for the whole Unity project, add `/DigiPhantStarter/` to the outer
project's `.gitignore`; commit the imported `Assets/Elephant` with its metadata
the imported `Assets/DigiPhant` with its metadata, and your own work normally. Record the starter repository URL and the output of
`git -C DigiPhantStarter rev-parse HEAD` in your project README so others can clone
the same version. Never commit `.venv`, Unity `Library`, `Temp`, or `Logs`.

To check starter changes, run `git -C DigiPhantStarter status`. To receive an
instructor update with a clean working tree, run `git -C DigiPhantStarter pull
--ff-only`. Updates affect the clone, not the already imported asset. Keep local
bridge changes committed before updating; do not discard work to make a pull pass.
If you modify the bridge, include your modified source in your final submission.

## Troubleshooting

- No camera: close other camera applications, check OS camera permission for the
  launching application, and try another camera index.
- No assignment: choose the correct people count and make all required body parts
  visible. Crossings and occlusion can confuse position-based IDs; reset and recalibrate.
- No Unity data: verify the port and loopback address, run only one bridge, and
  ensure the receiver is active and Camera mode is selected. Calibrate before
  expecting movement.
- Pink materials: check that your project uses URP and inspect material/shader
  compatibility with your selected Unity version.
- Vendor keyboard errors: disable the vendor control component on your instance
  when replacing it with tracking control.
- Dependency installation fails: record the Python version, operating system,
  architecture and complete error, and ask your agent to diagnose it. The supplied
  `.venv` must be created locally; Windows compatibility is not yet certified.
