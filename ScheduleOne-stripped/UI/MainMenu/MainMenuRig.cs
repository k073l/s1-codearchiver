using System.IO;
using ScheduleOne.AvatarFramework;
using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence;
using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.MainMenu;
public class MainMenuRig : MonoBehaviour
{
    public Avatar Avatar;
    public BasicAvatarSettings DefaultSettings;
    public CashPile[] CashPiles;
    public void Awake();
    private void LoadStuff();
}