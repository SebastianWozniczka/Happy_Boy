using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnRight : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Controllers controllers;
    public void OnPointerDown(PointerEventData eventData){}
    public void OnPointerEnter(PointerEventData eventData)
    {
        controllers.right = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        controllers.right = false;
    }
}