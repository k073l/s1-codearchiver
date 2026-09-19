using UnityEngine;

namespace ScheduleOne.Development;
public class DevTesting : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private string animationName;
    [SerializeField]
    private bool isAnimationActive;
    [SerializeField]
    private Transform avatar;
    [SerializeField]
    private Animator animator;
    private void OnValidate();
}