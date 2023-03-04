using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatEventChannelSO _setSpeedGroundFloatChannel;

    void OnEnable()
    {
        _setSpeedGroundFloatChannel.OnFloatRequested += SetSpeedAnimationClip;
    }

    void OnDisable()
    {
        _setSpeedGroundFloatChannel.OnFloatRequested -= SetSpeedAnimationClip;        
    }

    void SetSpeedAnimationClip(float speed)
    {
        _animator.speed = speed;
    }
}
