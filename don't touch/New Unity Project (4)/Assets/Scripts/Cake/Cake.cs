using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cake : MonoBehaviour
{
    [SerializeField] private int _profit;

    private CakeLayer[] _layers;
    private int _createdLayers;

    public int Profit => _profit;

    public bool Done => _createdLayers == _layers.Length;

    public event UnityAction CakeDone;
    public event UnityAction<float, float> LayerCookingProgresses;

    private void Start()
    {
        _layers = GetComponentsInChildren<CakeLayer>();

        _createdLayers = 0;
    }

    public void OnClick()
    {
        if (Done == false)
        {
            if (TryBakeLayer())
            {
                if (Done == true)
                {
                     CakeDone?.Invoke();
                }
            }
        }
    }

    private bool TryBakeLayer()
    {
        CakeLayer cakeLayer = _layers[_createdLayers];

        cakeLayer.IncreaseCookingProgress();
        LayerCookingProgresses?.Invoke(cakeLayer.CookingProgress, cakeLayer.ClicksBeforeCooking);

        if (cakeLayer.TryCookLayer())
        {
            _createdLayers++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
