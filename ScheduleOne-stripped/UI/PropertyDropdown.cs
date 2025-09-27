using System;
using System.Collections.Generic;
using ScheduleOne.Property;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class PropertyDropdown : MonoBehaviour
{
    public ScheduleOne.Property.Property selectedProperty;
    private TMP_Dropdown TMP_dropdown;
    private Dropdown dropdown;
    private Dictionary<int, ScheduleOne.Property.Property> intToProperty;
    public Action onSelectionChanged;
    protected virtual void Awake();
    private void PropertyAcquired(ScheduleOne.Property.Property p);
    private void ValueChanged(int newVal);
}