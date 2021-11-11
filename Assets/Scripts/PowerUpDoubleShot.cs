using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoubleShot : CollisionSystem
{
    protected override void OnCollision(Collider2D other)
    {
        ShootingSystemData sh = Resources.Load<ShootingSystemData>("ShotData");

        for (int i = 0; i < other.gameObject.GetComponent<ShipController>().ShootingScriptsListCount(); i++)
        {
            Destroy(other.gameObject.GetComponent<ShipController>().ReturnFromList(i));
        }

        other.gameObject.GetComponent<ShipController>().ClearList();

        ShotSystem sLeft = other.gameObject.AddComponent<ShotSystem>();
        ShotSystem sRight = other.gameObject.AddComponent<ShotSystem>();

        sLeft.shootingData = sh;
        Transform t = other.gameObject.GetComponent<ShipController>().GetShotPoint(1);
        sLeft.shotPoint = t;

        sRight.shootingData = sh;
        t = other.gameObject.GetComponent<ShipController>().GetShotPoint(2);
        sRight.shotPoint = t;

        other.gameObject.GetComponent<ShipController>().SetLauncher(sLeft, true);
        other.gameObject.GetComponent<ShipController>().SetLauncher(sRight, false);

        other.gameObject.GetComponent<ShipController>().AddToList(sLeft);
        other.gameObject.GetComponent<ShipController>().AddToList(sRight);
    }
}
