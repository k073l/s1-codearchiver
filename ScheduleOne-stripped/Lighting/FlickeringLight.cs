using UnityEngine;

namespace ScheduleOne.Lighting;
[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour
{
    [Header("Intensity Settings")]
    [Tooltip("The minimum light intensity.")]
    public float minIntensity;
    [Tooltip("The maximum light intensity.")]
    public float maxIntensity;
    [Header("Color Settings")]
    [Tooltip("Enable slight color shifts to simulate a warm flame.")]
    public bool enableColorShift;
    public Color minColor;
    public Color maxColor;
    [Header("Flicker Movement")]
    [SerializeField]
    private bool _enableFlickerMovement;
    [SerializeField]
    private float _flickerMovementRange;
    [SerializeField]
    private float _flickerMovementSpeed;
    [Header("Flicker Speed")]
    [Tooltip("How quickly the light flickers (lower is faster).")]
    public float flickerSpeed;
    private Light lightSource;
    private float targetIntensity;
    private Vector3 _targetMovement;
    private Vector3 _originalPosition;
    private Color targetColor;
    private void Start();
    private void Update();
    private void UpdateTargetValues();
    private void UpdateMovement();
}