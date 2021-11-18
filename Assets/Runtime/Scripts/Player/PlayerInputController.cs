using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private bool isReady = false;
    public bool IsReady => isReady;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isReady == false)
            {
                isReady = true;
            }
        }
    }
}
