using System.Collections.Generic;

namespace ScheduleOne.Tools;
public class FloatStack
{
    public enum EStackMode
    {
        Additive,
        Override,
        Multiplicative
    }

    public class StackEntry
    {
        public string Label { get; private set; }
        public float Value { get; private set; }
        public EStackMode Mode { get; private set; }
        public int Order { get; private set; }

        public StackEntry(string label, float value, EStackMode mode, int order);
    }

    private float _defaultValue;
    private List<StackEntry> _stack;
    public float Value { get; private set; }

    public FloatStack(float defaultValue);
    public void Add(StackEntry entry);
    public void Remove(string label);
    public bool TryGetEntry(string label, out StackEntry entry);
    private void Recalculate();
}