using UnityEngine;

namespace ScheduleOne.Avatar.Impostors;
public class AvatarImpostor : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private Texture2D _defaultImpostorTexture;
    [SerializeField]
    private Transform _hipBone;
    private bool _impostorSet;
    private void Awake();
    public void SetTexture(Texture2D impostorTexture);
    private void LateUpdate();
    private void UpdatePosition();
    public void Enable();
    public void Disable();
    public void SetRotation(float rotation);
}