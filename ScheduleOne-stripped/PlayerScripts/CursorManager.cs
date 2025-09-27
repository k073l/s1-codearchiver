using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.PlayerScripts;
public class CursorManager : Singleton<CursorManager>
{
    public enum ECursorType
    {
        Default,
        Finger,
        OpenHand,
        Grab,
        Scissors,
        Spray
    }

    [Serializable]
    public class CursorConfig
    {
        public ECursorType CursorType;
        public Texture2D Texture;
        public Vector2 HotSpot;
    }

    [Header("References")]
    public List<CursorConfig> Cursors;
    protected override void Awake();
    public void SetCursorAppearance(ECursorType type);
}