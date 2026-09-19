using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.AvatarFramework;
public class RagdollTemplate : MonoBehaviour
{
    [SerializeField]
    private List<Rigidbody> _impactableRigidbodies;
    [SerializeField]
    private Rigidbody _rootRigidbody;
    public Ragdoll CreateRagdoll(Transform rootBone);
    private void CloneRigidbodyData(Rigidbody from, Rigidbody to);
    private void CloneJointData(CharacterJoint from, CharacterJoint to, Rigidbody connectedBody);
    private Transform GetBone(Transform rootBone, string boneName);
}