using System.Linq;
using ScheduleOne.Cutscenes;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.Levelling;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;

namespace ScheduleOne.SpecialCustomers.UI;
public class SpecialCustomersArrivalCutsceneInfoPopup : MonoBehaviour
{
    [SerializeField]
    private Animation _anim;
    [SerializeField]
    private AnimationClip _openClip;
    [SerializeField]
    private AnimationClip _closeClip;
    [SerializeField]
    private TextMeshProUGUI[] _drugTypeLabels;
    [SerializeField]
    private TextMeshProUGUI[] _bonusEffectLabels;
    [SerializeField]
    private TextMeshProUGUI _buyQuantityLabel;
    private void Awake();
    private void Start();
    private void OnDestroy();
    private void OnCutsceneStarted(Cutscene cutscene);
    private void OnCutsceneEnded(Cutscene cutscene);
    public void Open(EDrugType[] drugTypes, Effect[] bonusEffects, int buyQuantity);
    public void Close();
}