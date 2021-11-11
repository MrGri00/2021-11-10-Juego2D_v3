using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMissile : CollisionSystem
{
    protected override void OnCollision(Collider2D other)
    {
        ShootingSystemData sh = Resources.Load<ShootingSystemData>("MissileData");

        for (int i = 0; i < other.gameObject.GetComponent<ShipController>().ShootingScriptsListCount(); i++)
        {
            Destroy(other.gameObject.GetComponent<ShipController>().ReturnFromList(i));
        }

        other.gameObject.GetComponent<ShipController>().ClearList();

        MissileSystem m = other.gameObject.AddComponent<MissileSystem>();

        m.shootingData = sh;
        Transform t = other.gameObject.GetComponent<ShipController>().GetShotPoint(0);
        m.shotPoint = t;

        other.gameObject.GetComponent<ShipController>().SetLauncher(m, true);
        other.gameObject.GetComponent<ShipController>().NoSecondaryWeaponSystem();

        other.gameObject.GetComponent<ShipController>().AddToList(m);
    }
}
