using System.Collections;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [Header("Others")]
    [SerializeField] private Animator _animator;
    [SerializeField] private float _transitionTime;
    [SerializeField] private string _transitionParameterName;

    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _startTransitionVoidChannel;
    [SerializeField] private VoidEventChannelSO _endTransitionVoidChannel;

    void OnEnable()
    {
        _startTransitionVoidChannel.OnVoidRequested += StartTransition;
    }

    void OnDisable()
    {
        _startTransitionVoidChannel.OnVoidRequested -= StartTransition;    
    }

    void StartTransition()
    {
        StartCoroutine(Transition());
    }


    IEnumerator Transition()
    {
        _animator.SetTrigger(_transitionParameterName);

        yield return new WaitForSeconds(_transitionTime);

        _endTransitionVoidChannel.RaiseEvent();
    }
}
