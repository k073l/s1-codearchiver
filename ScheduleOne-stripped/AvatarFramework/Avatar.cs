using System;
using EPOOutline;
using ScheduleOne.Avatar;
using ScheduleOne.Avatar.Impostors;
using ScheduleOne.AvatarFramework.Animation;
using ScheduleOne.AvatarFramework.Emotions;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.Core.Avatar;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework;
public class Avatar : MonoBehaviour, IThirdPersonReferencesProvider, IAvatar
{
    private const float FrustrumCullMinDist;
    public Action<bool> OnAvatarCullingChange;
    public Action<bool> OnRagdollChange;
    [Header("Settings")]
    [Range(10f, 500f)]
    [SerializeField]
    private float _cullingRange;
    [SerializeField]
    private RagdollTemplate _ragdollTemplate;
    [Header("References")]
    public AvatarAnimation Animation;
    public AvatarLookController LookController;
    public EyeController Eyes;
    public EyebrowController EyeBrows;
    [SerializeField]
    private Transform BodyContainer;
    public Transform LeftShoulder;
    public Transform RightShoulder;
    public Transform HipBone;
    [SerializeField]
    private Transform _rightHandContainer;
    [SerializeField]
    private Transform _leftHandContainer;
    [SerializeField]
    private Transform _rightHandAlignmentPoint;
    [SerializeField]
    private Transform _leftHandAlignmentPoint;
    public AvatarEmotionManager EmotionManager;
    public AvatarEffects Effects;
    public Transform MiddleSpine;
    public Transform LowestSpine;
    public ParticleSystem BloodParticles;
    [SerializeField]
    private AttachmentAnchorProviderComponent _attachmentAnchorProvider;
    [SerializeField]
    private AvatarAppearance _appearance;
    [SerializeField]
    private AvatarImpostor _impostor;
    [SerializeField]
    private Transform _ragdollRoot;
    [SerializeField]
    private Collider[] _avatarColliders;
    [Header("Outlining")]
    [SerializeField]
    protected GameObject[] _renderersToOutline;
    protected Outlinable _outlineEffect;
    private Ragdoll _activeRagdoll;
    private Vector3 _savedHipPosition;
    private float _visibilityRangeSqr;
    private float _gravityMultiplier;
    public Transform RightHandContainer => _rightHandContainer;
    public Transform LeftHandContainer => _leftHandContainer;
    public Transform RightHandAlignmentPoint => _rightHandAlignmentPoint;
    public Transform LeftHandAlignmentPoint => _leftHandAlignmentPoint;
    public IAttachmentAnchorProvider AttachmentAnchorProvider => _attachmentAnchorProvider;
    public AvatarAppearance Appearance => _appearance;
    public bool IsCulled { get; private set; }
    public bool Ragdolled => _activeRagdoll != null;
    public Ragdoll ActiveRagdoll => _activeRagdoll;
    public AvatarEquippable CurrentEquippable { get; protected set; }
    public Transform CenterPointTransform => MiddleSpine;
    public Vector3 CenterPoint => ((Component)CenterPointTransform).transform.position;

    protected virtual void Awake();
    protected virtual void Update();
    public Vector3 GetRagdollRootVelocity();
    public void SetVisible(bool vis);
    public void SetAnimationBool(string name, bool value);
    public void SetAnimationTrigger(string name);
    public void SetGravityMultiplier(float multiplier);
    public void SetIgnoreCollision(Collider collider, bool ignore);
    public void SetIgnoreCollision(Collider[] colliders, bool ignore);
    public void SetAvatarCollidersEnabled(bool enabled);
    public void SetImpostorTexture(Texture2D impostorTexture);
    private void RecalculateVisibilityRangeSqr(int a, int b);
    private void UpdateAnimationActive();
    public void EnableRagdoll();
    public void EnableRagdollAndApplyForce(Vector3 forcePoint, Vector3 forceDir);
    public void DisableRagdoll();
    public void RealignAvatarToHips(bool isHipBoneFacingUpwards);
    private void SetRagdollEnabled(bool ragdoll, Vector3 forcePoint = default(Vector3), Vector3 forceDir = default(Vector3));
    public void ApplyRagdollForce(Vector3 forcePoint, Vector3 forceDir, ForceMode forceMode = (ForceMode)1);
    public void ShowOutline(Color color);
    public void HideOutline();
    public virtual AvatarEquippable SetEquippable(string assetPath);
    public virtual void ReceiveEquippableMessage(string message, object data);
}