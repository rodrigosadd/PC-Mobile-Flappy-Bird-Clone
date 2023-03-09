using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/Void Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnVoidRequested;

    public void RaiseEvent()
    {
        if (OnVoidRequested != null)
        {
            OnVoidRequested.Invoke();
        }
    }
}
