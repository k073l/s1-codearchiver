using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Core.Avatar.Properties;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public class AvatarObject : MonoBehaviour
{
    public enum EType
    {
        Natural,
        Worn
    }

    [Header("Settings")]
    [SerializeField]
    protected string _name;
    [SerializeField]
    protected string _id;
    [SerializeField]
    protected EType _primaryType;
    [SerializeField]
    protected AvatarAttachment[] _attachments;
    [SerializeField]
    protected List<AvatarLayer> _layers;
    [SerializeField]
    protected AvatarPropertyCollection _properties;
    [Header("Misc. Settings")]
    [SerializeField]
    protected bool _reduceFootSizeWhenApplied;
    [SerializeField]
    [Conditional("_reduceFootSizeWhenApplied", false)]
    protected float _footSizeReduction;
    [SerializeField]
    protected EAvatarObjectFlags[] _flags;
    protected IAvatar _appliedAvatar;
    public string Name => _name;
    public string Id => _id;
    public EType PrimaryType => _primaryType;
    public AvatarPropertyCollection PropertyCollection => _properties;
    public float FootSizeReductionAmount { get; }
    public AvatarLayer[] Layers => _layers.ToArray();

    public virtual void Initialize(IAvatar avatar);
    public virtual void LoadProperties(SerializedAvatarObject serializedObject);
    public virtual void SetEnabled(bool enabled);
    public virtual void ApplyGender(float gender);
    public virtual void ApplyWeight(float weight);
    public virtual void Destroy();
    public virtual SerializedAvatarObject Serialize();
    public virtual SerializedAvatarObject SerializeWithPrimaryColor(Color color);
    public bool HasFlag(EAvatarObjectFlags flag);
}