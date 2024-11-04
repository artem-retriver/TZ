using UnityEngine;

[CreateAssetMenu(fileName = "ProductInfo", menuName = "Game/New Product Info SO")]
public class ProductInfo : ScriptableObject
{
    [SerializeField] private string _idProduct;
    [SerializeField] private Sprite _productSprite;

    public string idProduct => _idProduct;
    public Sprite productSprite => this._productSprite;
}
