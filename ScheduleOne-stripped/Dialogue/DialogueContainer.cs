using System;
using System.Collections.Generic;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Dialogue;
[Serializable]
public class DialogueContainer : ScriptableObject
{
    public List<NodeLinkData> NodeLinks;
    public List<DialogueNodeData> DialogueNodeData;
    public List<BranchNodeData> BranchNodeData;
    public bool allowExit { get; private set; } = true;
    public bool AllowExit { get; }

    public DialogueNodeData GetDialogueNodeByLabel(string dialogueNodeLabel);
    public BranchNodeData GetBranchNodeByLabel(string branchLabel);
    public DialogueNodeData GetDialogueNodeByGUID(string dialogueNodeGUID);
    public BranchNodeData GetBranchNodeByGUID(string branchGUID);
    public NodeLinkData GetLink(string baseChoiceOrOptionGUID);
    public void SetAllowExit(bool allowed);
}