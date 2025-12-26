using EasyButtons;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Growing;
public class GrowContainerCameraHandler : MonoBehaviour
{
    public enum ECameraPosition
    {
        Closeup,
        Midshot,
        Fullshot,
        BirdsEye
    }

    [SerializeField]
    private bool RotateCameraContainerToFacePlayer;
    [SerializeField]
    private bool SnapRotationToRightAngles;
    [SerializeField]
    private Transform _midshotCamera;
    [SerializeField]
    private Transform _closeupCamera;
    [SerializeField]
    private Transform _fullshotContainer;
    [SerializeField]
    private Transform _birdsEyeCamera;
    [Header("Debug & Development")]
    [SerializeField]
    private ECameraPosition _debugCameraPosition;
    public void PositionCameraContainer();
    public Transform GetCameraPosition(ECameraPosition pos, bool autoPosition = true);
    [Button("Set Camera Position")]
    private void SetCameraPosition();
}