using System.Collections.Generic;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Tools;
public class RoadCracksRandomizer : MonoBehaviour
{
    public Transform[] Cracks;
    public int MinCount;
    public int MaxCount;
    [Button]
    private void Randomize();
}