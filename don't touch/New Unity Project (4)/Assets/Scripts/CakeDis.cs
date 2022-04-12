using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeDis : MonoBehaviour
{
    [SerializeField] private CakeCollector _cakeCollector;
    [SerializeField] private CakePlace _cakePlace;
    [SerializeField] private List<Cake> _cakeTemplates;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _cakeCollector.CakeCollected += OnCakeCollected;
        _player.CakeBought += OnCakeBought;
    }

    private void OnDisable()
    {
        _cakeCollector.CakeCollected -= OnCakeCollected;
        _player.CakeBought -= OnCakeBought;
    }

    private void Start()
    {
        DispenceCake();
    }

    private void DispenceCake()
    {
        int randomNumber = Random.Range(0, _cakeTemplates.Count);
        Cake randomCake = _cakeTemplates[randomNumber];
        _cakePlace.SetCake(randomCake); 
    }

    private void OnCakeCollected(Cake cake)
    {
        _cakePlace.RemoveCake(cake);
        DispenceCake();
    }

    private void OnCakeBought(Cake cake)
    {
        _cakeTemplates.Add(cake); 
    }
}
