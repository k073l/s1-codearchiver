using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using ScheduleOne.Cutscenes;
using ScheduleOne.DevUtilities;
using ScheduleOne.Employees;
using ScheduleOne.GamePhysics;
using ScheduleOne.GameTime;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Law;
using ScheduleOne.Levelling;
using ScheduleOne.Map;
using ScheduleOne.Money;
using ScheduleOne.NPCs;
using ScheduleOne.NPCs.Relation;
using ScheduleOne.Persistence;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Product.Packaging;
using ScheduleOne.Property;
using ScheduleOne.Quests;
using ScheduleOne.Trash;
using ScheduleOne.UI;
using ScheduleOne.Variables;
using ScheduleOne.Vehicles;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne;
public class Console : Singleton<Console>
{
    public abstract class ConsoleCommand
    {
        public abstract string CommandWord { get; }
        public abstract string CommandDescription { get; }
        public abstract string ExampleUsage { get; }

        public abstract void Execute(List<string> args);
    }

    public class SetTimeCommand : ConsoleCommand
    {
        public override string CommandWord => "settime";
        public override string CommandDescription => "Sets the time of day to the specified 24-hour time";
        public override string ExampleUsage => "settime 1530";

        public override void Execute(List<string> args);
    }

    public class SpawnVehicleCommand : ConsoleCommand
    {
        public override string CommandWord => "spawnvehicle";
        public override string CommandDescription => "Spawns a vehicle at the player's location";
        public override string ExampleUsage => "spawnvehicle shitbox";

        public override void Execute(List<string> args);
    }

    public class AddItemToInventoryCommand : ConsoleCommand
    {
        public override string CommandWord => "give";
        public override string CommandDescription => "Gives the player the specified item. Optionally specify a quantity.";
        public override string ExampleUsage => "give ogkush 5";

        public override void Execute(List<string> args);
    }

    public class ClearInventoryCommand : ConsoleCommand
    {
        public override string CommandWord => "clearinventory";
        public override string CommandDescription => "Clears the player's inventory";
        public override string ExampleUsage => "clearinventory";

        public override void Execute(List<string> args);
    }

    public class ChangeCashCommand : ConsoleCommand
    {
        public override string CommandWord => "changecash";
        public override string CommandDescription => "Changes the player's cash balance by the specified amount";
        public override string ExampleUsage => "changecash 5000";

        public override void Execute(List<string> args);
    }

    public class ChangeOnlineBalanceCommand : ConsoleCommand
    {
        public override string CommandWord => "changebalance";
        public override string CommandDescription => "Changes the player's online balance by the specified amount";
        public override string ExampleUsage => "changebalance 5000";

        public override void Execute(List<string> args);
    }

    public class SetMoveSpeedCommand : ConsoleCommand
    {
        public override string CommandWord => "setmovespeed";
        public override string CommandDescription => "Sets the player's move speed multiplier";
        public override string ExampleUsage => "setmovespeed 1";

        public override void Execute(List<string> args);
    }

    public class SetJumpMultiplier : ConsoleCommand
    {
        public override string CommandWord => "setjumpforce";
        public override string CommandDescription => "Sets the player's jump force multiplier";
        public override string ExampleUsage => "setjumpforce 1";

        public override void Execute(List<string> args);
    }

    public class SetPropertyOwned : ConsoleCommand
    {
        public override string CommandWord => "setowned";
        public override string CommandDescription => "Sets the specified property or business as owned";
        public override string ExampleUsage => "setowned barn, setowned laundromat";

        public override void Execute(List<string> args);
    }

    public class Teleport : ConsoleCommand
    {
        public override string CommandWord => "teleport";
        public override string CommandDescription => "Teleports the player to the specified location, property, or NPC.";
        public override string ExampleUsage => "teleport townhall, teleport barn, teleport jessi_waters";

        public override void Execute(List<string> args);
    }

