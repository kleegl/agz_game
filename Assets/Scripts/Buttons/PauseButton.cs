using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void OnApplicationPause(bool pauseStatus)
    {
        pauseStatus = true;
    }
}
