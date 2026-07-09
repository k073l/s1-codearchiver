using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Gamepad;
using ScheduleOne.PlayerTasks;
using ScheduleOne.UI.Input;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ObjectScripts;
public class BunsenBurner : MonoBehaviour
{
    public bool LockDial;
    [Header("Settings")]
    public Gradient FlameColor;
    public AnimationCurve LightIntensity;
    public float HandleRotationSpeed;
    public AnimationCurve FlamePitch;
    [Header("References")]
    public ParticleSystem Flame;
    public Light Light;
    public Transform Handle;
    public Clickable HandleClickable;
    public Transform Handle_Min;
    public Transform Handle_Max;
    public Transform Highlight;
    public Animation Anim;
    public AudioSourceController FlameSound;
    [Header("Prompt Data")]
    [SerializeField]
    private InputPromptsData _handlePromptData;
    [SerializeField]
    private Transform _handlePromptAnchor;
    public bool Interactable { get; private set; }
    public bool IsDialHeld { get; private set; }
    public float CurrentDialValue { get; private set; }
    public float CurrentHeat { get; private set; }

    private void Start();
    private void Update();
    private void UpdateEffects();
    public void SetDialPosition(float pos);
    public void SetInteractable(bool e);
    private float GetDialValue();
    public void ClickStart(RaycastHit hit);
    public void ClickEnd();
}