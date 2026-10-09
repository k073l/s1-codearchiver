using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Persistence;
public class LoadRequest
{
    public string Path;
    public Loader Loader;
    public Action OnComplete;
    public bool IsDone { get; private set; }

    public LoadRequest(string filePath, Loader loader);
    public void Complete();
}