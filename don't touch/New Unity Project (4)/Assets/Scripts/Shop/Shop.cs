using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<CakeShopItem> _cakes;
    [SerializeField] private Player _player;
    [SerializeField] private Item _template;
    [SerializeField] private Transform _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _cakes.Count; i++)
        {
            AddItem(_cakes[i]);
        }
    }

    private void AddItem(CakeShopItem cakeItem)
    {
        Item item = Instantiate(_template, _itemContainer);
        InitializeItem(item, cakeItem);
    }

    private void InitializeItem(Item item, CakeShopItem cakeItem)
    {
        item.SetCake(cakeItem);
        item.SellButtonClick += OnSellButtonClick;
        item.name = _template.name + (transform.childCount + 1);
    }

    private void OnSellButtonClick(CakeShopItem cakeItem, Item item)
    {
        TreSellCake(cakeItem, item);
    }

    private void TreSellCake(CakeShopItem cakeItem, Item item)
    {
        if (_player.CheckSolvency(cakeItem.Price))
        {
            _player.BuyCake(cakeItem);
            cakeItem.Buy();
            UnsubscribeItem(item);
        }
    }
    private void UnsubscribeItem(Item item)
    {
        item.SellButtonClick -= OnSellButtonClick;
    }
}

