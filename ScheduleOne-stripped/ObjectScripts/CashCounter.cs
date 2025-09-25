using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Audio;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class CashCounter : MonoBehaviour
{
    public const float NoteLerpTime;
    public bool IsOn;
    [Header("References")]
    public GameObject UpperNotes;
    public GameObject LowerNotes;
    public Transform NoteStartPoint;
    public Transform NoteEndPoint;
    public List<Transform> MovingNotes;
    public AudioSourceController Audio;
    private bool lerping;
    public virtual void LateUpdate();
    private IEnumerator LerpNote(Transform note);
}