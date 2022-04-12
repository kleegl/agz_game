using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayButton : Buttons
{
    public void OnPlay()
    {
        SceneManager.LoadScene("Game");
    }
}
