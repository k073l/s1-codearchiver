using System;
using UnityEngine;

namespace ScheduleOne.Core;
public abstract class IdentifiedScriptableObject : ScriptableObject
{
    [Serializable]
    private class SerializedGUID
    {
        [SerializeField]
        private string _guidString;
        public void Set(Guid guid);
        public Guid ToGuid();
    }

    [SerializeField]
    [HideInInspector]
    private SerializedGUID _serializedGUID;
    public Guid GUID => _serializedGUID.ToGuid();

    public void SetGuid(Guid guid);
}