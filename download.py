import logging
import tempfile
import subprocess
import os

def download_branch_files(
    depotdownloader_path: str,
    branch: str,
    filelist: list[str],
    output_dir: str,
    username: str,
) -> bool:
    """Download files for a branch using DepotDownloader. Returns True if successful."""
    try:
        with tempfile.NamedTemporaryFile("w+t", suffix=".txt") as tmpfile:
            for line in filelist:
                tmpfile.write(line + "\n")
            tmpfile.flush()
            args = [
                "-username",
                username,
                "-remember-password",
                "-app",
                str(3164500),
                "-branch",
                branch,
                "-filelist",
                tmpfile.name,
                "-dir",
                os.path.join(output_dir, branch),
            ]
            p = subprocess.Popen(
                [
                    "dotnet",
                    os.path.join(depotdownloader_path, "DepotDownloader.dll"),
                    *args,
                ],
                stderr=subprocess.STDOUT,
            )
            exit_code = p.wait()
            if exit_code == 0:
                logging.info(f"Downloaded branch {branch} to {output_dir}")
                return True
            else:
                logging.error(
                    f"Download failed for branch {branch} with exit code {exit_code}"
                )
                return False
    except Exception as e:
        logging.error(f"Exception during download for branch {branch}: {e}")
        return False

def decompile_game_assembly(
    download_dir_path: str,
    branch: str,
    assembly_decompiler_path: str,
    full_code_path: str,
    stripped_code_path: str,
) -> bool:
    """Decompile game assembly for a branch. Returns True if successful."""
    args = [
        "-a",
        os.path.join(
            download_dir_path,
            branch,
            "Schedule I_Data",
            "Managed",
            "Assembly-CSharp.dll",
        ),
        "-m",
        os.path.join(
            download_dir_path, branch, "Schedule I_Data", "globalgamemanagers"
        ),
        "-f",
        os.path.join(full_code_path, branch),
        "-o",
        os.path.join(stripped_code_path, branch),
    ]
    try:
        p = subprocess.Popen(
            [
                "dotnet",
                os.path.join(assembly_decompiler_path, "AssemblyDecompiler.dll"),
                *args,
            ],
            stderr=subprocess.STDOUT,
        )
        exit_code = p.wait()
        if exit_code == 0:
            logging.info(
                f"Decompiled game code to {full_code_path}, stripped code saved in {stripped_code_path}"
            )
            return True
        else:
            logging.error(
                f"Decompilation failed for branch {branch} with exit code {exit_code}"
            )
            return False
    except Exception as e:
        logging.error(f"Exception during decompilation for branch {branch}: {e}")
        return False
