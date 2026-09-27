# Submit a lightweight Unity project through Git

Your group's Unity project needs its own Git repository. The instructor's starter
repository supplies large shared assets; it is not the destination for your work.
Recordings belong on Drive. Assignment details are provided separately.

## Track the work needed to reconstruct your project

- Your scenes, custom and adapted scripts, mappings, small configuration/material
  files, and their `.meta` files. Include adapted `Assets/DigiPhant` files if used.
- `Packages/manifest.json`, `Packages/packages-lock.json` when present, and
  `ProjectSettings`, so the editor version and package requirements are recorded.
- `README.md` with the Git/Drive links and `DIGIPHANT_SETUP.md` with tested setup,
  mappings, recording instructions, and known limitations.
- Any modified Python source or a reproducible patch, plus its requirements.
  Do not lose changes that exist only inside the ignored starter clone.

## Exclude large supplied or generated files

Ask your agent to configure the outer Unity project's `.gitignore`. These are
starting entries for this layout, to combine with a normal Unity ignore file:

```gitignore
/Library/
/Temp/
/Obj/
/Logs/
/UserSettings/
/Build/
/Builds/
**/.venv/
**/__pycache__/
/Recordings/
/recordings/
/DigiPhantStarter/
/Assets/Elephant/
/Assets/Elephant.meta
```

Do not globally ignore `.meta`, `.unity`, `.asset` or `.cs`: they can be essential
student work. Inspect other large files individually. Do not commit the shared
FBX models, large textures, pose model, local Python environment, videos or frame
sequences to your student repository. `.gitignore` does not untrack files already
committed; have your agent inspect tracking status and address that deliberately.

## Make omitted assets recoverable

Record the instructor starter URL and the exact commit used. From a fresh checkout
of your project, the reconstruction instructions must explain how to:

1. Clone `https://github.com/kommanderpi/studentstarter.git` as `DigiPhantStarter`
   beside Assets and check out the recorded commit.
2. Restore `Elephant/` and `Elephant.meta` into Assets, preserving original metadata.
3. Recreate the Python environment and locate the bundled pose model.
4. Restore any documented changes to tracking code or omitted shared assets.
5. Open your submitted scene without overwriting your tracked, adapted DigiPhant
   scripts or scenes with reference copies from the starter.

If you changed an excluded shared asset, a pristine copy is not enough: include
a small reproducible modification script/patch, or store the changed large asset
on Drive and document the exact restore path and metadata. Ask your agent to
verify that all references resolve after reconstruction.

Test these instructions in a separate fresh checkout, preserving your working
project. Record the actual result and any checks not performed. A small repository
that cannot reconstruct the project is not a complete submission. Do not rewrite
the instructor repository or push your project to it.
