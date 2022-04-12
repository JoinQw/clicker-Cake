using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CakeLayer : MonoBehaviour
{
    [SerializeField] private int _clicksBeforeCooking;
    [SerializeField] private ParticleSystem _cookingEffects;
    [SerializeField] private int _emitCount;


    private SpriteRenderer _spriteRenderer;
    private Color _layerColor;

    public int CookingProgress { get; private set; }
    public int ClicksBeforeCooking => _clicksBeforeCooking;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _layerColor = _spriteRenderer.color;
        CreateGhostLayer();
    }

    public void IncreaseCookingProgress()
    {
        if (_cookingEffects != null)
        {
            _cookingEffects.Emit(_emitCount);
        }
        CookingProgress++;
    }
    private void CreateGhostLayer()
    {
        _spriteRenderer.color = new Color(255, 255, 255, 60);
    }

    public bool TryCookLayer()
    {
        if (_clicksBeforeCooking == CookingProgress)
        {
            _spriteRenderer.color = _layerColor;
            return true;
        }
        else
        {
            return false;
        }
    }
}
