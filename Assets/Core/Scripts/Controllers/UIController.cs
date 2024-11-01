using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private List<ShopProductInfo> _shopProductInfoPool;
    [SerializeField] private List<ShopProduct> _shopProductPool;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _contentForShopProduct;
    [SerializeField] private Button[] _shopButtons;

    private bool isActiveShop, isInitializeShopProducts;

    private void Start()
    {
        _shopButtons[0].onClick.AddListener(ShopButton);
        _shopButtons[1].onClick.AddListener(ShopButton);
    }

    private void ShopButton()
    {
        if (isInitializeShopProducts == false)
        {
            isInitializeShopProducts = true;
            
            InitializeShopProductPool();
        }
        
        if (isActiveShop == false)
        {
            isActiveShop = true;

            _shopPanel.transform.DOScale(1, 0.3f);
            _contentForShopProduct.transform.DOMoveY(650, 0);
        }
        else
        {
            isActiveShop = false;

            _shopPanel.transform.DOScale(0, 0.3f);
        }
    }

    private void InitializeShopProductPool()
    {
        foreach (var shopProductInfo in _shopProductInfoPool)
        {
            var newShopProduct = shopProductInfo.shopProductPrefab;

            newShopProduct.ChangeTitleText(shopProductInfo.titleText);
            newShopProduct.ChangeDescriptionText(shopProductInfo.descriptionText);
            //newShopProduct.ChangeProductSprite(t.productSprite);
            newShopProduct.ChangeOldPriceText(shopProductInfo.oldPriceText);
            newShopProduct.ChangeNewPriceText(shopProductInfo.newPriceText);
            newShopProduct.ChangeMaterialPanelInfoPool(shopProductInfo.materialPanelInfoPool);
            
            var newShopProductObject = Instantiate(newShopProduct, _contentForShopProduct.transform);
            
            //newShopProductObject.InitializeMaterialPanelPool();
            
            _shopProductPool.Add(newShopProductObject);
        }
    }
}
