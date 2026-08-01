using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.CustomUI;
public class UICycler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private TabController _tabController;
    private int _currentIndex;
    public void Update();
}