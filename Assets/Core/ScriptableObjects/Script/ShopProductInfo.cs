using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopProductInfo", menuName = "Game/New Shop Product Indo SO")]
public class ShopProductInfo : ScriptableObject
{
    //[SerializeField] private string _idShopProduct;
    [SerializeField] private string _titleText;
    [SerializeField] private string _descriptionText;
    [SerializeField] private string _newPriceText;
    [SerializeField] private string _oldPriceText;
    //[SerializeField] private Sprite _productSprite;
    [SerializeField] private ShopProduct _shopProductPrefab;
    [SerializeField] private List<MaterialPanelInfo> _materialPanelInfoPool;

    //public string idShopProduct => this._idShopProduct;
    public string titleText => this._titleText;
    public string descriptionText => this._descriptionText;
    public string newPriceText => this._newPriceText;
    public string oldPriceText => this._oldPriceText;
    //public Sprite productSprite => this._productSprite;
    public ShopProduct shopProductPrefab => this._shopProductPrefab;
    public List<MaterialPanelInfo> materialPanelInfoPool => this._materialPanelInfoPool;
}
