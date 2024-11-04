using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Controllers:")]
    [SerializeField] private ShopProductController _shopProductController;
    [Header("Game Objects:")]
    [SerializeField] private GameObject[] _panelPool;
    [SerializeField] private GameObject _contentForShopProduct;
    [Header("Buttons:")]
    [SerializeField] private Button[] _shopPanelButtons;
    [SerializeField] private Button[] _createNewPackPanelButtons;
    [SerializeField] private Button _createShopProductButton;
    [SerializeField] private Button _filledPanelButton;

    private bool isActiveShop, isActiveFilled, isActiveCreateNewPack, isInitializeShopProducts;

    private void Start()
    {
        InitializeNewListeners();
    }

    private void InitializeNewListeners()
    {
        foreach (var button in _shopPanelButtons)
        {
            button.onClick.AddListener(ShopPanelButton);
        }
        
        foreach (var button in _createNewPackPanelButtons)
        {
            button.onClick.AddListener(CreateNewPackPanelButton);
        }
        
        _createShopProductButton.onClick.AddListener(CheckForEverythingIsFilled);
        _filledPanelButton.onClick.AddListener(FilledPanelButton);
    }

    private void CheckForEverythingIsFilled()
    {
        if (_shopProductController.CheckForCreateNewPack(_contentForShopProduct.transform) == false)
        {
            FilledPanelButton();
        }
        else
        {
            CreateNewPackPanelButton();
            ShopPanelButton();
        }
    }

    private void FilledPanelButton()
    {
        if (isActiveFilled == false)
        {
            isActiveFilled = true;
            _panelPool[2].transform.DOScale(1, 0.1f);
        }
        else
        {
            isActiveFilled = false;
            _panelPool[2].transform.DOScale(0, 0.1f);
        }
    }
    
    private void CreateNewPackPanelButton()
    {
        if (isActiveCreateNewPack == false)
        {
            isActiveCreateNewPack = true;

            _panelPool[0].transform.DOScale(1, 0.1f);
        }
        else
        {
            isActiveCreateNewPack = false;

            _panelPool[0].transform.DOScale(0, 0.1f);
        }
    }

    private void ShopPanelButton()
    {
        if (isInitializeShopProducts == false)
        {
            isInitializeShopProducts = true;
            
            _shopProductController.InitializeShopProductPool(_contentForShopProduct.transform);
        }
        
        if (isActiveShop == false)
        {
            isActiveShop = true;

            _panelPool[1].transform.DOScale(1, 0.1f);
            _contentForShopProduct.transform.DOMoveY(650, 0);
        }
        else
        {
            isActiveShop = false;

            _panelPool[1].transform.DOScale(0, 0.1f);
        }
    }
}