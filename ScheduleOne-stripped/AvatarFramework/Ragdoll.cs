using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.AvatarFramework;
public class Ragdoll
{
    private Rigidbody[] _rigidbodies;
    private CharacterJoint[] _joints;
    private Rigidbody _rootRigidbody;
    private Rigidbody[] _impactableRigidbodies;
    private ConstantForce[] _constantForces;
    private Dictionary<Rigidbody, ConstantForce> _constantForceMap;
    public Rigidbody RootRigidbody => _rootRigidbody;
    public Rigidbody[] Rigidbodies => _rigidbodies;

    public Ragdoll(Rigidbody[] rigidbodies, CharacterJoint[] joints, Rigidbody rootRigidbody, Rigidbody[] impactableRigidbodies);
    public void Destroy();
    public void SetGravityMultiplier(float multiplier);
    public void ApplyRagdollForce(Vector3 forcePoint, Vector3 forceDir, ForceMode forceMode = (ForceMode)1);
    public Vector3 GetRootVelocity();
}