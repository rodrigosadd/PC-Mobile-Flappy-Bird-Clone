using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundSprites : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private SpritesDataSO spritesDataSO;

    [Header("Background Sprites")]
    [SerializeField] private GameObject _backgroundDaySprite;
    [SerializeField] private GameObject _backgroundNightSprite;

    void Start()
    {
        ActivateSprites(spritesDataSO.isDay);
    }

    void ActivateSprites(bool isDay)
    {
        if (isDay)
        {
            _backgroundDaySprite.SetActive(true);
            _backgroundNightSprite.SetActive(false);
        }
        else
        {
            _backgroundDaySprite.SetActive(false);
            _backgroundNightSprite.SetActive(true);
        }
    }
}
