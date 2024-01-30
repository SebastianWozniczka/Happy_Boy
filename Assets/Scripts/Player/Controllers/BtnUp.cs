using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnUp : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Controllers controllers;
    public void OnPointerDown(PointerEventData eventData){
        controllers.up = true;

    }
    public void OnPointerUp(PointerEventData eventData) {    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
