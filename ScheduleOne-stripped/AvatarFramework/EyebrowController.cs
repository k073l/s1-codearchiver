using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.AvatarFramework;
public class EyebrowController : MonoBehaviour
{
    [Header("References")]
    public Eyebrow leftBrow;
    public Eyebrow rightBrow;
    public void ApplySettings(AvatarSettings settings);
    public void ApplySettings(EyebrowSettings leftSettings, EyebrowSettings rightSettings);
    public void SetLeftBrowRestingHeight(float normalizedHeight);
    public void SetRightBrowRestingHeight(float normalizedHeight);
}