    public class PackageProduct : ConsoleCommand
    {
        public override string CommandWord => "packageprodcut";
        public override string CommandDescription => "Packages the equipped product with the specified packaging";
        public override string ExampleUsage => "packageproduct jar, packageproduct baggie";

        public override void Execute(List<string> args);
    }

    public class SetStaminaReserve : ConsoleCommand
    {
        public override string CommandWord => "setstaminareserve";
        public override string CommandDescription => "Sets the player's stamina reserve (default 100) to the specified amount.";
        public override string ExampleUsage => "setstaminareserve 200";

        public override void Execute(List<string> args);
    }

    public class RaisedWanted : ConsoleCommand
    {
        public override string CommandWord => "raisewanted";
        public override string CommandDescription => "Raises the player's wanted level";
        public override string ExampleUsage => "raisewanted";

        public override void Execute(List<string> args);
    }

    public class LowerWanted : ConsoleCommand
    {
        public override string CommandWord => "lowerwanted";
        public override string CommandDescription => "Lowers the player's wanted level";
        public override string ExampleUsage => "lowerwanted";

        public override void Execute(List<string> args);
    }

    public class ClearWanted : ConsoleCommand
    {
        public override string CommandWord => "clearwanted";
        public override string CommandDescription => "Clears the player's wanted level";
        public override string ExampleUsage => "clearwanted";

        public override void Execute(List<string> args);
    }

    public class SetHealth : ConsoleCommand
    {
        public override string CommandWord => "sethealth";
        public override string CommandDescription => "Sets the player's health to the specified amount";
        public override string ExampleUsage => "sethealth 100";

        public override void Execute(List<string> args);
    }

    public class SetEnergy : ConsoleCommand
    {
        public override string CommandWord => "setenergy";
        public override string CommandDescription => "Sets the player's energy to the specified amount";
        public override string ExampleUsage => "setenergy 100";

        public override void Execute(List<string> args);
    }

    public class FreeCamCommand : ConsoleCommand
    {
        public override string CommandWord => "freecam";
        public override string CommandDescription => "Toggles free cam mode";
        public override string ExampleUsage => "freecam";

        public override void Execute(List<string> args);
    }

    public class Save : ConsoleCommand
    {
        public override string CommandWord => "save";
        public override string CommandDescription => "Forces a save";
        public override string ExampleUsage => "save";

        public override void Execute(List<string> args);
    }

    public class SetTimeScale : ConsoleCommand
    {
        public override string CommandWord => "settimescale";
        public override string CommandDescription => "Sets the time scale. Default 1";
        public override string ExampleUsage => "settimescale 1";

        public override void Execute(List<string> args);
    }

    public class SetVariableValue : ConsoleCommand
    {
        public override string CommandWord => "setvar";
        public override string CommandDescription => "Sets the value of the specified variable";
        public override string ExampleUsage => "setvar <variable> <value>";

        public override void Execute(List<string> args);
    }

    public class SetQuestState : ConsoleCommand
    {
        public override string CommandWord => "setqueststate";
        public override string CommandDescription => "Sets the state of the specified quest";
        public override string ExampleUsage => "setqueststate <quest name> <state>";

        public override void Execute(List<string> args);
    }

    public class SetQuestEntryState : ConsoleCommand
    {
        public override string CommandWord => "setquestentrystate";
        public override string CommandDescription => "Sets the state of the specified quest entry";
        public override string ExampleUsage => "setquestentrystate <quest name> <entry index> <state>";

        public override void Execute(List<string> args);
    }

    public class SetEmotion : ConsoleCommand
    {
        public override string CommandWord => "setemotion";
        public override string CommandDescription => "Sets the facial expression of the player's avatar.";
        public override string ExampleUsage => "setemotion cheery";

        public override void Execute(List<string> args);
    }

    public class SetUnlocked : ConsoleCommand
    {
        public override string CommandWord => "setunlocked";
        public override string CommandDescription => "Unlocks the given NPC";
        public override string ExampleUsage => "setunlocked <npc_id>";

