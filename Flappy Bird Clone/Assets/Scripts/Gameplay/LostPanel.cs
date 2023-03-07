using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LostPanel : MonoBehaviour
{
    [SerializeField] private GameObject _lostPanel;
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;

    void OnEnable()
    {
        _collisionVoidChannel.OnVoidRequested += SetActivePanel;
    }
    void OnDisable()
    {
        _collisionVoidChannel.OnVoidRequested -= SetActivePanel;
    }

    void SetActivePanel()
    {
        _lostPanel.SetActive(true);
    }
}
