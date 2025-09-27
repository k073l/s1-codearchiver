using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Casino.UI;
public class CasinoGamePlayerDisplay : MonoBehaviour
{
    public CasinoGamePlayers BindedPlayers;
    [Header("References")]
    public TextMeshProUGUI TitleLabel;
    public RectTransform[] PlayerEntries;
    public void RefreshPlayers();
    public void RefreshScores();
    public void Bind(CasinoGamePlayers players);
    public void Unbind();
}