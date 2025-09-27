using System;
using System.Collections.Generic;
using System.IO;
using ScheduleOne.DevUtilities;
using ScheduleOne.Persistence.Loaders;

namespace ScheduleOne.Persistence;
public interface ISaveable
{
    string SaveFolderName { get; }

    string SaveFileName { get; }

    Loader Loader { get; }

    bool ShouldSaveUnderFolder { get; }

    List<string> LocalExtraFiles { get; set; }

    List<string> LocalExtraFolders { get; set; }

    bool HasChanged { get; set; }

    void InitializeSaveable();
    string GetSaveString();
    string Save(string parentFolderPath);
    void WriteBaseData(string parentFolderPath, string saveString);
    string GetLocalPath(out bool isFolder);
    void CompleteSave(string parentFolderPath, bool writeDataFile);
    List<string> WriteData(string parentFolderPath);
    void DeleteUnapprovedFiles(string parentFolderPath);
    string GetContainerFolder(string parentFolderPath);
    string WriteSubfile(string parentPath, string localPath_NoExtensions, string contents);
    string WriteFolder(string parentPath, string localPath_NoExtensions);
    bool TryLoadFile(string parentPath, string fileName, out string contents);
    bool TryLoadFile(string path, out string contents, bool autoAddExtension = true);
}