using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/Bool Channel")]
public class BoolEventChannelSO : ScriptableObject
{
    public UnityAction<bool> OnBoolRequested;

    public void RaiseEvent(bool value)
    {
        if (OnBoolRequested != null)
        {
            OnBoolRequested.Invoke(value);
        }
    }
}
