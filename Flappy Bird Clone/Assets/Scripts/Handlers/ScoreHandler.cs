using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private BestScoreSO _bestScore;

    [Header("Texts")]
    [SerializeField] private TMP_Text _currentScoreText;
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private TMP_Text _bestScoreText;

    [Header("Panels")]
    [SerializeField] private GameObject _bronzeScorePanel;
    [SerializeField] private GameObject _silverScorePanel;
    [SerializeField] private GameObject _goldScorePanel;
    [SerializeField] private GameObject _diamondScorePanel;

    [Header("Medal")]
    [SerializeField] private int _currentScore;
    [SerializeField] private int _bronzeScore;
    [SerializeField] private int _silverScore;
    [SerializeField] private int _goldScore;

    [Header("Channels")]
    [SerializeField] private IntEventChannelSO _scoreIntChannel;
    [SerializeField] private VoidEventChannelSO _collisionVoidChannel;

    [Header("Event")]
    [SerializeField] private UnityEvent _OnScored;

    void OnEnable()
    {
        _scoreIntChannel.OnIntRequested += SetScored;
        _collisionVoidChannel.OnVoidRequested += SetFinalScore;
        _collisionVoidChannel.OnVoidRequested += SetBestScore;
        _collisionVoidChannel.OnVoidRequested += SetMedal;
    }
    void OnDisable()
    {
        _scoreIntChannel.OnIntRequested -= SetScored;
        _collisionVoidChannel.OnVoidRequested -= SetFinalScore;
        _collisionVoidChannel.OnVoidRequested -= SetBestScore;
        _collisionVoidChannel.OnVoidRequested -= SetMedal;
    }

    void SetScored(int value)
    {
        _currentScore += value;
        _currentScoreText.text = _currentScore.ToString();
        _OnScored?.Invoke();
    }

    void SetFinalScore()
    {
        _finalScoreText.text = _currentScore.ToString();
    }

    void SetBestScore()
    {
        if (_currentScore >= _bestScore.score)
        {
            _bestScoreText.text = _currentScore.ToString();
            _bestScore.score = _currentScore;
        }
        else
        {
            _bestScoreText.text = _bestScore.score.ToString();
        }
    }

    void SetMedal()
    {
        if (_currentScore <= _bronzeScore)
        {
            _bronzeScorePanel.SetActive(true);
        }
        else if (_currentScore <= _silverScore)
        {
            _silverScorePanel.SetActive(true);
        }
        else if (_currentScore <= _goldScore)
        {
            _goldScorePanel.SetActive(true);
        }
        else if (_currentScore > _goldScore)
        {
            _diamondScorePanel.SetActive(true);
        }
    }
}
