using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Map;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.UI.Phone.Map;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.ContactsApp;
public class ContactsDetailPanel : MonoBehaviour
{
    [Header("Settings")]
    public Color DependenceColor_Min;
    public Color DependenceColor_Max;
    [Header("References")]
    public Text NameLabel;
    public Text TypeLabel;
    public Text UnlockHintLabel;
    public RectTransform RelationshipContainer;
    public Scrollbar RelationshipScrollbar;
    public Text RelationshipLabel;
    public RectTransform AddictionContainer;
    public Scrollbar AddictionScrollbar;
    public Text AddictionLabel;
    public RectTransform DebtContainer;
    public Text DebtLabel;
    public RectTransform PropertiesContainer;
    public Text PropertiesLabel;
    public RectTransform MostPurchasedProductsContainer;
    public Text MostPurchasedProductsLabel;
    public RectTransform TotalSpentContainer;
    public Text TotalSpentLabel;
    public Button ShowOnMapButton;
    public RectTransform StandardsContainer;
    public Image StandardsStar;
    public Text StandardsLabel;
    [Header("Fonts")]
    [SerializeField]
    private ColorFont _generalColorFont;
    [SerializeField]
    private ColorFont _proudctColorFont;
    private POI poi;
    private const int MAX_PURCHASED_PRODUCTS_DISPLAYED;
    public NPC SelectedNPC { get; protected set; }

    public void Open(NPC npc);
    public void ShowOnMap();
}