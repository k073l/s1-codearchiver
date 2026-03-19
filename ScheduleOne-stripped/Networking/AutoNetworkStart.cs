using FishNet.Managing;
using UnityEngine;

namespace ScheduleOne.Networking;
[RequireComponent(typeof(NetworkManager))]
public class AutoNetworkStart : MonoBehaviour
{
    private enum EAutoStartType
    {
        Disabled,
        Host,
        Server,
        Client
    }

    [SerializeField]
    private EAutoStartType _autoStartType;
}