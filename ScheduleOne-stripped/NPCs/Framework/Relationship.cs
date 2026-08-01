using System;
using UnityEngine;

namespace ScheduleOne.NPCs.Framework;
[Serializable]
public class Relationship
{
    [Range(0f, 1f)]
    public float DefaultRelationshipValue;
    public bool DisplayRelationshipValue;
    public Relationship GetCopy();
}