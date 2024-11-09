using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI nbCoinsText; // Txt nb de PO du joueur
    public int playerNbCoins; // nb de PO du joueur
    int initialPrice = 10; // Prix initial d'un passage de level
    int coinsLevel; // Niveau actuel du joueur sur le btn coins
    int coinsActualPrice; // Prix actuel de passatge de niveau pour btn coins
    public TextMeshProUGUI coinsPriceText; // texte du prix du btn
    public TextMeshProUGUI coinsLevelText; // texte du niveau du btn

    // speed
    int speedActualPrice;
    int speedLevel;
    public TextMeshProUGUI speedPriceText;
    public TextMeshProUGUI speedLevelText;

    // time
    int timeActualPrice;
    int timeLevel;
    public TextMeshProUGUI timePriceText;
    public TextMeshProUGUI timeLevelText;

    private void Awake()
    {
        // On récupère le nb de PO du joueur
        playerNbCoins = PlayerPrefs.GetInt("nbCoins", 0);
        // On affiche ce nb
        nbCoinsText.text = playerNbCoins.ToString();
        // On Get le lvl du btn coins
        coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
        // On calcule le prix de ce btn
        coinsActualPrice = initialPrice * coinsLevel;
        // On affiche ce prix
        coinsPriceText.text = coinsActualPrice + " PO";
        // Chargement du niveau actuel du btn coins
        coinsLevelText.text = "LEVEL " + coinsLevel;

        speedActualPrice = initialPrice * speedLevel;
        speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
    }

    // On achète le passage au niveau suivant
    public void IncrementCoinLevel()
    {
        // Si on a assez d'argent
        if(playerNbCoins >= coinsActualPrice)
        {
            // On diminue la qté d'argent du joueur
            playerNbCoins -= coinsActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            // On monte d'un niveau
            PlayerPrefs.SetInt("coinsLevel", PlayerPrefs.GetInt("coinsLevel", 1) + 1);
            // On met à journ toutes les infos
            coinsLevel = PlayerPrefs.GetInt("coinsLevel", 1);
            coinsLevelText.text = "LEVEL " + coinsLevel;
            coinsActualPrice = initialPrice * coinsLevel;
            coinsPriceText.text = coinsActualPrice + " PO";
        }
    }

    public void IncrementSpeedLevel()
    {
        if (playerNbCoins >= coinsActualPrice)
        {
            playerNbCoins -= speedActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            PlayerPrefs.SetInt("speedLevel", PlayerPrefs.GetInt("speedLevel", 1) + 1);
            speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
            speedLevelText.text = "LEVEL " + speedLevel;
            speedActualPrice = initialPrice * speedLevel;
            speedPriceText.text = speedActualPrice + " PO";
        }
    }

    public void IncrementTimeLevel()
    {
        if (playerNbCoins >= coinsActualPrice)
        {
            playerNbCoins -= timeActualPrice;
            PlayerPrefs.SetInt("nbCoins", playerNbCoins);
            nbCoinsText.text = playerNbCoins.ToString();
            PlayerPrefs.SetInt("timeLevel", PlayerPrefs.GetInt("timeLevel", 1) + 1);
            timeLevel = PlayerPrefs.GetInt("timeLevel", 1);
            timeLevelText.text = "LEVEL " + timeLevel;
            timeActualPrice = initialPrice * timeLevel;
            timePriceText.text = timeActualPrice + " PO";
        }
    }

}
