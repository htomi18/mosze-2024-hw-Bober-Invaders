using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    
    public static SceneController isntance;
    public GameObject gameOverUI;

    [SerializeField] Animator transitionAnim;
    private void Awake()
    {
        if (isntance == null)
        {
            isntance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
    
    public void NextLevel()
    {
        StartCoroutine(LoadLevel()); 
    }

    IEnumerator LoadLevel()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        transitionAnim.SetTrigger("Start");
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Bober_Invaders_Main_Menu");
    }

    public void exit()
    {
        
        Debug.Log("Exit Game, have a nice Day lad!");
        Application.Quit();
    }

    
}
