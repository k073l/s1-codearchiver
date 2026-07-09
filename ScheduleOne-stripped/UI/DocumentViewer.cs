using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.UI;
public class DocumentViewer : Singleton<DocumentViewer>
{
    [Header("References")]
    public Canvas Canvas;
    public DocumentViewerPage[] Documents;
    public MonoState State;
    public UnityEvent onOpen;
    public bool IsOpen { get; protected set; }

    protected override void Start();
    public void Open(string documentName);
    public void Close();
    private void OnClose();
}