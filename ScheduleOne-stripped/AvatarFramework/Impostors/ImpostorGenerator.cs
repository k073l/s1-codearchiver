using System.Collections.Generic;
using ScheduleOne.NPCs.Framework;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Impostors;
public class ImpostorGenerator : MonoBehaviour
{
    [Header("Settings")]
    public List<NPCDataObject> GenerationQueue;
    [Header("References")]
    public Camera ImpostorCamera;
    public Avatar Avatar;
    private Texture2D output;
}