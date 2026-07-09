using UnityEngine;

namespace ScheduleOne.Core.Weather;
public class BasicEnclosure : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Vector3 _center;
    [SerializeField]
    private Vector3 _size;
    [Header("Blend Zone Settings")]
    [SerializeField]
    private bool _isBlendZone;
    [SerializeField]
    private LayerMask _collisionLayers;
    [SerializeField]
    private float _backRadius;
    [SerializeField]
    private float _frontRadius;
    [Header("Openings")]
    [SerializeField]
    private GameObject _openingObj;
    private const float EXPOSURE_EPSILON;
    private IEnclosureOpening _opening;
    public bool IsBlendZone => _isBlendZone;
    public Vector3 Center => _center;
    public Vector3 Size => _size;

    private void Awake();
    public bool WithinEnclosure(Vector3 targetPosition);
    public float GetExposure(Vector3 targetPosition);
    protected Vector3 GetSize();
    protected Vector3 GetCenter();
}