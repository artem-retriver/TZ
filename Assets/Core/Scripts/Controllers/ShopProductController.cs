using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopProductController : MonoBehaviour
{
    [SerializeField] private List<ShopProductInfo> _shopProductInfoPool;
    [SerializeField] private List<ShopProduct> _shopProductPool;
    [SerializeField] private CreateNewPackInfo _createNewPackInfo;
    [SerializeField] private RectTransform _contentRectTransform;
    [SerializeField] private TMP_InputField[] _newPackTextPool;

    private int countNullText;

    private void Start()
    {
        ChangeNewPackInfo(transform,true);
    }

    public bool CheckForCreateNewPack(Transform contentForShopProduct)
    {
        foreach (var text in _newPackTextPool)
        {
            if (text.text == string.Empty)
            {
                countNullText++;
            }
        }

        if (CheckForLetterInCountText(_newPackTextPool[2].text) && CheckForLetterInCountText(_newPackTextPool[3].text) && CheckForLetterInCountText(_newPackTextPool[5].text))
        {
            if (countNullText > 0)
            {
                countNullText = 0;
                return false;
            }
            
            foreach (var t in _createNewPackInfo.allMaterialPanelInfoPool)
            {
                if (_newPackTextPool[4].text == t.idMaterial)
                {
                    ChangeNewPackInfo(contentForShopProduct);
                    return true;
                }
            }
        }

        countNullText = 0;
        return false;
    }

    private void ChangeNewPackInfo(Transform contentForShopProduct, bool needChangeAllToNull = false)
    {
        if (needChangeAllToNull)
        {
            _createNewPackInfo.emptyMaterialPanelInfoPool.Clear();
            
            _createNewPackInfo.titleText = string.Empty;
            _createNewPackInfo.descriptionText = string.Empty;
            _createNewPackInfo.priceText = string.Empty;
            _createNewPackInfo.discountText = string.Empty;
            _createNewPackInfo.materialText = string.Empty;
            _createNewPackInfo.materialCountText = string.Empty;
            _createNewPackInfo.productText = string.Empty;
        }
        else
        {
            _createNewPackInfo.titleText = _newPackTextPool[0].text;
            _createNewPackInfo.descriptionText = _newPackTextPool[1].text;
            _createNewPackInfo.priceText = _newPackTextPool[2].text;
            _createNewPackInfo.discountText = _newPackTextPool[3].text;
            _createNewPackInfo.materialText = _newPackTextPool[4].text;
            _createNewPackInfo.materialCountText = _newPackTextPool[5].text;
            _createNewPackInfo.productText = _newPackTextPool[6].text;

            var materialCount = float.Parse(_createNewPackInfo.materialCountText);

            materialCount = materialCount switch
            {
                > 6 => 6,
                < 3 => 3,
                _ => materialCount
            };

            foreach (var t in _createNewPackInfo.allMaterialPanelInfoPool)
            {
                if (_createNewPackInfo.materialText == t.idMaterial)
                {
                    for (int i = 0; i < materialCount; i++)
                    {
                        _createNewPackInfo.emptyMaterialPanelInfoPool.Add(t);
                    }
                    break;
                }
            }

            CreateNewPack(contentForShopProduct);
        }
    }

    private void CreateNewPack(Transform contentForShopProduct)
    {
        var newShopProduct = _createNewPackInfo.shopProductPrefab;
        var newProductSprite = Resources.Load<Sprite>(_createNewPackInfo.productText);

        newShopProduct.ChangeTitleText(_createNewPackInfo.titleText);
        newShopProduct.ChangeDescriptionText(_createNewPackInfo.descriptionText);
        newShopProduct.ChangeCurrentPriceText(float.Parse(_createNewPackInfo.priceText));
        newShopProduct.ChangeDiscountText(float.Parse(_createNewPackInfo.discountText));
        newShopProduct.ChangeProductSprite(newProductSprite);
        newShopProduct.ChangeMaterialPanelInfoPool(_createNewPackInfo.emptyMaterialPanelInfoPool);
            
        var newShopProductObject = Instantiate(newShopProduct, contentForShopProduct);
            
        newShopProductObject.InitializeMaterialPanelPool();
            
        _shopProductPool.Add(newShopProductObject);
            
        ChangeHeightContentForShopProduct();
    }
    
    public void InitializeShopProductPool(Transform contentForShopProduct)
    {
        
        foreach (var shopProductInfo in _shopProductInfoPool)
        {
            var newShopProduct = shopProductInfo.shopProductPrefab;

            newShopProduct.ChangeTitleText(shopProductInfo.titleText);
            newShopProduct.ChangeDescriptionText(shopProductInfo.descriptionText);
            newShopProduct.ChangeCurrentPriceText(shopProductInfo.priceText);
            newShopProduct.ChangeDiscountText(shopProductInfo.discountText);
            newShopProduct.ChangeProductSprite(shopProductInfo.productSprite);
            newShopProduct.ChangeMaterialPanelInfoPool(shopProductInfo.materialPanelInfoPool);
            
            var newShopProductObject = Instantiate(newShopProduct, contentForShopProduct);
            
            newShopProductObject.InitializeMaterialPanelPool();
            
            _shopProductPool.Add(newShopProductObject);
            
            ChangeHeightContentForShopProduct();
        }
    }
    
    private bool CheckForLetterInCountText(string str)
    {
        return str.All(c => c is >= '0' and <= '9');
    }
    
    private void ChangeHeightContentForShopProduct()
    {
        _contentRectTransform.sizeDelta = new Vector2(1080, 750 * _shopProductPool.Count);
    }
}