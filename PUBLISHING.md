# Instructor publishing notes

Publish the contents of this directory as the root of the starter repository.
The student instructions assume the README, Elephant, DigiPhant and Tracking directories
are directly at its root. The repository is
https://github.com/kommanderpi/studentstarter.

For a fresh copy without Git history, run these commands from this directory
after choosing the remote. If already initialized, use the existing history and
remote rather than repeating initialization:

```sh
git init -b main
git add .
git diff --cached --stat
git commit -m "Add DigiPhant student starter"
git remote add origin YOUR_REPOSITORY_URL
git push -u origin main
```

Give students the actual repository URL after publishing. Keep access consistent with the supplied elephant asset's distribution
terms; its source folder does not include a redistribution license.

The repository includes binary FBX, PNG and MediaPipe model files. No Git LFS
pointers are used. Machine-specific virtual environments and installed Python
packages are excluded; students or their agents recreate those using the explicit
virtual-environment and installation commands in README.md, section 3.

Before teaching, test a fresh clone on the intended Mac and Windows machines.
Verify package installation, model loading, camera permissions, skeleton display,
elephant import into a new URP project, and the student integration instructions.
The package includes the custom DigiPhant example scene, runtime and editor
scripts, and required stage materials alongside the elephant vendor package.
Students create a new URP project and copy both Unity asset folders into Assets;
project settings and package manifests are not included. The packaged camera
launcher uses the documented DigiPhantStarter/Tracking location.
