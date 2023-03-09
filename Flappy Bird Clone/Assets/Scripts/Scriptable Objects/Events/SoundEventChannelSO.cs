using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Event/Sound Channel")]
public class SoundEventChannelSO : ScriptableObject
{
    public UnityAction<SoundSO> OnSoundRequested;

    public void RaiseEvent(SoundSO sound)
    {
        if (OnSoundRequested != null)
        {
            OnSoundRequested.Invoke(sound);
        }
    }
}
