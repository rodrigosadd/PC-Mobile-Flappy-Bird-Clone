using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Others")]
    [SerializeField] private PoolObjects _poolObjects;
    [SerializeField] private BalancingContainerSO _balancingContainer;


    [Header("Channel")]
    [SerializeField] private VoidEventChannelSO _startSpawnVoidChannel;

    [Header("Spawn")]
    [SerializeField] private float _timeToNextSpawn;
    [SerializeField] private float _initialPosition;
    [SerializeField] private bool _canSpawn = true;

    [Header("Heigth")]
    [SerializeField] private float _minHeigth;
    [SerializeField] private float _maxHeigth;

    PoolableObject _currentPoolableObj;

    void OnEnable()
    {
        _startSpawnVoidChannel.OnVoidRequested += SpawnCoroutine;
    }

    void Start()
    {
        if (_balancingContainer.timeSpawn > 0f)
        {
            _timeToNextSpawn = _balancingContainer.timeSpawn;
        }
    }

    void SpawnCoroutine()
    {
        StopCoroutine(Spawn());
        StartCoroutine(Spawn());
        _startSpawnVoidChannel.OnVoidRequested -= SpawnCoroutine;
    }

    IEnumerator Spawn()
    {
        while (_canSpawn)
        {
            yield return new WaitForSeconds(_timeToNextSpawn);
            _currentPoolableObj = _poolObjects.GetMonoBehaviourFromPool();
            _currentPoolableObj.rectTransform.anchoredPosition3D = new Vector3(_initialPosition, Random.Range(_minHeigth, _maxHeigth), _currentPoolableObj.rectTransform.localPosition.z);
            _currentPoolableObj.rectTransform.localScale = Vector3.one;
        }
    }
}
