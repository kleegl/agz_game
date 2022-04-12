using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGubButton : Buttons
{
    public void OnHitGubLink()
    {
        Application.OpenURL("https://github.com/JenyaMefedov/agz");
    }
}
