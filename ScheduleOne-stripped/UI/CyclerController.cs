using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CyclerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Text _label;
    [SerializeField]
    private List<CyclerItemUI> _items;
    [Header("Settings")]
    [SerializeField]
    private bool _allowLoopingNavigation;
    [Header("UI")]
    [SerializeField]
    private UIScreen _screen;
    private int _currentItemIndex;
    private CyclerEvent _onCycleItem;
    private bool _wasTriggeredLastFrame;
    private float _triggerTimer;
    public int CurrentItemIndex => _currentItemIndex;

    private void Update();
    private void CycleItem(int dir);
    private void SetItem(int index);
    public void SetToSelectedItem(bool instantIndicatorMove = false);
    public void SetItem(int index, bool instantIndicatorMove = false, bool forceUpdateUI = false);
    public void SetLabel(string text);
    private int GetLoopedIndex(int dir);
    private int GetClampedIndex(int dir);
    public void SubscribeToCyclerEvent(CyclerEvent handler);
    public void UnsubscribeFromCyclerEvent(CyclerEvent handler);
}