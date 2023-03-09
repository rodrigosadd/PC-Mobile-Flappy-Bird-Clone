using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/Float Channel")]
public class FloatEventChannelSO : ScriptableObject
{
    public UnityAction<float> OnFloatRequested;

    public void RaiseEvent(float value)
    {
        if (OnFloatRequested != null)
        {
            OnFloatRequested.Invoke(value);
        }
    }
}
