using UnityEngine;

[CreateAssetMenu(fileName = "MaterialInfo", menuName = "Game/New Material Panel SO")]
public class MaterialInfo : ScriptableObject
{
    [SerializeField] private string _idMaterial;
    [SerializeField] private string _materialCountText;
    [SerializeField] private Sprite _materialSprite;
    [SerializeField] private MaterialPanel _materialPanelPrefab;

    public string idMaterial => _idMaterial;
    public string materialCountText => this._materialCountText;
    public Sprite materialSprite => this._materialSprite;
    public MaterialPanel materialPanelPrefab => this._materialPanelPrefab;
}