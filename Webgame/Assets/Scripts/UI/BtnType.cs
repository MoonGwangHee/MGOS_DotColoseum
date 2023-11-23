using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNTYPE      currentType;
    public Transform    buttonScale;
    Vector3             defaultScale;
    
    void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
