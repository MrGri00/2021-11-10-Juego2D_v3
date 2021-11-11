using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;

    private int randPoint;
    private int randAsteroid;

    void Start()
    {
        StartCoroutine(GenerateMeteor());
    }

    IEnumerator GenerateMeteor()
    {
        randPoint = Random.Range(0, positions.Length);
        randAsteroid = Random.Range(0, 3);

        GameObject meteor = PoolingManager.Instance.GetPooledObject("asteroids");

        GameObject mMeteor = PoolingManager.Instance.GetPooledObject("miniAsteroids");

        GameObject hMeteor = PoolingManager.Instance.GetPooledObject("heavyAsteroids");

        switch (randAsteroid)
        {
            case 0:
                if (meteor != null)
                {
                    meteor.transform.position = positions[randPoint].position;
                    meteor.GetComponent<HealthManager>().ResetHealth();
                    meteor.SetActive(true);
                }
                break;

            case 1:
                if (mMeteor != null)
                {
                    mMeteor.transform.position = positions[randPoint].position;
                    meteor.GetComponent<HealthManager>().ResetHealth();
                    mMeteor.SetActive(true);
                }
                break;

            case 2:
                if (hMeteor != null)
                {
                    hMeteor.transform.position = positions[randPoint].position;
                    meteor.GetComponent<HealthManager>().ResetHealth();
                    hMeteor.SetActive(true);
                }
                break;
        }

        yield return new WaitForSeconds(1.0f);
        StartCoroutine(GenerateMeteor());
    }
}
