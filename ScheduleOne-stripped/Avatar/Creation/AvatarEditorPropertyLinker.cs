namespace ScheduleOne.Avatar.Creation;
public abstract class AvatarEditorPropertyLinker<T> : AvatarEditorInputLinkerBase
{
    public override void SetLinkStateIfValuesMatch();
    protected abstract T GetSourceValue();
    protected abstract T GetTargetValue();
    protected abstract bool AreValuesEqual(T value1, T value2);
    protected abstract void SetTargetValue(T value, bool notify);
    protected override void SetTargetValueToSourceValue(bool notify);
}