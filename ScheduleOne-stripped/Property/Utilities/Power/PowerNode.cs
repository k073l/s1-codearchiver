using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Property.Utilities.Power;
public class PowerNode : MonoBehaviour
{
    public bool poweredNode;
    public bool consumptionNode;
    public bool isConnectedToPower;
    [Header("References")]
    [SerializeField]
    protected Transform connectionPoint;
    public List<PowerLine> connections;
    public Transform pConnectionPoint => connectionPoint;

    public bool IsConnectedTo(PowerNode node);
    public void RecalculatePowerNetwork();
    public List<PowerNode> GetConnectedNodes(List<PowerNode> exclusions);
}