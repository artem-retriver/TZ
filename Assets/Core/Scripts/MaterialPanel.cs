using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialPanel : MonoBehaviour
{
    [SerializeField] private Text _materialCountText;
    [SerializeField] private Image _productSprite;

    public void ChangeMaterialCountText(string materialCountText)
    {
        _materialCountText.text = materialCountText;
    }
    
    public void ChangeProductSprite(Sprite productSprite)
    {
        _productSprite.sprite = productSprite;
    }
}
