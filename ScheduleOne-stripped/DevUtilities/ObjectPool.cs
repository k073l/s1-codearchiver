using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScheduleOne.DevUtilities;
public class ObjectPool<T>
    where T : MonoBehaviour
{
    private readonly Stack<T> _pool;
    private readonly T _prefab;
    private readonly Transform _parent;
    private readonly NetworkBehaviour _networkBehaviour;
    private Action<T> _onGetOperation;
    private Action<T> _onReturnOperation;
    public ObjectPool(T prefab, int initialCapacity = 32, Transform parent = null, NetworkBehaviour networkBehaviour = null, Action<T> onGetOperation = null, Action<T> onReturnOperation = null);
    public void Prewarm(int count);
    private void Create(int count);
    public T Get(Transform parent = null);
    public T Get(Vector3 position, Quaternion rotation, Transform parent = null);
    public void Return(T obj);
}