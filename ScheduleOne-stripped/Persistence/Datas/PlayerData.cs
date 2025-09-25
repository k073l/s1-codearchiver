using System;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class PlayerData : SaveData
{
    public string PlayerCode;
    public Vector3 Position;
    public float Rotation;
    public bool IntroCompleted;
    public PlayerData(string playerCode, Vector3 playerPos, float playerRot, bool introCompleted);
    public PlayerData();
//IL_0006: Unknown result type (might be due to invalid IL or missing references)
}