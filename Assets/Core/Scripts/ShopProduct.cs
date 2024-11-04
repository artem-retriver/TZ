using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopProduct : MonoBehaviour
{
    [Header("Materials:")]
    [SerializeField] private List<MaterialInfo> _materialPanelInfoPool;
    [SerializeField] private List<MaterialPanel> _materialPanelPool;
    [Header("Texts:")]
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Text _discountText;
    [SerializeField] private Text _currentPriceText;
    [SerializeField] private Text _discountPriceText;
    [Header("Images:")]
    [SerializeField] private Image _productSprite;
    [Header("Game Objects:")]
    [SerializeField] private GameObject _contentForMaterialPanel;

    private float discount, currentPrice, discountPrice;

    public void ChangeMaterialPanelInfoPool(List<MaterialInfo> materialInfoPool)
    {
        _materialPanelInfoPool = materialInfoPool;
    }
    
    public void ChangeTitleText(string titleText)
    {
        _titleText.text = titleText;
    }
    
    public void ChangeDescriptionText(string descriptionText)
    {
        _descriptionText.text = descriptionText;
    }
    
    public void ChangeCurrentPriceText(float newPrice)
    {
        _currentPriceText.text = newPrice.ToString("$ 0.00");
        currentPrice = newPrice;
    }

    public void ChangeDiscountText(float newDiscount)
    {
        _discountText.text = "-" + newDiscount + "%";
        discount = newDiscount;
        
        ChangeDiscountPriceText();
    }

    private void ChangeDiscountPriceText()
    {
        discountPrice = currentPrice - currentPrice * (discount / 100);
        _discountPriceText.text = discountPrice.ToString("$ 0.00");
    }
    
    public void ChangeProductSprite(Sprite productSprite)
    {
        _productSprite.sprite = productSprite;
    }
    
    public void InitializeMaterialPanelPool()
    {
        foreach (var materialPanelInfo in _materialPanelInfoPool)
        {
            var newMaterialPanelInfo = materialPanelInfo.materialPanelPrefab;
            
            newMaterialPanelInfo.ChangeMaterialCountText(materialPanelInfo.materialCountText);
            newMaterialPanelInfo.ChangeMaterialSprite(materialPanelInfo.materialSprite);
            
            var newMaterialPanel = Instantiate(newMaterialPanelInfo, _contentForMaterialPanel.transform);
            
            _materialPanelPool.Add(newMaterialPanel);
        }
    }
}