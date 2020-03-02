using System;
using UnityEngine;
using UnityEngine.UI;

public class BonusIcon : MonoBehaviour
{
    public Sprite baseSprite;
    public Sprite usedSprite;
    public Sprite selectedSprite;
    public Sprite usedSelectedSprite;
    public int numberOfUse;
    private int _numberUsed;
    private Image _img;

    private void Start()
    {
        _img = GetComponent<Image>();
    }

    public bool CanUse()
    {
        return _numberUsed < numberOfUse;
    }
    
    public void Use()
    {
        if (CanUse())
        {
            _numberUsed++;
            if (_numberUsed == numberOfUse)
            {
                _img.sprite = usedSprite;
            }
        }
    }

    public void Reset()
    {
        _img.sprite = baseSprite;
        _numberUsed = 0;
    }

    public void Select()
    {
        if (CanUse())
        {
            _img.sprite = selectedSprite;
        }
        else
        {
            _img.sprite = usedSelectedSprite;
        }
    }

    public void Deselect()
    {
        if (CanUse())
        {
            _img.sprite = baseSprite;
        }
        else
        {
            _img.sprite = usedSprite;
        }
    }
}
