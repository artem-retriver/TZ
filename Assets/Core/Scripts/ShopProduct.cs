using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopProduct : MonoBehaviour
{
    //private string _idShopProduct;
    [SerializeField] private List<MaterialPanelInfo> _materialPanelInfoPool;
    [SerializeField] private List<MaterialPanel> _materialPanelPool;
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Text _newPriceText;
    [SerializeField] private Text _oldPriceText;
    [SerializeField] private Image _productSprite;
    [SerializeField] private GameObject _contentForMaterialPanel;

    private void Start()
    {
        InitializeMaterialPanelPool();
    }

    public void ChangeMaterialPanelInfoPool(List<MaterialPanelInfo> materialPanelInfoPool)
    {
        _materialPanelInfoPool = materialPanelInfoPool;
    }
    
    private void InitializeMaterialPanelPool()
    {
        foreach (var materialPanelInfo in _materialPanelInfoPool)
        {
            var newMaterialPanelInfo = materialPanelInfo.materialPanelPrefab;
            
            newMaterialPanelInfo.ChangeMaterialCountText(materialPanelInfo.materialCountText);
            
            var newMaterialPanel = Instantiate(newMaterialPanelInfo, _contentForMaterialPanel.transform);
            _materialPanelPool.Add(newMaterialPanel);
        }
    }
    
    public void ChangeTitleText(string titleText)
    {
        _titleText.text = titleText;
    }
    
    public void ChangeDescriptionText(string descriptionText)
    {
        _descriptionText.text = descriptionText;
    }
    
    public void ChangeNewPriceText(string newPriceText)
    {
        _newPriceText.text = newPriceText;
    }
    
    public void ChangeOldPriceText(string newPriceText)
    {
        _oldPriceText.text = newPriceText;
    }
    
    public void ChangeProductSprite(Sprite productSprite)
    {
        _productSprite.sprite = productSprite;
    }
}
