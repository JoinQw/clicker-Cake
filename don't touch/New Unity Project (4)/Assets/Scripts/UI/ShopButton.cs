using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OpenShop);
        _closeButton.onClick.AddListener(CloseShop);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(OpenShop);
        _closeButton.onClick.RemoveListener(CloseShop);
    }

    private void OpenShop()
    {
        _shop.gameObject.SetActive(true);
    }

    private void CloseShop()
    {
        _shop.gameObject.SetActive(false);
    }
}
