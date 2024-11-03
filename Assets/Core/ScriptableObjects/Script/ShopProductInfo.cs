using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopProductInfo", menuName = "Game/New Shop Product Indo SO")]
public class ShopProductInfo : ScriptableObject
{
    [SerializeField] private string _titleText;
    [SerializeField] private string _descriptionText;
    [SerializeField] private float _priceText;
    [SerializeField] private float _discountText;
    [SerializeField] private Sprite _productSprite;
    [SerializeField] private ShopProduct _shopProductPrefab;
    [SerializeField] private List<MaterialPanelInfo> _materialPanelInfoPool;
    
    public string titleText => this._titleText;
    public string descriptionText => this._descriptionText;
    public float priceText => this._priceText;
    public float discountText => this._discountText;
    public Sprite productSprite => this._productSprite;
    public ShopProduct shopProductPrefab => this._shopProductPrefab;
    public List<MaterialPanelInfo> materialPanelInfoPool => this._materialPanelInfoPool;
}