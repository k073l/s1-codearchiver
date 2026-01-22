using System;
using System.Collections.Generic;
using ScheduleOne.Vehicles.Modification;
using UnityEngine;

namespace ScheduleOne.Persistence.Datas;
[Serializable]
public class VehicleData : SaveData
{
    public string GUID;
    public string VehicleCode;
    public Vector3 Position;
    public Quaternion Rotation;
    public string Color;
    public ItemSet VehicleContents;
    public List<SpraySurfaceData> SpraySurfaces;
    public VehicleData(Guid guid, string code, Vector3 pos, Quaternion rot, EVehicleColor col, ItemSet vehicleContents, List<SpraySurfaceData> spraySurfaces);
}