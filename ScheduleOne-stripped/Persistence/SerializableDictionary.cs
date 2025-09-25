using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Persistence;
[Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
{
    [SerializeField]
    private List<TKey> keys;
    [SerializeField]
    private List<TValue> values;
    private Dictionary<TKey, TValue> dictionary;
    public TValue this[TKey key]
    {
        get
        {
            return dictionary[key];
        }

        set
        {
            dictionary[key] = value;
        }
    }

    public ICollection<TKey> Keys => dictionary.Keys;
    public ICollection<TValue> Values => dictionary.Values;
    public int Count => dictionary.Count;
    public bool IsReadOnly => false;

    public void OnBeforeSerialize();
    public void OnAfterDeserialize();
    public void Add(TKey key, TValue value);
    public bool ContainsKey(TKey key);
    public bool Remove(TKey key);
    public bool TryGetValue(TKey key, out TValue value);
    public void Add(KeyValuePair<TKey, TValue> item);
    public void Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex);
    public bool Remove(KeyValuePair<TKey, TValue> item);
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator();
}