using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    [SerializeField]
    private Transform explosionPoint;

    [SerializeField]
    private GameObject explosionPrefab;

    void OnEnable()
    {
        GetComponent<HealthManager>().Death += Explode;
    }

    void OnDisable()
    {
        GetComponent<HealthManager>().Death -= Explode;
    }

    void Explode()
    {
        Instantiate(explosionPrefab, explosionPoint.position, Quaternion.identity);
    }
}
