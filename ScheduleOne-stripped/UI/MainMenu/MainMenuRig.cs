using System.Collections.Generic;
using System.IO;
using System.Linq;
using ScheduleOne.Avatar.Player;
using ScheduleOne.Avatar.Tools;
using ScheduleOne.AvatarFramework;
using ScheduleOne.AvatarFramework.Customization;
using ScheduleOne.Clothing;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI.MainMenu;
public class MainMenuRig : MonoBehaviour
{
    private const string DanceAnimationBool;
    private const float DanceChance;
    public ScheduleOne.AvatarFramework.Avatar Avatar;
    public BasicAvatarSettings DefaultSettings;
    public CashPile[] CashPiles;
    public void Awake();
    private void LoadStuff();
}