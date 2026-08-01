using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.ProductManagerApp;
public class ProductTypeContainer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private EDrugType _drugType;
    [SerializeField]
    private RectTransform _enteries;
    [SerializeField]
    private RectTransform _noneDisplay;
    [SerializeField]
    private RectTransform _dropDownIndicator;
    [SerializeField]
    private Button _dropDownButton;
    private bool _isExpanded;
    public EDrugType DrugType => _drugType;
    public RectTransform Enteries => _enteries;

    private void Start();
    public void RefreshNoneDisplay();
    public void SetDropdown(bool isExpanded);
}