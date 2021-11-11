using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollision(collision);
    }

    protected virtual void OnCollision(Collider2D other)
    {
        other.gameObject.GetComponent<HealthManager>().ReduceHealth(
            gameObject.GetComponent<HealthManager>().GetMaxHealth());
    }
}
