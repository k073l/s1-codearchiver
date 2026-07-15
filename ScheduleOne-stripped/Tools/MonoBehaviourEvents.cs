using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Tools;
public class MonoBehaviourEvents : MonoBehaviour
{
    public UnityEvent onAwake;
    public UnityEvent onStart;
    public UnityEvent onUpdate;
    public UnityEvent onEnable;
    public UnityEvent onDisable;
    private void Awake();
    private void Start();
    private void Update();
    private void OnEnable();
    private void OnDisable();
}