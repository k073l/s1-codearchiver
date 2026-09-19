using UnityEngine;
using UnityEngine.EventSystems;

namespace ScheduleOne.Tools;
public class OrbitCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 targetOffset;
    [Header("Rotation")]
    [SerializeField]
    private int dragButton;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float minPitch;
    [SerializeField]
    private float maxPitch;
    [Header("Zoom")]
    [SerializeField]
    private float zoomSpeed;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float distance;
    private float _yaw;
    private float _pitch;
    private bool _isDragging;
    private bool _focussedLastFrame;
    private void Start();
    private void Update();
    private void HandleRotationInput();
    private void HandleZoomInput();
    private void ApplyTransform();
    private static bool IsPointerOverUI();
}