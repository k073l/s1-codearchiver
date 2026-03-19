using System.Collections.Generic;
using ScheduleOne.Core;
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
    [Header("Finding Shaders")]
    [SerializeField]
    private Transform _rootObject;
    [SerializeField]
    private bool _showCountOnly;
    [Button]
    public void ScanSceneForShaders();
    [Button]
    public void AddAffinityAndRandomise();
    [Button]
    public void RemoveAffinity();
}