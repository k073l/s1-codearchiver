using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class GameplayMenuInterface : Singleton<GameplayMenuInterface>
{
    public Canvas Canvas;
    public Button PhoneButton;
    public Button CharacterButton;
    public RectTransform SelectionIndicator;
    public CharacterInterface CharacterInterface;
    public GameplayMenuTab Tab;
    public CanvasGroup TabPromptsCanvasGroup;
    private Coroutine selectionLerp;
    protected override void Awake();
    protected override void Start();
    private void Update();
    public void Open();
    public void Close();
    public void PhoneClicked();
    public void CharacterClicked();
    public void SetSelected(GameplayMenu.EGameplayScreen screen);
}