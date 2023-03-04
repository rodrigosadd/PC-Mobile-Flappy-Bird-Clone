using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class PoolableObject : MonoBehaviour, IMonoBehaviourPool, IPool
{
    public MonoBehaviour MonoBehaviourReference => this;
    public GameObject GameObjectReference => gameObject;

    [Header("Others")]
    public RectTransform rectTransform;
    [SerializeField] private float _timeToDeactivate = 2f;
    [SerializeField] private bool _canDeactivate;

    [Header("Channel")]
    [SerializeField] private BoolEventChannelSO _setCanDeactivatePoolableBoolChannel;

    public bool IsBeenUsed { get; set; }

    private float _timer;

    void OnEnable()
    {
        InitializeTimer();

        _setCanDeactivatePoolableBoolChannel.OnBoolRequested += SetCanDeactivate;
    }

    void OnDisable()
    {
        _setCanDeactivatePoolableBoolChannel.OnBoolRequested -= SetCanDeactivate;
    }

    void Update()
    {
        DeactivateAfterTime();
    }

    public void Reset()
    {
        IsBeenUsed = false;
        gameObject.SetActive(false);
    }

    void DeactivateAfterTime()
    {
        if (_canDeactivate)
        {
            if (_timer <= 0f)
            {
                Reset();
            }
            else
            {
                _timer -= Time.deltaTime;
            }
        }
    }

    void InitializeTimer()
    {
        _timer = _timeToDeactivate;
    }

    void SetCanDeactivate(bool value)
    {
        _canDeactivate = value;
    }
}
