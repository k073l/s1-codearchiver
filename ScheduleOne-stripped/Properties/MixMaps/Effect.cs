using UnityEngine;

namespace ScheduleOne.Properties.MixMaps;
public class Effect : MonoBehaviour
{
    public Property Property;
    [Range(0.05f, 3f)]
    public float Radius;
    public Vector2 Position => new Vector2(((Component)this).transform.position.x, ((Component)this).transform.position.z);

    public void OnValidate();
}