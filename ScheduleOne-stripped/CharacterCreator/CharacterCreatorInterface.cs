using System;
using ScheduleOne.Avatar;
using ScheduleOne.Clothing;
using ScheduleOne.Core.Avatar;
using ScheduleOne.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ScheduleOne.CharacterCreator;
public class CharacterCreatorInterface : MonoBehaviour
{
    [Serializable]
    public class Window
    {
        public string Name;
        public RectTransform Container;
        public UIPanel Panel;
        public void Open();
        public void Close();
    }

    [SerializeField]
    private CharacterCreator _characterCreator;
    [Header("References")]
    [SerializeField]
    private Canvas _canvas;
    [SerializeField]
    private Animation _canvasAnimation;
    [SerializeField]
    [FormerlySerializedAs("Windows")]
    private Window[] _windows;
    [SerializeField]
    private TextMeshProUGUI _categoryLabel;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _doneButton;
    [SerializeField]
    private Slider _avatarRotationSlider;
    [Header("Body")]
    [SerializeField]
    private Toggle _maleButton;
    [SerializeField]
    private Toggle _femaleButton;
    [SerializeField]
    private Slider _weightSlider;
    [SerializeField]
    private CharacterCreatorColorSelector _skinColorSelector;
    [Header("Hair")]
    [SerializeField]
    private CharacterCreatorAvatarObjectSelector _hairSelector;
    [SerializeField]
    private CharacterCreatorColorSelector _hairColorSelector;
    [Header("Face")]
    [SerializeField]
    private CharacterCreatorAvatarObjectSelector _faceSelector;
    [SerializeField]
    private CharacterCreatorAvatarObjectSelector _facialHairSelector;
    [SerializeField]
    private CharacterCreatorAvatarObjectSelector _facialDetailSelector;
    [SerializeField]
    private Slider _facialDetailIntensitySelector;
    [Header("Eyes")]
    [SerializeField]
    private CharacterCreatorColorSelector _eyeballColorSelector;
    [SerializeField]
    private Slider _pupilDilationSlider;
    [Header("Eyelids")]
    [SerializeField]
    private Slider _upperEyelidPositionSlider;
    [SerializeField]
    private Slider _lowerEyelidPositionSlider;
    [Header("Eyebrows")]
    [SerializeField]
    private Slider _eyebrowScaleSlider;
    [SerializeField]
    private Slider _eyebrowThicknessSlider;
    [SerializeField]
    private Slider _eyebrowHeightSlider;
    [SerializeField]
    private Slider _eyebrowAngleSlider;
    [Header("Clothing")]
    [SerializeField]
    private CharacterCreatorClothingSelector _topSelector;
    [SerializeField]
    private CharacterCreatorColorSelector _topColorSelector;
    [SerializeField]
    private CharacterCreatorClothingSelector _bottomSelector;
    [SerializeField]
    private CharacterCreatorColorSelector _bottomColorSelector;
    [SerializeField]
    private CharacterCreatorClothingSelector _shoesSelector;
    [SerializeField]
    private CharacterCreatorColorSelector _shoesColorSelector;
    [Header("UI")]
    [SerializeField]
    private CyclerController _cyclerController;
    [SerializeField]
    private UIScreen _screen;
    private int _openWindowIndex;
    private Window _openWindow;
    private void Awake();
    private void BindInputs();
    private void SetInputsToAppearance(CharacterCreatorState state);
    private void OnGenderToggle();
    private void SetGenderToggle(EGender gender);
    public void Open(CharacterCreatorState _startingAppearance);
    public void Close();
    private void OpenWindow(int index);
    private void HandleCycleEvent(int dir);
    private void Back();
    private void Next();
}