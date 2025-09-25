using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Datas;

namespace ScheduleOne.Persistence;
public interface IGenericSaveable
{
    Guid GUID { get; }

    void InitializeSaveable();
    void Load(GenericSaveData data);
    GenericSaveData GetSaveData();
}