using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.ObjectScripts;
public class BrickPressContainer : MonoBehaviour
{
    public MultiTypeVisualsSetter Visuals;
    public Transform ContentsContainer;
    public Transform Contents_Min;
    public Transform Contents_Max;
    public void SetContents(ProductItemInstance product, float fillLevel);
}