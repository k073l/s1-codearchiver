using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ScheduleOne.Persistence.Loaders;
public class Loader
{
    public virtual void Load(string mainPath);
    public bool TryLoadFile(string parentPath, string fileName, out string contents);
    public bool TryLoadFile(string path, out string contents, bool autoAddExtension = true);
    protected List<DirectoryInfo> GetDirectories(string parentPath);
    protected List<FileInfo> GetFiles(string parenPath);
    public static bool TryDeserialize<T>(string json, out T data);
}