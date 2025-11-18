using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Product;
public class NewMixDiscoveryBox : MonoBehaviour
{
    private bool isOpen;
    [Header("References")]
    public Transform CameraPosition;
    public TextMeshPro PropertiesText;
    public Animation Animation;
    public InteractableObject IntObj;
    public Transform Lid;
    public MultiTypeVisualsSetter Visuals;
    private Pose closedLidPose;
    private NewMixOperation currentMix;
    public void Start();
    public void ShowProduct(ProductDefinition baseDefinition, List<Effect> properties);
    private void CloseCase();
    private void OpenCase();
    private void Interacted();
}