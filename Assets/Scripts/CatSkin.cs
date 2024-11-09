using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkin : MonoBehaviour
{
    public Texture[] skins;
    public Material catMaterial;
    public int selectedSkin;

    private void Awake()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        catMaterial.mainTexture = skins[selectedSkin];
    }

    public void SetSkin(int skinId)
    {
        catMaterial.mainTexture = skins[skinId];
    }
}
