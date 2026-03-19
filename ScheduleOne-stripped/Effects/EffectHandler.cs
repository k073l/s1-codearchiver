using System;
using System.Collections;
using UnityEngine;

namespace ScheduleOne.Effects;
public abstract class EffectHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private string _id;
    [SerializeField]
    private bool _scaleToParent;
    [SerializeField]
    private bool _positionToParent;
    [SerializeField]
    private bool _activeByDefault;
    private Coroutine _delayDeactivateCoroutine;
    public virtual string Id => _id;
    public virtual bool ScaleToParent => _scaleToParent;
    public virtual bool PositionToParent => _positionToParent;

    public abstract void Activate();
    public abstract void Deactivate();
    public abstract void SetNumericParameter(string effectName, string variable, float value);
    public abstract void SetNumericParameterForAll(string variable, float value);
    public abstract void SetVectorParameter(string effectName, string variable, Vector3 value);
    public abstract void SetVectorParameter(string effectName, string variable, Vector2 value);
    public abstract void SetVectorParameterForAll(string variable, Vector3 value);
    public abstract void SetVectorParameterForAll(string variable, Vector2 value);
    public abstract void SetColorParameterForAll(string variable, Color value);
    public virtual void Initialise();
    public void SetPosition(Vector3 position);
    public void SetSize(Vector3 size);
    public void DelayDeactivate(float duration, Action onComplete = null);
    private IEnumerator DoDelayDeactivate(float duration, Action onComplete = null);
    protected string AddPrefixToVariableName(string variable);
}