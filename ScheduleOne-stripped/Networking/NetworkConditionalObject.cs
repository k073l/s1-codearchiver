using System;
using FishNet;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Networking;
public class NetworkConditionalObject : MonoBehaviour
{
    public enum ECondition
    {
        All,
        HostOnly
    }

    public ECondition condition;
    private void Awake();
    public void Check();
}