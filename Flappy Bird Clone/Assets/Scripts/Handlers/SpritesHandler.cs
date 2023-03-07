using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpritesHandler : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private SpritesDataSO spritesDataSO;

    void Awake()
    {
        DrawRandomSprite();
    }

    void DrawRandomSprite()
    {
        int random = Random.Range(0, 10);

        if (random > 5)
        {
            spritesDataSO.isDay = false;
        }
        else if (random < 5)
        {
            spritesDataSO.isDay = true;
        }
    }
}
