using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private IntEventChannelSO _scoreIntChannel;
    [SerializeField] private int _amountPoints;

    void OnTriggerEnter2D(Collider2D collision)
    {
        _scoreIntChannel.RaiseEvent(_amountPoints);
    }
}
