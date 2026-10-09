using UnityEngine;

namespace ScheduleOne.Weather;
[CreateAssetMenu(fileName = "MaskMapModificationData", menuName = "ScriptableObjects/Weather/Mask Map Modification")]
public class MaskModificationData : ScriptableObject
{
    [SerializeField]
    public Vector2 StartIndex;
    [SerializeField]
    public Vector2 Size;
    [SerializeField]
    public int initialState;
    [SerializeField]
    public Texture2D Texture;
    public MaskModificationDataGPU ToGPUData();
}