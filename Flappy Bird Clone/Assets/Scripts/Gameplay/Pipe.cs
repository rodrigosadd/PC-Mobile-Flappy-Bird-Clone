using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("Others")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float _speed;

    [Header("SO")]
    [SerializeField] private BalancingContainerSO _balancingContainer;
    [SerializeField] private SpritesDataSO spritesDataSO;

    [Header("Pipe Sprites")]
    [SerializeField] private GameObject _pipeDayUpSprite;
    [SerializeField] private GameObject _pipeDayDownSprite;
    [SerializeField] private GameObject _pipeNightUpSprite;
    [SerializeField] private GameObject _pipeNightDownSprite;

    [Header("Channel")]
    [SerializeField] private FloatEventChannelSO _setSpeedPipeFloatChannel;

    void OnEnable()
    {
        _setSpeedPipeFloatChannel.OnFloatRequested += SetSpeed;
    }

    void OnDisable()
    {
        _setSpeedPipeFloatChannel.OnFloatRequested -= SetSpeed;        
    }

    void Start()
    {
        if (_balancingContainer.pipeSpeed > 0f)
        {
            _speed = _balancingContainer.pipeSpeed;
        }

        ActivateSprites(spritesDataSO.isDay);
    }

    void Update()
    {
        _rectTransform.anchoredPosition3D += Vector3.left * _speed * Time.deltaTime; 
    }

    void ActivateSprites(bool isDay)
    {
        if (isDay)
        {
            _pipeDayUpSprite.SetActive(true);
            _pipeDayDownSprite.SetActive(true);

            _pipeNightUpSprite.SetActive(false);
            _pipeNightDownSprite.SetActive(false);
        }
        else
        {
            _pipeDayUpSprite.SetActive(false);
            _pipeDayDownSprite.SetActive(false);

            _pipeNightUpSprite.SetActive(true);
            _pipeNightDownSprite.SetActive(true);
        }
    }

    void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
