using ScheduleOne.Core;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar.Tools;
[RequireComponent(typeof(AvatarAppearance))]
public class OutfitLoader : MonoBehaviour
{
    [SerializeField]
    private Outfit _outfit;
    [SerializeField]
    private bool _loadOnStart;
    private void Start();
    [Button]
    public void Load();
    public void Load(Outfit outfit);
}