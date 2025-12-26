using System.Collections.Generic;
using EasyButtons;
using ScheduleOne.Economy;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class SceneUtility : MonoBehaviour
{
    [Header("Afinity Settings")]
    public EDrugType DrugAffinityToAdd;
    public Vector2 MinMaxAffinityRange;
    public bool UseCurrentHighestAffinityAsMax;
    [Header("Objects to Modify")]
    public List<Transform> SceneObjects;
    [Button]
    public void AddAffinityAndRandomise();
    [Button]
    public void RemoveAffinity();
}