using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        eventData.selectedObject.transform.localScale *= 0.8f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        eventData.selectedObject.transform.localScale /= 0.8f;
    }
}
