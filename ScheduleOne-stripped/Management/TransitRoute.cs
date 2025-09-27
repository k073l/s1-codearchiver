using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.Management;
public class TransitRoute
{
    protected TransitLineVisuals visuals;
    public Action<ITransitEntity> onSourceChange;
    public Action<ITransitEntity> onDestinationChange;
    public ITransitEntity Source { get; protected set; }
    public ITransitEntity Destination { get; protected set; }

    public TransitRoute(ITransitEntity source, ITransitEntity destination);
    public void Destroy();
    public void SetVisualsActive(bool active);
    private void Update();
    public virtual void SetSource(ITransitEntity source);
    public bool AreEntitiesNonNull();
    public virtual void SetDestination(ITransitEntity destination);
    private void ValidateEntities();
}