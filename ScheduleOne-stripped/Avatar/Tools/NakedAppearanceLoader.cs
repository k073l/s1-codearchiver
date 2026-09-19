using ScheduleOne.Core;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar.Tools;
[RequireComponent(typeof(AvatarAppearance))]
public class NakedAppearanceLoader : MonoBehaviour
{
    [SerializeField]
    private NakedAppearanceObject _appearance;
    [SerializeField]
    private bool _loadOnStart;
    private void Start();
    [Button]
    public void Load();
    public void Load(NakedAppearanceObject appearance);
}