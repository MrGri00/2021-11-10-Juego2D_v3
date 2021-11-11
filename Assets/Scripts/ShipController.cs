using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Transform[] shotPoints;
    private ShootingSystem launcher;
    private ShootingSystem launcher2 = null;

    private List<ShootingSystem> shootingScriptsList;

    void Awake()
    {
        InputSystemKeyboard sk;

        if (TryGetComponent<InputSystemKeyboard>(out sk))
        {
            sk.OnFire += Shoot;
        }
    }

    private void Start()
    {
        launcher = GetComponent<ShootingSystem>();
        launcher2 = null;
        shootingScriptsList = new List<ShootingSystem>();
    }

    public void AddToList(ShootingSystem sysToAdd)
    {
        shootingScriptsList.Add(sysToAdd);
    }

    public ShootingSystem ReturnFromList(int posInList)
    {
        return shootingScriptsList[posInList];
    }

    public void ClearList()
    {
        shootingScriptsList.Clear();
    }

    public int ShootingScriptsListCount()
    {
        return shootingScriptsList.Count;
    }

    public Transform GetShotPoint(int arrayPos)
    {
        return shotPoints[arrayPos];
    }

    public void SetLauncher(ShootingSystem ss, bool launcherNum)
    {
        switch (launcherNum)
        {
            case true:
                launcher = ss;
                break;

            case false:
                launcher2 = ss;
                break;
        }
    }

    public void NoSecondaryWeaponSystem()
    {
        launcher2 = null;
    }

    void Shoot()
    {
        launcher.Shoot();

        if (launcher2 != null)
            launcher2.Shoot();
    }
}
