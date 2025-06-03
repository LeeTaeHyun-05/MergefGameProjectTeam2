using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject Setting;
    public GameObject SkillPopup;
    public GameObject Stage1Target;
    public GameObject Stage2Target;
    public GameObject Stage3Target;
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

    public void Stage1_TargetOpen()
    {
        Stage1Target.SetActive(true); 
    }

    public void Stage1_TargetQuit()
    {
        Stage1Target.SetActive(false );
    }    

    public void Stage1_Start()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2_TargetOpen()
    {
        Stage2Target.SetActive(true);
    }

    public void Stage2_TargetQuit()
    {
        Stage2Target.SetActive(false);
    }

    public void Stage2_Start()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3_TargetOpen()
    {
        Stage3Target.SetActive(true);   
    }

    public void Stage3_TargetQuit()
    {
        Stage3Target.SetActive(false);  
    }

    public void Stage3_Start()
    {
        SceneManager.LoadScene("Stage3");
    }
}
