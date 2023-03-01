using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        IScorable scorable = collision.GetComponent<IScorable>();

        if (scorable != null)
        {
            scorable.ScoredAPoint();
        }
    }
}
