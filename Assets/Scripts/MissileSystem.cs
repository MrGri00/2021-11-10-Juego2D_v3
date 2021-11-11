using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSystem : ShootingSystem
{
    public override void Shoot()
    {
        GameObject missile = PoolingManager.Instance.GetPooledObject("missiles");

        missile.GetComponent<HealthManager>().ResetHealth();

        if (missile != null)
        {
            missile.transform.position = shotPoint.position;
            missile.transform.rotation = shotPoint.rotation;
            missile.SetActive(true);
            missile.GetComponent<Missile>().SetTarget(GameObject.Find("Target").transform, shootingData.fireForce);
        }
    }
}
