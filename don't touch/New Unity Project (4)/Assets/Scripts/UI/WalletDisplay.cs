using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _cakeDisplay;

    private void OnEnable()
    {
        _playerWallet.CakeBalanceChange += OnCakeBalanceChange;
    }
    private void OnDisable()
    {
        _playerWallet.CakeBalanceChange -= OnCakeBalanceChange;
    }

    private void OnCakeBalanceChange(int cakeBalance)
    {
        _cakeDisplay.text = cakeBalance.ToString();
    }
}
