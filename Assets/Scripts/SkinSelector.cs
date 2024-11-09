using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public GameObject shop;
    public CatSkin cs;

    public void SelectSkin(int skinId)
    {
        print("Le joueur a cliqué sur le skin " + skinId);
        PlayerPrefs.SetInt("selectedSkin", skinId);
        cs.SetSkin(skinId);
        shop.SetActive(false);
    }
}
