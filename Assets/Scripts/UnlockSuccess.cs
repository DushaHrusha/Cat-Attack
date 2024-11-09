using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSuccess : MonoBehaviour
{
    public string successName;
    public GameObject check;

    private void Start()
    {
        if(PlayerPrefs.GetInt(successName, 0) == 1)
        {
            check.SetActive(true);
        }
    }
}
