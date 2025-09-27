using UnityEngine;

namespace ScheduleOne.Tools;
public class CashPile : MonoBehaviour
{
    public const float MAX_AMOUNT;
    public Transform Container;
    private Transform[] CashInstances;
    private void Awake();
    public void SetDisplayedAmount(float amount);
}