using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceTower : MonoBehaviour, IPointerClickHandler
{
    private GameObject clickedGO;
    public static Vector2 clickedGOPos;
    public void OnPointerClick(PointerEventData eventData) 
    {
        clickedGO = eventData.pointerPress.gameObject;
        clickedGOPos = eventData.pointerPress.transform.position;
    }
}
