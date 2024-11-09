using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomName : MonoBehaviour
{
    string[] names = { "Lydan", "Syrin", "Ptorik", "Joz", "Varog", "Gethrod", "Hezra", "Feron", "Ophni", "Colborn", "Fintis", "Gatlin", "Jinto", "Hagalbar", "Krinn", "Lenox", "Revvyn", "Hodus", "Dimian", "Paskel" };

    private void Awake()
    {
        this.gameObject.name = names[Random.Range(0, names.Length)];
    }
}
