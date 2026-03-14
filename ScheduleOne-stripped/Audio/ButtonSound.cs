using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScheduleOne.Audio;
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(AudioSourceController))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("PlaySoundOnClickStart")]
    private bool _playSoundOnClickStart;
    [SerializeField]
    [FormerlySerializedAs("HoverClip")]
    private AudioClip _hoverClip;
    [SerializeField]
    [FormerlySerializedAs("HoverSoundVolume")]
    private float _hoverVolume;
    [SerializeField]
    [FormerlySerializedAs("ClickClip")]
    private AudioClip _clickClip;
    [SerializeField]
    [FormerlySerializedAs("ClickSoundVolume")]
    private float _clickVolume;
    private AudioSourceController _audioSource;
    private Button _button;
    private EventTrigger _eventTrigger;
    public void Awake();
    public void AddEventTrigger(EventTrigger eventTrigger, EventTriggerType eventTriggerType, Action action);
    protected virtual void Hovered();
    protected virtual void Clicked();
}