using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShopProductController : MonoBehaviour
{
    [Header("Shop Products:")]
    [SerializeField] private List<ShopProductInfo> _shopProductInfoPool;
    [SerializeField] private List<ShopProduct> _shopProductPool;
    [SerializeField] private NewShopProductInfo _newShopProductInfo;
    [Header("Rect Transforms:")]
    [SerializeField] private RectTransform _contentRectTransform;
    [Header("Texts:")]
    [SerializeField] private TMP_InputField[] _newPackTextPool;
    
    private Sprite _spriteForNewShopProduct;
    
    private int countNullText;
    private bool isMaterialTextCorrect, isProductTextCorrect;

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
            
            foreach (var newShopProduct in _newShopProductInfo.allMaterialInfoPool)
            {
                if (_newPackTextPool[4].text == newShopProduct.idMaterial)
                {
                    isMaterialTextCorrect = true;
                }
            }

            foreach (var newShopProduct in _newShopProductInfo.allProductInfoPool)
            {
                if (_newPackTextPool[6].text == newShopProduct.idProduct)
                {
                    isProductTextCorrect = true;
                }
            }

            if (isMaterialTextCorrect && isProductTextCorrect)
            {
                isMaterialTextCorrect = false;
                isProductTextCorrect = false;
                
                ChangeNewPackInfo(contentForShopProduct);
                return true;
            }
        }

        countNullText = 0;
        isMaterialTextCorrect = false;
        isProductTextCorrect = false;
        return false;
    }

    private void ChangeNewPackInfo(Transform contentForShopProduct)
    {
        _newShopProductInfo.titleText = _newPackTextPool[0].text;
        _newShopProductInfo.descriptionText = _newPackTextPool[1].text;
        _newShopProductInfo.priceText = _newPackTextPool[2].text;
        _newShopProductInfo.discountText = _newPackTextPool[3].text;
        _newShopProductInfo.materialText = _newPackTextPool[4].text;
        _newShopProductInfo.materialCountText = _newPackTextPool[5].text;
        _newShopProductInfo.productText = _newPackTextPool[6].text;

        var materialCount = float.Parse(_newShopProductInfo.materialCountText);

        materialCount = materialCount switch
        {
            > 6 => 6,
            < 3 => 3,
            _ => materialCount
        };

        foreach (var newShopProduct in _newShopProductInfo.allMaterialInfoPool)
        {
            if (_newShopProductInfo.materialText == newShopProduct.idMaterial)
            {
                for (int i = 0; i < materialCount; i++)
                {
                    _newShopProductInfo.emptyMaterialInfoPool.Add(newShopProduct);
                }
                break;
            }
        }

        foreach (var newShopProduct in _newShopProductInfo.allProductInfoPool)
        {
            if (_newShopProductInfo.productText == newShopProduct.idProduct)
            {
                _spriteForNewShopProduct = newShopProduct.productSprite;
            }
        }
            
        CreateNewPack(contentForShopProduct);
    }

    private void CreateNewPack(Transform contentForShopProduct)
    {
        var newShopProduct = _newShopProductInfo.shopProductPrefab;

        newShopProduct.ChangeTitleText(_newShopProductInfo.titleText);
        newShopProduct.ChangeDescriptionText(_newShopProductInfo.descriptionText);
        newShopProduct.ChangeCurrentPriceText(float.Parse(_newShopProductInfo.priceText));
        newShopProduct.ChangeDiscountText(float.Parse(_newShopProductInfo.discountText));
        newShopProduct.ChangeProductSprite(_spriteForNewShopProduct);
        newShopProduct.ChangeMaterialPanelInfoPool(_newShopProductInfo.emptyMaterialInfoPool);
            
        var newShopProductObject = Instantiate(newShopProduct, contentForShopProduct);
            
        newShopProductObject.InitializeMaterialPanelPool();
            
        _shopProductPool.Add(newShopProductObject);
            
        ChangeHeightContentForShopProduct();
        
        ClearNewPackInfo();
        ClearNewPackTextInfo();
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
            newShopProduct.ChangeMaterialPanelInfoPool(shopProductInfo.materialInfoPool);
            
            var newShopProductObject = Instantiate(newShopProduct, contentForShopProduct);
            
            newShopProductObject.InitializeMaterialPanelPool();
            
            _shopProductPool.Add(newShopProductObject);
            
            ChangeHeightContentForShopProduct();
        }
    }

    private void ClearNewPackInfo()
    {
        _newShopProductInfo.emptyMaterialInfoPool.Clear();
            
        _newShopProductInfo.titleText = string.Empty;
        _newShopProductInfo.descriptionText = string.Empty;
        _newShopProductInfo.priceText = string.Empty;
        _newShopProductInfo.discountText = string.Empty;
        _newShopProductInfo.materialText = string.Empty;
        _newShopProductInfo.materialCountText = string.Empty;
        _newShopProductInfo.productText = string.Empty;
    }
    
    private void ClearNewPackTextInfo()
    {
        foreach (var newPackText in _newPackTextPool)
        {
            newPackText.text = string.Empty;
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