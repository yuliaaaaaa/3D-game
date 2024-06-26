using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject game_over; 
    public GameObject cells;

    private void Start()
    {
        Time.timeScale = 1;
    }
    
    public void StartGame()
    {

        SceneManager.LoadScene(1);

    }

    public void GameOver()
    {
        game_over.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        // Виходить з гри
        Application.Quit();

#if UNITY_EDITOR
        // Цей блок коду для відлагодження в редакторі Unity - при збірці ігноруватиметься
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OpenInventory()
    {
        cells.SetActive(!cells.activeSelf);
    }
}
