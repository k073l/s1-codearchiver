import os
import logging
import json
import subprocess
from dotenv import load_dotenv
from update import check_for_updates, init_cache, CACHE_FILE, TRACKED_BRANCHES
from download import download_branch_files, decompile_game_assembly
from git_utils import copy_stripped_to_repo, git_commit_all, get_version_txt

load_dotenv()
FULL_CODE_PATH = os.getenv("FULL_CODE_PATH", "fullcode")
STRIPPED_CODE_PATH = os.getenv("STRIPPED_CODE_PATH", "stripped")
DEPOTDOWNLOADER_PATH = os.getenv("DEPOTDOWNLOADER_PATH", "DepotDownloader-framework")
USERNAME = os.getenv("USERNAME", "changeme123")
DOWNLOAD_DIR_PATH = os.getenv("DOWNLOAD_DIR_PATH", "download")
ASSEMBLY_DECOMPILER_PATH = os.getenv("ASSEMBLY_DECOMPILER_PATH", "AssemblyDecompiler-framework")

logging.basicConfig(level=logging.INFO, format="%(asctime)s %(levelname)s: %(message)s")

if __name__ == "__main__":
    # Initialize cache file if not present
    if not os.path.exists(CACHE_FILE):
        init_cache(CACHE_FILE)
        logging.info(f"Initialized cache file at {CACHE_FILE}.")
    with open(CACHE_FILE, "r") as f:
        cache = json.load(f)

    update_dict = {
        "alternate": cache.get("last_downloaded_alternate", 0),
        "alternate-beta": cache.get("last_downloaded_alternate-beta", 0),
    }
    logging.info(f'Checking for updates on branches: {", ".join(TRACKED_BRANCHES)}')
    to_update = check_for_updates(update_dict)

    for branch, time in to_update.items():
        success = download_branch_files(
            DEPOTDOWNLOADER_PATH,
            branch,
            [
                "Schedule I_Data/Managed/Assembly-CSharp.dll",
                "Schedule I_Data/globalgamemanagers",
            ],
            DOWNLOAD_DIR_PATH,
            USERNAME,
        )
        if not success:
            logging.error(
                f"Skipping cache update and decompilation for branch {branch} due to download failure."
            )
            continue
        # Downloaded, update cache
        cache["last_downloaded_" + branch] = int(time)
        logging.info(f"Updated cache for {branch} to time {time}")
        success = decompile_game_assembly(
            DOWNLOAD_DIR_PATH,
            branch,
            ASSEMBLY_DECOMPILER_PATH,
            FULL_CODE_PATH,
            STRIPPED_CODE_PATH,
        )
        if not success:
            logging.error(f"Decompilation failed for branch {branch}.")
            continue

        # Commit stripped code to ScheduleOne-stripped
        repo_dir = os.getcwd()
        subprocess.run(["git", "reset", "--hard"], cwd=repo_dir)
        subprocess.run(["git", "clean", "-fd"], cwd=repo_dir)
        result = subprocess.run(["git", "checkout", branch], cwd=repo_dir, capture_output=True, text=True)
        if result.returncode != 0:
            logging.error(f"Failed to checkout branch {branch}:\n{result.stderr}")
            continue

        result = subprocess.run(["git", "rev-parse", "--abbrev-ref", "HEAD"], cwd=repo_dir, capture_output=True, text=True)
        if result.stdout.strip() != branch:
            logging.error(f"Sanity check failed: expected branch '{branch}' but on '{result.stdout.strip()}'")
            continue
        logging.info(f"Checked out branch {branch} successfully")
        branch_output = os.path.join(STRIPPED_CODE_PATH, branch)
        copy_stripped_to_repo(branch_output, repo_dir)

        commit_msg = f"Auto-update for version {get_version_txt(branch_output)}"
        git_commit_all(repo_dir, commit_msg)
        push_result = subprocess.run(["git", "push", "origin", branch], cwd=repo_dir, capture_output=True, text=True)
        if push_result.returncode == 0:
            logging.info(f"Pushed branch {branch} to remote.")
        else:
            logging.error(f"Failed to push branch {branch} to remote:\n{push_result.stderr}")

    if to_update:
        # Save
        with open(CACHE_FILE, "w") as f:
            json.dump(cache, f, indent=4)
    else:
        logging.info("No new updates - exiting")
