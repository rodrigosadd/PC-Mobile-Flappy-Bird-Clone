using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/Int Channel")]
public class IntEventChannelSO : ScriptableObject
{
    public UnityAction<int> OnIntRequested;

    public void RaiseEvent(int value)
    {
        if (OnIntRequested != null)
        {
            OnIntRequested.Invoke(value);
        }
    }
}
