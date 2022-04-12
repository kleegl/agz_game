using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitterButton : Buttons
{
    public void OnTwitterLink()
    {
        Application.OpenURL("https://twitter.com/j_mefedov");
    }
}
