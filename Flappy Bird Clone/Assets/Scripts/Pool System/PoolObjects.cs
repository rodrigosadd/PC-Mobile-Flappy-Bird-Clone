using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    [Header("System")]
    [SerializeField] private PoolSystem _poolSystem;

    [Header("Initialize")]
    [SerializeField] private PoolableObject _prefabObjPool;
    [SerializeField] private RectTransform _spot;
    [SerializeField] private int _initialAmountPoolableObjects;

    [Header("Poolable Objects")]
    [SerializeField] private PoolableObject[] _objsPool;

    PoolableObject _currentPoolableObj;

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        _poolSystem.InitializePool(ref _objsPool, _prefabObjPool, _initialAmountPoolableObjects, _spot);
    }

    public PoolableObject GetMonoBehaviourFromPool()
    {
        _currentPoolableObj = (PoolableObject)_poolSystem.TryGetMonoBehaviourFromPool<PoolableObject>(ref _objsPool, _prefabObjPool, _spot);
        _currentPoolableObj.IsBeenUsed = true;
        return _currentPoolableObj;
    }
}