        public override void Execute(List<string> args);
    }

    public class SetRelationship : ConsoleCommand
    {
        public override string CommandWord => "setrelationship";
        public override string CommandDescription => "Sets the relationship scalar of the given NPC. Range is 0-5.";
        public override string ExampleUsage => "setrelationship <npc_id> 5";

        public override void Execute(List<string> args);
    }

    public class AddEmployeeCommand : ConsoleCommand
    {
        public override string CommandWord => "addemployee";
        public override string CommandDescription => "Adds an employee of the specified type to the given property.";
        public override string ExampleUsage => "addemployee botanist barn";

        public override void Execute(List<string> args);
    }

    public class SetDiscovered : ConsoleCommand
    {
        public override string CommandWord => "setdiscovered";
        public override string CommandDescription => "Sets the specified product as discovered";
        public override string ExampleUsage => "setdiscovered ogkush";

        public override void Execute(List<string> args);
    }

    public class GrowPlants : ConsoleCommand
    {
        public override string CommandWord => "growplants";
        public override string CommandDescription => "Sets ALL plants in the world fully grown";
        public override string ExampleUsage => "growplants";

        public override void Execute(List<string> args);
    }

    public class SetLawIntensity : ConsoleCommand
    {
        public override string CommandWord => "setlawintensity";
        public override string CommandDescription => "Sets the intensity of law enforcement activity on a scale of 0-10.";
        public override string ExampleUsage => "setlawintensity 6";

        public override void Execute(List<string> args);
    }

    public class SetQuality : ConsoleCommand
    {
        public override string CommandWord => "setquality";
        public override string CommandDescription => "Sets the quality of the currently equipped item.";
        public override string ExampleUsage => "setquality standard, setquality heavenly";

        public override void Execute(List<string> args);
    }

    public class Bind : ConsoleCommand
    {
        public override string CommandWord => "bind";
        public override string CommandDescription => "Binds the given key to the given command.";
        public override string ExampleUsage => "bind t 'settime 1200'";

        public override void Execute(List<string> args);
    }

    public class Unbind : ConsoleCommand
    {
        public override string CommandWord => "unbind";
        public override string CommandDescription => "Removes the given bind.";
        public override string ExampleUsage => "unbind t";

        public override void Execute(List<string> args);
    }

    public class ClearBinds : ConsoleCommand
    {
        public override string CommandWord => "clearbinds";
        public override string CommandDescription => "Clears ALL binds.";
        public override string ExampleUsage => "clearbinds";

        public override void Execute(List<string> args);
    }

    public class HideUI : ConsoleCommand
    {
        public override string CommandWord => "hideui";
        public override string CommandDescription => "Hides all on-screen UI.";
        public override string ExampleUsage => "hideui";

        public override void Execute(List<string> args);
    }

    public class GiveXP : ConsoleCommand
    {
        public override string CommandWord => "addxp";
        public override string CommandDescription => "Adds the specified amount of experience points.";
        public override string ExampleUsage => "addxp 100";

        public override void Execute(List<string> args);
    }

    public class Disable : ConsoleCommand
    {
        public override string CommandWord => "disable";
        public override string CommandDescription => "Disables the specified GameObject";
        public override string ExampleUsage => "disable pp";

        public override void Execute(List<string> args);
    }

    public class Enable : ConsoleCommand
    {
        public override string CommandWord => "enable";
        public override string CommandDescription => "Enables the specified GameObject";
        public override string ExampleUsage => "enable pp";

        public override void Execute(List<string> args);
    }

    public class EndTutorial : ConsoleCommand
    {
        public override string CommandWord => "endtutorial";
        public override string CommandDescription => "Forces the tutorial to end immediately (only if the player is actually in the tutorial).";
        public override string ExampleUsage => "endtutorial";

        public override void Execute(List<string> args);
    }

