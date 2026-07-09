using System;
using ScheduleOne.DevUtilities;
using Steamworks;
using UnityEngine;

namespace ScheduleOne;
public static class OnScreenKeyboard
{
    public const float ExitCooldown;
    private static uint s_charLimit;
    private static Action<string> s_onSubmit;
    private static Action s_onCancel;
    private static Callback<GamepadTextInputDismissed_t> s_onGamepadTextInputDismissed;
    public static bool IsOpen { get; private set; } = false;
    public static float TimeOnLastClose { get; private set; } = -1f;

    public static void Show(Action<string> onSubmit, Action onCancel = null, string description = "", uint charMax = 32u, string defaultText = "");
    private static void Exit(ExitAction exit);
    public static void Hide();
    private static void OnGamepadTextInputDismissed(GamepadTextInputDismissed_t param);
    private static void OnHide();
    public static bool IsOSKAvailable();
}