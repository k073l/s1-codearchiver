using System.Collections.Generic;
using FishNet.Connection;
using ScheduleOne.Persistence.Datas;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Management;
public class EntityConfiguration
{
    private const int NameCharacterLimit;
    public List<ConfigField> Fields;
    public UnityEvent onChanged;
    public ConfigurationReplicator Replicator { get; protected set; }
    public IConfigurable Configurable { get; protected set; }
    public bool IsSelected { get; protected set; }
    public StringField Name { get; private set; }

    public virtual bool AllowRename();
    public EntityConfiguration(ConfigurationReplicator replicator, IConfigurable configurable, string defaultName);
    protected void InvokeChanged();
    public void ReplicateField(ConfigField field, NetworkConnection conn = null);
    public void ReplicateAllFields(NetworkConnection conn = null, bool replicateDefaults = true);
    public virtual void Destroy();
    public virtual void Reset();
    public virtual void Selected();
    public virtual void Deselected();
    public virtual bool ShouldSave();
    public virtual string GetSaveString();
    public T GetField<T>()
        where T : ConfigField;
}