using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingSystem : MonoBehaviour
{
    public ShootingSystemData shootingData;

    public Transform shotPoint;

    public abstract void Shoot();
}
