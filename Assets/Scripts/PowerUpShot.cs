using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShot : CollisionSystem
{
    protected override void OnCollision(Collider2D other)
    {
        ShootingSystemData sh = Resources.Load<ShootingSystemData>("ShotData");

        for (int i = 0; i < other.gameObject.GetComponent<ShipController>().ShootingScriptsListCount(); i++)
        {
            Destroy(other.gameObject.GetComponent<ShipController>().ReturnFromList(i));
        }

        other.gameObject.GetComponent<ShipController>().ClearList();

        ShotSystem s = other.gameObject.AddComponent<ShotSystem>();

        s.shootingData = sh;
        Transform t = other.gameObject.GetComponent<ShipController>().GetShotPoint(0);
        s.shotPoint = t;

        other.gameObject.GetComponent<ShipController>().SetLauncher(s, true);
        other.gameObject.GetComponent<ShipController>().NoSecondaryWeaponSystem();

        other.gameObject.GetComponent<ShipController>().AddToList(s);
    }
}
