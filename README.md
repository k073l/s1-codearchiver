# S1CodeArchiver

Automated Steam game branch updater and code tracker for Schedule I.

## Overview
S1CodeArchiver is a Python tool that automatically checks for updates to tracked Steam branches, downloads and decompiles game assemblies, and commits stripped code to dedicated branches in a git repository. It is designed for Schedule I modding and code archival workflows.

## Features
- Checks for updates on specified Steam branches (e.g., `alternate`, `alternate-beta`)
- Downloads and decompiles game assemblies using DepotDownloader and AssemblyDecompiler
- Copies stripped code to a dedicated directory (`ScheduleOne-stripped/`)
- Commits stripped code to corresponding git branches with versioned commit messages
- Maintains a cache to avoid redundant downloads

## Setup
0. Download [DepotDownloader](https://github.com/SteamRE/DepotDownloader) and AssemblyDecompiler framework versions. Uncompress them to known locations.
1. Clone this repository and install requirements:
	```sh
	pip install -r requirements.txt
	```
    Other dependencies: .NET, Python 3.8+, git, Steam account with access to Schedule I
2. Configure `.env` with your paths and credentials:
	- `FULL_CODE_PATH`, `STRIPPED_CODE_PATH`, `DEPOTDOWNLOADER_PATH`, `USERNAME`, `DOWNLOAD_DIR_PATH`, `ASSEMBLY_DECOMPILER_PATH`
3. Create your own git repository and create the empty `ScheduleOne-stripped/` directory with a `.gitkeep` file on `main`.
4. Pre-create the target branches (`alternate`, `alternate-beta`) from `main`.
5. Initialize DepotDownloader by running it once with your Steam credentials to cache login. `dotnet DepotDownloader.dll -app 3164500 -username YOUR_USERNAME -remember-password` - will ask for password, 2FA and start the download, which you can cancel after it starts. DepotDownloader will cache your credentials using [Isolated Storage](https://learn.microsoft.com/en-us/dotnet/standard/io/isolated-storage).

## Usage
Run the updater script:
```sh
python main.py
```
The script will:
- Check for updates on tracked branches
- Download and decompile new assemblies
- Switch to the target branch, copy stripped code, and commit with the version
- Switch back to `main` when done

## Workflow
- `main` branch contains your scripts and tooling
- `alternate` and `alternate-beta` branches contain only stripped game code in `ScheduleOne-stripped/`
- No crosstalk: each branch is isolated and only contains its own commits

## License
Python code and AssemblyDecompiler - MIT, dependency licenses apply.
ScheduleOne-stripped contains code stubs from Schedule I, game by TVGS. These stubs are provided for archival and modding purposes only. All rights to the original code belong to TVGS.
