using System;
using System.Collections.Generic;
using ScheduleOne.ConstructableScripts;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Property.Utilities.Power;
public class PowerLine : Constructable
{
    public static int powerLine_MinSegments;
    public static int powerLine_MaxSegments;
    public static float maxLineLength;
    public static float updateThreshold;
    public PowerNode nodeA;
    public PowerNode nodeB;
    public float LengthFactor;
    protected List<Transform> segments;
    private Vector3 nodeA_LastUpdatePos;
    private Vector3 nodeB_LastUpdatePos;
    private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002EUtilities_002EPower_002EPowerLineAssembly_002DCSharp_002Edll_Excuted;
    private bool NetworkInitialize__LateScheduleOne_002EProperty_002EUtilities_002EPower_002EPowerLineAssembly_002DCSharp_002Edll_Excuted;
    public void InitializePowerLine(PowerNode a, PowerNode b);
    public override void DestroyConstructable(bool callOnServer = true);
    protected virtual void LateUpdate();
    private void RefreshVisuals();
    private void RefreshBoundingBox();
    public PowerNode GetOtherNode(PowerNode firstNode);
    public void SetVisible(bool v);
    public override Vector3 GetCosmeticCenter();
    public static bool CanNodesBeConnected(PowerNode nodeA, PowerNode nodeB);
    public static int GetSegmentCount(Vector3 startPoint, Vector3 endPoint);
    public static void DrawPowerLine(Vector3 startPoint, Vector3 endPoint, List<Transform> segments, float lengthFactor);
    private static void PositionSegments(List<Vector3> points, List<Transform> segments);
    private static List<Vector3> GetCatenaryPoints(Vector3 startPoint, Vector3 endPoint, int pointCount, float l);
    public override void NetworkInitialize___Early();
    public override void NetworkInitialize__Late();
    public override void NetworkInitializeIfDisabled();
    public override void Awake();
}