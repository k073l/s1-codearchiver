using System.Collections.Generic;
using FishNet.Object;
using ScheduleOne.PlayerScripts;

namespace ScheduleOne.Casino;
public class CasinoGamePlayerData
{
    protected Dictionary<string, bool> bools;
    protected Dictionary<string, float> floats;
    public CasinoGamePlayers Parent { get; private set; }
    public Player Player { get; private set; }

    public CasinoGamePlayerData(CasinoGamePlayers parent, Player player);
    public T GetData<T>(string key);
    public void SetData<T>(string key, T value, bool network = true);
}