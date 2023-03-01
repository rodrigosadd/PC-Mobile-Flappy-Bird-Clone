using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    [Header("Others")]
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _finalPointsText;
    [SerializeField] private int _points;

    [Header("Channels")]
    [SerializeField] private IntEventChannelSO _scoreIntChannel;
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;

    [Header("Event")]
    [SerializeField] private UnityEvent _OnScored;

    void OnEnable()
    {
        _scoreIntChannel.OnIntRequested += Scored;
        _collisionVoidChannel.OnVoidRequested += SetFinalPoints;
    }

    void OnDisable()
    {
        _scoreIntChannel.OnIntRequested -= Scored;
        _collisionVoidChannel.OnVoidRequested -= SetFinalPoints;        
    }

    void Scored(int value)
    {
        _points += value;
        _pointsText.text = _points.ToString();
        _OnScored?.Invoke();
    }

    void SetFinalPoints()
    {
        _finalPointsText.text = _points.ToString();
    }
}
