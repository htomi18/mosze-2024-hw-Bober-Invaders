using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public int highestScore;
    public TMP_Text scoreText;  //Ezzel jelöljük a játékban azt az objektumot, amely a pontokat jeleníti meg
    public TMP_Text highScoreText;
    void Start()
    {
        scoreText.text = "Score: " + score;  //A játék kezdetekor meghívjuk, hogy alapértelmezetten 0 legyen a megjelenített pont
        
    }
    
    public void UpdateScore(int points)  //Ezzel a pontjainkat frissítjük folyamatosan, azt figyeljük, hogy löttünk-e ki ellenséget
    {
        score += points;  //A score-hoz hozzáadjuk a megszerzett pontot
        
        scoreText.text = "Score: " + score;  //Kiiratjuk a megszerzett pontot a megfelelő formában

    }

    public void HighScoreUpdate(int points)
    {  
        highestScore += points;
        highScoreText.text = "Highest Score: " + highestScore; 
    }
}