    public class DisableNPCAsset : ConsoleCommand
    {
        public override string CommandWord => "disablenpcasset";
        public override string CommandDescription => "Disabled the given asset under all NPCs";
        public override string ExampleUsage => "disablenpcasset avatar";

        public override void Execute(List<string> args);
    }

    public class ShowFPS : ConsoleCommand
    {
        public override string CommandWord => "showfps";
        public override string CommandDescription => "Shows FPS label.";
        public override string ExampleUsage => "showfps";

        public override void Execute(List<string> args);
    }

    public class HideFPS : ConsoleCommand
    {
        public override string CommandWord => "hidefps";
        public override string CommandDescription => "Hides FPS label.";
        public override string ExampleUsage => "hidefps";

        public override void Execute(List<string> args);
    }

    public class ClearTrash : ConsoleCommand
    {
        public override string CommandWord => "cleartrash";
        public override string CommandDescription => "Instantly removes all trash from the world.";
        public override string ExampleUsage => "cleartrash";

        public override void Execute(List<string> args);
    }

    public class PlayCutscene : ConsoleCommand
    {
        public override string CommandWord => "playcutscene";
        public override string CommandDescription => "Plays the cutscene with the given name";
        public override string ExampleUsage => "playcutscene Tutorial end";

        public override void Execute(List<string> args);
    }

    public class SetGravityMultiplier : ConsoleCommand
    {
        public override string CommandWord => "setgravitymultiplier";
        public override string CommandDescription => "Sets the multiplier of the gravity strength.";
        public override string ExampleUsage => "setgravitymultiplier 0.5";

        public override void Execute(List<string> args);
    }

    public class SetRegionUnlocked : ConsoleCommand
    {
        public override string CommandWord => "setregionunlocked";
        public override string CommandDescription => "Unlocks the given region";
        public override string ExampleUsage => "setregionunlocked downtown";

        public override void Execute(List<string> args);
    }

    public class ForceSleep : ConsoleCommand
    {
        public override string CommandWord => "forcesleep";
        public override string CommandDescription => "Forces all players to immediately sleep.";
        public override string ExampleUsage => "forcesleep";

        public override void Execute(List<string> args);
    }

    public class DestroyNPCs : ConsoleCommand
    {
        public override string CommandWord => "destroynpcs";
        public override string CommandDescription => "Destroys all NPCs in the scene, including employees and dealers.";
        public override string ExampleUsage => "destroynpcs";

        public override void Execute(List<string> args);
    }

    public class SetDayDuration : ConsoleCommand
    {
        public override string CommandWord => "setdayduration";
        public override string CommandDescription => "Sets the (real life) duration of an in-game 24-hour cycle. Measured in real minutes.";
        public override string ExampleUsage => "setdayduration 24";

        public override void Execute(List<string> args);
    }

    [Serializable]
    public class LabelledGameObject
    {
        public string Label;
        public GameObject GameObject;
    }

    public Transform TeleportPointsContainer;
    public List<LabelledGameObject> LabelledGameObjectList;
    [Tooltip("Commands that run on startup (Editor only)")]
    public List<string> startupCommands;
    public static List<ConsoleCommand> Commands;
    private static Dictionary<string, ConsoleCommand> commands;
    private Dictionary<KeyCode, string> keyBindings;
    private static Player player => Player.Local;

    private static void LogCommandError(string error);
    private static void LogUnrecognizedFormat(string[] correctExamples);
    protected override void Awake();
    private void RunStartupCommands();
    [HideInCallstack]
    public static void Log(object message, Object context = null);
    [HideInCallstack]
    public static void LogWarning(object message, Object context = null);
    [HideInCallstack]
    public static void LogError(object message, Object context = null);
    public static void SubmitCommand(List<string> args);
    public static void SubmitCommand(string args);
    public unsafe void AddBinding(KeyCode key, string command);
    public unsafe void RemoveBinding(KeyCode key);
    public void ClearBindings();
    private void Update();
}