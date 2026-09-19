using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public class AvatarAttachmentAlignmentHelper : MonoBehaviour
{
    private const string HelperAvatarPrefabPath;
    private AvatarAttachment _attachment;
    private GameObject _helperAvatarInstance;
    private IAttachmentAnchorProvider _anchorProvider;
    [Button("Show Helper", "!_helperAvatarInstance")]
    public void ShowHelper();
    private void OnValidate();
    [Button("Hide Helper", "_helperAvatarInstance")]
    public void HideHelper();
    private void RefreshHelperAlignment();
}