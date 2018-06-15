using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EventController : MonoBehaviour {

    [SerializeField]
    public Image menu;
    [SerializeField]
    public Image instruction;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GlobalControl.isPaused == false) ShowMenu();
            HideMenu();
        }
    }
    public void OnPlayButtonClick()
    {
        SceneController.LoadScene("Stage2");
    }
    public void OnScoresButtonClick()
    {
        
    }
    public void OnSettingsButtonClick()
    {
        
    }

    public void OnStage1ButtonClick()
    {
        SceneController.LoadScene("Stage1");
    }

    public void BackToMenuScene()
    {
        SceneController.BackToMenuScene();
    }
    public void ReloadScene()
    {
        SceneController.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        Time.timeScale = 0;
        GlobalControl.isPaused = true;
    }
    public void HideMenu()
    {
        menu.gameObject.SetActive(false);
        Time.timeScale = 1;
        GlobalControl.isPaused = false;
    }

    public void HideInstruction()
    {
        instruction.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
