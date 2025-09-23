import json
import logging
import requests
from datetime import datetime

API_URL = "https://api.steamcmd.net/v1/info/"
APPID = 3164500
TRACKED_BRANCHES = ["alternate", "alternate-beta"]
CACHE_FILE = "cache.json"

def check_for_updates(last_downloaded_time: dict[str, int]) -> dict[str, int]:
    """Check for updates on tracked branches. Returns dict of branch: time for updates found."""
    r = requests.get(API_URL + str(APPID))
    if r.status_code != 200:
        logging.error(f"Failed to fetch data from API, status code: {r.status_code}")
        return {}
    response_json = r.json()
    depots = response_json["data"][str(APPID)]["depots"]
    branch_time_map = {
        key: branch["timeupdated"]
        for key, branch in depots["branches"].items()
        if key in TRACKED_BRANCHES
    }
    ret = {}
    for branch, time in branch_time_map.items():
        time = int(time)
        if branch not in last_downloaded_time or time > last_downloaded_time[branch]:
            logging.info(
                f"New update found for branch {branch}, at time {time} ({datetime.fromtimestamp(time)})"
            )
            ret[branch] = time
    return ret

def init_cache(path: str):
    cache = {"last_downloaded_alternate": 0, "last_downloaded_alternate-beta": 0}
    with open(path, "w") as f:
        json.dump(cache, f, indent=4)
