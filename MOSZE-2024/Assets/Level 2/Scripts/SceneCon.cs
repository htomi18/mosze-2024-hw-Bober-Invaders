using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCon : MonoBehaviour
{
    public GameObject winUI;
    public static SceneCon isntance;
    public void win()
    {
        winUI.SetActive(true);
    }
    public void endGame()
    {
        SceneManager.LoadScene("Outro");
    }
}