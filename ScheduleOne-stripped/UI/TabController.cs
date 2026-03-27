using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class TabController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private RectTransform _tabIndicator;
    [SerializeField]
    private List<TabItemUI> _tabItems;
    [Header("Settings")]
    [SerializeField]
    private float _indicatorMoveTime;
    [SerializeField]
    private AnimationCurve _indicatorMoveCurve;
    [Header("Fonts")]
    [SerializeField]
    private ColorFont _tabColorFont;
    private int _currentTabIndex;
    private Vector2 _indicatorPosition;
    private Coroutine _moveIndicatorCo;
    private TabSelectedEvent _onTabSelected;
    public int CurrentTabIndex => _currentTabIndex;

    public void Start();
    private void SetTab(int index);
    public void SetToSelectedTab(bool instantIndicatorMove = false);
    public void SetTab(int index, bool instantIndicatorMove = false);
    private IEnumerator DoMoveTabIndicatorRoutine();
    public void SetTabIndicatorText(int index, string text);
    public void HideTabIndicator(int index);
    public void SubscribeToTabSelected(TabSelectedEvent handler);
    public void UnsubscribeFromTabSelected(TabSelectedEvent handler);
    private IEnumerator DoDelayRoutine(float delay, Action onComplete);
}