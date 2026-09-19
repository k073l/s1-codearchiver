using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCTags : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField]
    private List<string> _tags;
    public List<string> GetTags();
    public void AddTag(string tag);
    public void RemoveTag(string tag);
    public bool HasTag(string tag);
}