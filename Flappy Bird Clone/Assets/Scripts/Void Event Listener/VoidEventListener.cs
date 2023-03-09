using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    [Header("Channel")]
    public VoidEventChannelSO voidEventChannelSO;

    [Header("Event")]
    public UnityEvent OnEventRised;

    void OnDisable()
    {
        DeleteSignature();
    }

    private void Start()
    {
        voidEventChannelSO.OnVoidRequested += RiseEvent;
    }

    public void DeleteSignature()
    {
        voidEventChannelSO.OnVoidRequested -= RiseEvent;
    }

    void RiseEvent()
    {
        if (OnEventRised == null)
            return;

        OnEventRised.Invoke();
    }
}
