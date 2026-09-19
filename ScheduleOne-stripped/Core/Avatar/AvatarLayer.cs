using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[CreateAssetMenu(fileName = "New Avatar Layer", menuName = "ScheduleOne/Avatar/Avatar Layer")]
public class AvatarLayer : ScriptableObject
{
    public enum EType
    {
        FullBody,
        Face
    }

    [SerializeField]
    protected EType _type;
    [SerializeField]
    protected Texture2D _texture;
    [SerializeField]
    protected Texture2D _normal;
    [SerializeField]
    protected short _layeringOrder;
    [Header("Legacy")]
    [SerializeField]
    private Texture2D _normalAsDefaultFormat;
    public EType Type => _type;
    public int LayeringOrder => _layeringOrder;
    public bool LayerEnabled { get; private set; } = true;

    public virtual void Initialize();
    public virtual void SetEnabled(bool enabled);
    public virtual void Destroy();
    public virtual Texture2D GetTextureToApply();
    public virtual Texture2D GetNormalTextureToApply();
}