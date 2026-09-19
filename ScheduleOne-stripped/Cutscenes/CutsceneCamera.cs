using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Cutscenes;
public class CutsceneCamera : MonoBehaviour
{
    [SerializeField]
    private bool _controlFoV;
    [Conditional("_controlFoV", false)]
    [SerializeField]
    [Range(10f, 100f)]
    private float _fov;
    public bool ControlFoV => _controlFoV;
    public float FoV => _fov;

    private void OnEnable();
    private void OnDisable();
}