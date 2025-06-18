using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

    [Header("�������� ��ư")]
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;

    private bool isPaused = false;

    [Header("�ر� �ȳ� UI")]
    public GameObject unlockNoticeUI;
    public TMP_Text unlockNoticeText;

    [Header("�������� �˾� UI")]
    public GameObject stage2Popup;
    public GameObject stage3Popup;

    private Coroutine autoHideCoroutine;

    void Start()
    { 

        if (stage1Button != null)
        {
            stage1Button.interactable = true;
        }

        if (stage2Button != null)
        {
            stage2Button.interactable = true;
        }

        if (stage3Button != null)
        {
            stage3Button.interactable = true;
        }

        if (unlockNoticeUI != null)
        {
            unlockNoticeUI.SetActive(false);
        }
    }

    public void OnStageButtonClicked(int stageIndex)
    {
        int clear1 = PlayerPrefs.GetInt("Stage1Clear", 0);
        int clear2 = PlayerPrefs.GetInt("Stage2Clear", 0);

        switch (stageIndex)
        {
            case 1:
                Stage1.SetActive(true);
                break;

            case 2:
                if (clear1 == 1)
                {  
                    ShowOnlyPopup(stage2Popup);
                }
                else
                { 
                    ShowUnlockNotice("�������� 1 Ŭ���� �� �رݵ˴ϴ�.");
                }
                break;

            case 3:
                if (clear2 == 1)
                {
                    ShowOnlyPopup(stage3Popup);
                }
                else
                {
                    ShowUnlockNotice("�������� 2 Ŭ���� �� �رݵ˴ϴ�.");
                }
                break;
        }
    }
    private void ShowOnlyPopup(GameObject popup)
    {
        if (unlockNoticeUI != null) unlockNoticeUI.SetActive(false);
        if (stage2Popup != null) stage2Popup.SetActive(false);
        if (stage3Popup != null) stage3Popup.SetActive(false);

        if (popup != null) popup.SetActive(true);
    }
    private void ShowUnlockNotice(string message)
    {
        if (unlockNoticeText != null)
            unlockNoticeText.text = message;

        if (unlockNoticeUI != null)
            unlockNoticeUI.SetActive(true);

        if (autoHideCoroutine != null)
            StopCoroutine(autoHideCoroutine);

        autoHideCoroutine = StartCoroutine(AutoHideUnlockUI());
    }
    private IEnumerator AutoHideUnlockUI()
    {
        yield return new WaitForSeconds(2f);

        if (unlockNoticeUI != null)
            unlockNoticeUI.SetActive(false);

        autoHideCoroutine = null;
    }
    public void CloseUnlockNotice()
    {
        if (unlockNoticeUI != null)
            unlockNoticeUI.SetActive(false);

        if (autoHideCoroutine != null)
        {
            StopCoroutine(autoHideCoroutine);
            autoHideCoroutine = null;
        }
    }

    public void SetStageCleared(int stageIndex)
    {
        PlayerPrefs.SetInt($"Stage{stageIndex}Clear", 1);
        PlayerPrefs.Save();
    }
    public void Pause()
    {
        isPaused = !isPaused;

        SettingsPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        Debug.Log(isPaused ? "���� �Ͻ�����" : "���� �簳");
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
        Debug.Log("������ ���������� ����Ǿ����ϴ�");
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

    public void Stage1Quit()
    {
        Stage1.SetActive(false);
    }

    

    public void Stage2Quit()
    {
        Stage2.SetActive(false);
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

    public void ClearStage1()
    {
        PlayerPrefs.SetInt("Stage1Clear", 1); 
        PlayerPrefs.Save();                   
    }
    public void ClearStage2()
    {
        PlayerPrefs.SetInt("Stage2Clear", 1);
        PlayerPrefs.Save();
    }
}
