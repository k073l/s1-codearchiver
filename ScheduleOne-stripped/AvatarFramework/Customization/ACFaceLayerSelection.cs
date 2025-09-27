using UnityEngine;

namespace ScheduleOne.AvatarFramework.Customization;
public class ACFaceLayerSelection : ACSelection<FaceLayer>
{
    public override string GetOptionLabel(int index);
    public override void CallValueChange();
    public override int GetAssetPathIndex(string path);
}