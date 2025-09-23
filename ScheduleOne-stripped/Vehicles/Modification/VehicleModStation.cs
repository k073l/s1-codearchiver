using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Vehicles.Modification;
public class VehicleModStation : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    protected Transform vehiclePosition;
    [SerializeField]
    protected OrbitCamera orbitCam;
    public LandVehicle currentVehicle { get; protected set; }
    public bool isOpen => (Object)(object)currentVehicle != (Object)null;

    public void Open(LandVehicle vehicle);
    protected virtual void Update();
    public void Close();
}