using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Setting;
    public GameObject SkillPopup;
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject SettingsPanel;
    public GameObject RestartInGame;
    public GameObject Defeat;

    private bool isPaused = false;

   
    public void Pause()
    {
        isPaused = !isPaused;

        SettingsPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        Debug.Log(isPaused ? "게임 일시정지" : "게임 재개");
    }

    public void OpenSettings()
    {
        isPaused = true;
        SettingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSettings()
    {
        isPaused = false;
        SettingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GameStart()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameEnd()
    {
        Application.Quit();
        Debug.Log("게임이 정상적으로 종료되었습니다");
    }

    public void MenuOpen()
    {
        Setting.SetActive(true);
    }

    public void MenuQuit()
    {
        Setting.SetActive(false);
    }

    public void SkillOpen()
    {
        SkillPopup.SetActive(true);
    }    

    public void SkillQuit()
    {
        SkillPopup.SetActive(false);
    }

    public void ToStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Stage1Open()
    {
        Stage1.SetActive(true);
    }

    public void Stage1Quit()
    {
        Stage1.SetActive(false);
    }

    public void Stage2Open()
    {
        Stage2.SetActive(true);
    }

    public void Stage2Quit()
    {
        Stage2.SetActive(false);
    }

    public void Stage3Open()
    {
        Stage3.SetActive(true);
    }

    public void Stage3Quit()
    {
        Stage3.SetActive(false);
    }
    
    public void Stage1Start()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2Start()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3Start()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartIngameOpen()
    {
        RestartInGame.SetActive(true);
    }

    public void RestartIngameQuit()
    {
        RestartInGame.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void DefeatGame()
    {
        Defeat.SetActive(true);
    }
}
