using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpritesManager : MonoBehaviour
{
    [Header("SO")]
    [SerializeField] private SpritesDataSO spritesDataSO;

    void Awake()
    {
        RandomDraw();
    }

    void RandomDraw()
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
