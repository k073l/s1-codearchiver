using System;
using Steamworks;
using UnityEngine;

namespace ScheduleOne;
public static class OnScreenKeyboard
{
    private static uint s_charLimit;
    private static Action<string> s_onSubmit;
    private static Action s_onCancel;
    private static Callback<GamepadTextInputDismissed_t> s_onGamepadTextInputDismissed;
    public static void Show(Action<string> onSubmit, Action onCancel = null, string description = "", uint charMax = 32u, string defaultText = "");
    private static void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t param);
}