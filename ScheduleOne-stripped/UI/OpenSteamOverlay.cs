using Steamworks;
using UnityEngine;

namespace ScheduleOne.UI;
public class OpenSteamOverlay : MonoBehaviour
{
    public enum EType
    {
        Store,
        CustomLink
    }

    public const uint APP_ID;
    public EType Type;
    public string CustomLink;
    public void OpenOverlay();
}