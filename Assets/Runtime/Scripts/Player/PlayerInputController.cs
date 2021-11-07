using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public bool IsReady {get; private set;} = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsReady == false)
            {
                IsReady = true;
            }
        }
    }
}
