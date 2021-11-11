using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemKeyboard : MonoBehaviour
{
    public float hor { get; private set; }
    public float ver { get; private set; }

    public event Action OnFire = delegate { };

    public event Action Moving = delegate { };
    public event Action StoppedMoving = delegate { };

    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1"))
            OnFire();

        if (Input.GetKeyDown(KeyCode.W))
            Moving();

        else if (Input.GetKeyUp(KeyCode.W))
            StoppedMoving();
    }
}
