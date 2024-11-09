using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameStarted = false;
    public bool gameEnded = false;
    public int level = 1;
    public GameObject[] rooms;
    public GameObject[] tutos;
    public GameObject screenEnd;
    public int timerVal = 30;
    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreFinal;
    public TextMeshProUGUI bestScore;
    public AiPlayer[] aiPlayers;
    public TextMeshProUGUI[] finalScoresText;
    public string[] finalScores;
    public TextMeshProUGUI playerLevel;

    private void Awake()
    {
        level = PlayerPrefs.GetInt("level", 1);
        playerLevel.text = "Level: " + level;
        for (int i = 1; i <= rooms.Length; i++)
        {
            if(i <= level)
            {
                rooms[i-1].SetActive(true);
            }
        }
        bestScore.text = "Best: " + PlayerPrefs.GetInt("scoreMax", 0);
    }

    private void Update()
    {
        
    }

    public void StartGame()
    {
        gameStarted = true;
        tutos[0].SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);
        foreach(AiPlayer ai in aiPlayers)
        {
            ai.StartGame();
        }
    }

    public void SetTimer()
    {
        timerVal--;
        textTimer.text = timerVal.ToString();
        // Si fin de partie
        if(timerVal == 0)
        {
            gameEnded = true;
            CancelInvoke();
            screenEnd.SetActive(true);
            textScoreFinal.text = "Score: " + textScore.text;
            // Afficher le classement
            finalScores[0] = "Player 1 : " + textScore.text;
            finalScores[1] = aiPlayers[0].gameObject.name + " : " + aiPlayers[0].score;
            finalScores[2] = aiPlayers[1].gameObject.name + " : " + aiPlayers[1].score;

            for (int i = 0; i <= 2; i++)
            {
                finalScoresText[i].text = finalScores[i];
            }
        }
    }

    public void RestartGame()
    {
        int scoreActuel = int.Parse(textScore.text);

        int scoreTotal = PlayerPrefs.GetInt("scoreTotal", 0);
        scoreTotal += scoreActuel;
        PlayerPrefs.SetInt("scoreTotal", scoreTotal);
        int actualLevel = Mathf.FloorToInt(scoreTotal / 1000) + 1;
        PlayerPrefs.SetInt("level", actualLevel);

        int scoreMax = PlayerPrefs.GetInt("scoreMax", 0);

        if (scoreActuel > scoreMax)
        {
            PlayerPrefs.SetInt("scoreMax", scoreActuel);
        }

        timerVal = 30; // reset val
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void WatchExtraTimeVideo()
    {
        // TODO: Afficher pub vidéo
        // TODO: Détecter si pub vue
        GetExtraTime();
    }

    public void GetExtraTime()
    {
        // 5 secondes bonus + 1 seconde / niveau de temps
        timerVal = 5 + PlayerPrefs.GetInt("timeLevel", 1);
        textTimer.text = timerVal.ToString();
        InvokeRepeating("SetTimer", 1, 1);
        gameEnded = false;
        screenEnd.SetActive(false);
    }
}
