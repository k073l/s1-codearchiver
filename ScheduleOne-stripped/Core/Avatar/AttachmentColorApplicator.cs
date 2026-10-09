using System;
using ScheduleOne.Core.Avatar.Properties;
using UnityEngine;

namespace ScheduleOne.Core.Avatar;
[RequireComponent(typeof(AvatarAttachment))]
public class AttachmentColorApplicator : MonoBehaviour
{
    [Serializable]
    public class MeshSelection
    {
        public Renderer Renderer;
        public int[] MaterialIndices;
        public string[] MaterialPropertyNames;
    }

    [Serializable]
    public class ColorMapping
    {
        public string PropertyName;
        public MeshSelection[] Meshes;
    }

    [SerializeField]
    private ColorMapping[] _colorMappings;
    private AvatarObject _avatarObject;
    private AvatarAttachment _attachment;
    private void Awake();
    private void Start();
    private void ApplyColors();
}