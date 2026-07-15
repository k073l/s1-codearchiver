using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
[Serializable]
public class DialogueChoiceEntry
{
    public GameObject GameObject;
    public TextMeshProUGUI Label { get; private set; }
    public TextMeshProUGUI InputLabel { get; private set; }
    public Button Button { get; private set; }
    public GameObject NotPossibleGameObject { get; private set; }
    public TextMeshProUGUI NotPossibleText { get; private set; }
    public CanvasGroup CanvasGroup { get; private set; }
    public UISelectable UISelectable { get; private set; }

    public void Init();
}