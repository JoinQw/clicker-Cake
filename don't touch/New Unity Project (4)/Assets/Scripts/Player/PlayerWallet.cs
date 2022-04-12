using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _bakedCake;

    public int BakedCake => _bakedCake;

    public event UnityAction<int> CakeBalanceChange;

    public void AddCakeProfit(int amount)
    {
        _bakedCake += amount;
        CakeBalanceChange?.Invoke(_bakedCake);
    }
    
    public void WithdrawCakes(int amount)
    {
        _bakedCake -= amount;
        CakeBalanceChange?.Invoke(_bakedCake);
    }
}
