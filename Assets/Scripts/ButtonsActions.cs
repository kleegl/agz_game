using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonsActions : Buttons
{
    public void OnOpenTwitterLink()
    {
        Application.OpenURL("https://twitter.com/j_mefedov");
    }
}
