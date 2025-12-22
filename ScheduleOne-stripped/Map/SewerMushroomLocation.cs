using System;
using System.Collections.Generic;
using EasyButtons;
using UnityEngine;

namespace ScheduleOne.Map;
public class SewerMushroomLocation : MonoBehaviour
{
    [Serializable]
    public struct MushroomLocationData
    {
        public bool isActive;
        public Vector3 location;
        public Quaternion rotation;
        public float scale;
    }

    [Header("Properties")]
    [SerializeField]
    private List<MushroomLocationData> _data;
    public void SetMushroomsFromData(GameObject mushroomObject);
    private void SetMushroomFromData(Transform childMushroomObj, MushroomLocationData data);
    public void ClearData();
    [Button]
    public void SetMushroomLocationData();
}