using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public void SetTarget(Transform target, int force)
    {
        Vector3 lookPos = target.position - transform.position;

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        GetComponent<Rigidbody2D>().AddForce(transform.up * force);
    }
}
