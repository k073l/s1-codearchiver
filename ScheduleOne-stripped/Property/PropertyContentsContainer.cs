using UnityEngine;

namespace ScheduleOne.Property;
public class PropertyContentsContainer : MonoBehaviour
{
    public Property Property { get; private set; }

    public void SetProperty(Property property);
}