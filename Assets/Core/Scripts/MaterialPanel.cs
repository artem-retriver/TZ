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
    
    public void ChangeMaterialSprite(Sprite materialSprite)
    {
        _productSprite.sprite = materialSprite;
    }
}