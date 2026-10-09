using System;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.SpecialCustomers;
public class SpecialCustomerGroupWorldModifier : MonoBehaviour
{
    [Serializable]
    public class MoveableObject
    {
        public Transform Target;
        public Transform MovedPosition;
        private bool _isMoved;
        private TransformData _originalPosition;
        public void MoveToPosition();
        public void MoveBackToOriginalPosition();
    }

    [Serializable]
    public class GroupEvent
    {
        public string GroupId;
        public GameObject[] GameObjectsToDisableWhileGroupIsActive;
        public GameObject[] GameObjectsToEnableWhileGroupIsActive;
        public MoveableObject[] ObjectsToMoveWhileGroupIsActive;
        public UnityEvent OnGroupPresent;
        public UnityEvent OnGroupLeave;
        public void TriggerGroupPresent();
        public void TriggerGroupLeave();
    }

    [SerializeField]
    private GroupEvent[] groupEvents;
    private void Start();
    private void OnDestroy();
    private void OnDrawGizmos();
    private void OnGroupAdded(string id);
    private void OnGroupRemoved(string id);
}