using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collided : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        ICollidable collidable = collision.GetComponent<ICollidable>();

        if (collidable != null)
        {
            collidable.Collision();
        }
    }
}
