using System.Collections.Generic;
using System.Linq;
using EasyButtons;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class LODAdjuster : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private LODGroup _lodGroup;
    [Header("LOD Settings")]
    [SerializeField]
    private string _rendererName;
    [SerializeField]
    private int _lodLevel;
    [Button]
    public void AddToLodGroup();
}