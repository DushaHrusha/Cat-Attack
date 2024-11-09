using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockSkin : MonoBehaviour
{
    public Button btnToUnlock;
    public string prefsKey;

    void Start()
    {
        if(PlayerPrefs.GetInt(prefsKey, 0) == 1)
        {
            btnToUnlock.interactable = true;
        }
    }

}
