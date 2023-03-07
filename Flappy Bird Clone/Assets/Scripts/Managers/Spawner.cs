using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Others")]
    [SerializeField] private PoolObjects _poolObjects;
    [SerializeField] private BalancingContainerSO _balancingContainer;


    [Header("Channels")]
    [SerializeField] private BoolEventChannelSO _setCanSpawnBoolChannel;
    [SerializeField] private VoidEventChannelSO _jumpVoidChannel;

    [Header("Spawn")]
    [SerializeField] private float _timeToNextSpawn;
    [SerializeField] private float _initialPosition;
    [SerializeField] private bool _canSpawn = true;

    [Header("Heigth")]
    [SerializeField] private float _minHeigth;
    [SerializeField] private float _maxHeigth;

    PoolableObject _currentPoolableObj;
    private float _timer;

    void OnEnable()
    {
        _setCanSpawnBoolChannel.OnBoolRequested += SetCanSpawn;
        _jumpVoidChannel.OnVoidRequested += ChangeCanSpawnAfterFirstJump;
    }

    void OnDisable()
    {
        _setCanSpawnBoolChannel.OnBoolRequested -= SetCanSpawn;        
        _jumpVoidChannel.OnVoidRequested -= ChangeCanSpawnAfterFirstJump;
    }

    void Start()
    {
        InitializeParameters();
    }

    void Update()
    {
        SpawnAfterTime();
    }

    void SpawnAfterTime()
    {
        if (_canSpawn)
        {
            if (_timer <= 0f)
            {
                _currentPoolableObj = _poolObjects.GetMonoBehaviourFromPool();
                _currentPoolableObj.rectTransform.anchoredPosition3D = new Vector3(_initialPosition, Random.Range(_minHeigth, _maxHeigth), _currentPoolableObj.rectTransform.localPosition.z);
                _currentPoolableObj.rectTransform.localScale = Vector3.one;
                _timer = _timeToNextSpawn;
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    void InitializeParameters()
    {
        _timeToNextSpawn = _balancingContainer.timeToNextSpawn;
        _timer = _timeToNextSpawn;
    }

    void SetCanSpawn(bool value)
    {
        _canSpawn = value;
    }

    void ChangeCanSpawnAfterFirstJump()
    {
        SetCanSpawn(true);
    }
}
