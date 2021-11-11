using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleGameObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToVisualize;

    void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().Moving += VisibleOn;
        GetComponent<InputSystemKeyboard>().StoppedMoving += VisibleOff;
    }

    void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().Moving -= VisibleOn;
        GetComponent<InputSystemKeyboard>().StoppedMoving -= VisibleOff;
    }

    void VisibleOn()
    {
        objectToVisualize.gameObject.SetActive(true);
    }

    void VisibleOff()
    {
        objectToVisualize.gameObject.SetActive(false);
    }
}
