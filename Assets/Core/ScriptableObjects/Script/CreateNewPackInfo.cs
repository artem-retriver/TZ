using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreateNewPackInfo", menuName = "Game/New Pack Info SO")]
public class CreateNewPackInfo : ScriptableObject
{
    [SerializeField] private ShopProduct _shopProductPrefab;
    [SerializeField] private List<MaterialPanelInfo> _allMaterialPanelInfoPool;
    public ShopProduct shopProductPrefab => this._shopProductPrefab;
    public List<MaterialPanelInfo> allMaterialPanelInfoPool => this._allMaterialPanelInfoPool;
    public List<MaterialPanelInfo> emptyMaterialPanelInfoPool;
    public string titleText;
    public string descriptionText;
    public string priceText;
    public string discountText;
    public string materialText;
    public string materialCountText;
    public string productText;
}
