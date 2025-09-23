using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Storage;
public class PalletZone : MonoBehaviour
{
    private List<Pallet> pallets;
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject palletPrefab;
    private bool orderReceivedThisFrame;
    public bool isClear { get; }

    protected void OnTriggerStay(Collider other);
    protected void FixedUpdate();
    protected void LateUpdate();
    public Pallet GeneratePallet();
    private bool AreAllPalletsClear();
}