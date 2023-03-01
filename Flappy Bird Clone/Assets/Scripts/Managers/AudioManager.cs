using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    [Header("List")]
    [SerializeField] private List<SoundSO> _sounds;

    [Header("Event")]
    [SerializeField] private UnityEvent _onStart;

    [Header("Channel")]
    [SerializeField] private SoundEventChannelSO _soundChannel;

    void Awake()
    {
        SetSoundConfigs();
    }

    void OnEnable()
    {
        _soundChannel.OnSoundRequested += Play;
    }

    void OnDisable()
    {
        _soundChannel.OnSoundRequested -= Play;        
    }

    void Start()
    {
        _onStart?.Invoke();
    }

    void SetSoundConfigs()
    {
        foreach (SoundSO sound in _sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.playOnAwake = sound.playOnAwake;
            sound.source.loop = sound.loop;
        }
    }

    public void Play(SoundSO sound)
    {
        if (sound == null)
        {
            Debug.LogWarning("Sound not found!");
            return;
        }

        sound.source.Play();
    }
}
