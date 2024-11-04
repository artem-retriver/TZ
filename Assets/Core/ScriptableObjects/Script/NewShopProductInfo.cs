using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreateNewPackInfo", menuName = "Game/New Pack Info SO")]
public class NewShopProductInfo : ScriptableObject
{
    [SerializeField] private ShopProduct _shopProductPrefab;
    [SerializeField] private List<MaterialInfo> _allMaterialInfoPool;
    [SerializeField] private List<ProductInfo> _allProductInfoPool;
    public ShopProduct shopProductPrefab => this._shopProductPrefab;
    public List<MaterialInfo> allMaterialInfoPool => this._allMaterialInfoPool;
    public List<MaterialInfo> emptyMaterialInfoPool;
    public List<ProductInfo> allProductInfoPool => this._allProductInfoPool;
    
    public string titleText;
    public string descriptionText;
    public string priceText;
    public string discountText;
    public string materialText;
    public string materialCountText;
    public string productText;
}
