using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickerZone : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction Click;

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}