using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Setting;
    public GameObject SkillPopup;
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
}
