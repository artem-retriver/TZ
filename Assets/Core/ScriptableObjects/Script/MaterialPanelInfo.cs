using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopProductInfo", menuName = "Game/New Material Panel SO")]
public class MaterialPanelInfo : ScriptableObject
{
    [SerializeField] private string _materialCountText;
    //[SerializeField] private Sprite _productSprite;
    [SerializeField] private MaterialPanel _materialPanelPrefab;

    public string materialCountText => this._materialCountText;
    //public Sprite productSprite => this._productSprite;
    public MaterialPanel materialPanelPrefab => this._materialPanelPrefab;
}
