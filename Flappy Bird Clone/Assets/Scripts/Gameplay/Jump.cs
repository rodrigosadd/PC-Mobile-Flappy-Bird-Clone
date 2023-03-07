using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private Rigidbody2D _rbody;
    [SerializeField] private BalancingContainerSO _balancingContainer;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _timeToChangeRbodyParameters;
    [SerializeField] private float _forceRotation;

    [Header("Linear Drag")]
    [SerializeField] private float _linearDrag;
    [SerializeField] private float _linearDragAfterTime;

    [Header("Gravity Scale")]
    [SerializeField] private float _gravityScale;
    [SerializeField] private float _gravityScaleAfterTime;

    [Header("Channels")]
    [SerializeField] private VoidEventChannelSO _jumpVoidChannel;    
    [SerializeField] private BoolEventChannelSO _setRbodySimulatedBoolChannel;    

    void OnEnable()
    {
        _jumpVoidChannel.OnVoidRequested += Jumping;
        _setRbodySimulatedBoolChannel.OnBoolRequested += SetRBodySimulated;
    }

    void OnDisable()
    {
        _jumpVoidChannel.OnVoidRequested -= Jumping;        
        _setRbodySimulatedBoolChannel.OnBoolRequested -= SetRBodySimulated;
    }

    void Start()
    {
        InitializeParameters();
    }

    private void Update()
    {
        RotationAfterJump();
    }

    void InitializeParameters()
    {
        _jumpForce = _balancingContainer.jumpForce;
        _gravityScaleAfterTime = _balancingContainer.fallForce;
    }

    void Jumping()
    {
        StopAllCoroutines();

        _rbody.velocity = Vector3.zero;
        _rbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        if(!_rbody.simulated) SetRBodySimulated(true);

        StartCoroutine(TimerToChangeRbodyParameters());
    }

    IEnumerator TimerToChangeRbodyParameters()
    {
        _rbody.drag = _linearDrag;
        _rbody.gravityScale = _gravityScale;

        yield return new WaitForSeconds(_timeToChangeRbodyParameters);

        _rbody.drag = _linearDragAfterTime;
        _rbody.gravityScale = _gravityScaleAfterTime;
    }

    void SetRBodySimulated(bool value)
    {
        _rbody.simulated = value;
    }

    void RotationAfterJump()
    {
        transform.eulerAngles = new Vector3(0f, 0f, _rbody.velocity.y * _forceRotation);
    }
}
