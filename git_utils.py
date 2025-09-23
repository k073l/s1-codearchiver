import os
import shutil
import subprocess
import logging

def git_checkout_branch(repo_path: str, branch: str):
    """Checkout or create branch in repo."""
    subprocess.run(["git", "checkout", "-B", branch], cwd=repo_path)
    logging.info(f"Checked out branch {branch} in {repo_path}")

def copy_stripped_to_repo(src_dir: str, repo_dir: str):
    """Copy contents of stripped/branch/ScheduleOne into ScheduleOne-stripped/ in repo, replacing existing files."""
    src = os.path.join(src_dir, "ScheduleOne")
    dest = os.path.join(repo_dir, "ScheduleOne-stripped")
    if not os.path.exists(src):
        logging.warning(f"Source ScheduleOne not found at {src}")
        return
    # Remove all files/folders in dest except .gitkeep
    if not os.path.exists(dest):
        os.makedirs(dest)
    for item in os.listdir(dest):
        if item == ".gitkeep":
            continue
        item_path = os.path.join(dest, item)
        if os.path.isdir(item_path):
            shutil.rmtree(item_path)
        else:
            os.remove(item_path)
    # Copy contents of ScheduleOne into ScheduleOne-stripped
    for item in os.listdir(src):
        s = os.path.join(src, item)
        d = os.path.join(dest, item)
        if os.path.isdir(s):
            shutil.copytree(s, d)
        else:
            shutil.copy2(s, d)
    logging.info(f"Copied contents of {src} to {dest}")

def git_commit_all(repo_path: str, commit_message: str):
    """Add all and commit with message."""
    subprocess.run(["git", "add", "-A"], cwd=repo_path)
    subprocess.run(["git", "commit", "-m", commit_message], cwd=repo_path)
    logging.info(f"Committed changes in {repo_path} with message: {commit_message}")

def get_version_txt(branch_dir: str) -> str:
    """Read version.txt from branch dir."""
    version_path = os.path.join(branch_dir, "version.txt")
    if os.path.exists(version_path):
        with open(version_path) as f:
            return f.read().strip()
    return "Unknown"
