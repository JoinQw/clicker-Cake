using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerWallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private CakeCollector _cakeCollector;

    private PlayerWallet _playerWallet;

    public event UnityAction<Cake> CakeBought;

    private void OnEnable()
    {
        _cakeCollector.CakeCollected += OnCakeCollected;
    }

    private void OnDisable()
    {
        _cakeCollector.CakeCollected -= OnCakeCollected;
    }

    private void Start()
    {
        _playerWallet = GetComponent<PlayerWallet>();
    }

    private void OnCakeCollected(Cake cake)
    {
        _playerWallet.AddCakeProfit(cake.Profit);
    }

    public bool CheckSolvency(int price)
    {
        return _playerWallet.BakedCake >= price;
    }

    public void BuyCake(CakeShopItem cakeItem)
    {
        _playerWallet.WithdrawCakes(cakeItem.Price);
        CakeBought?.Invoke(cakeItem.cake);
    }
}


