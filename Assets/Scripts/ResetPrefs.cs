using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
    public void ResetAllStageProgress()
    {
        PlayerPrefs.DeleteKey("Stage2Clear");
        PlayerPrefs.DeleteKey("Stage1Clear");
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs 초기화 완료");
    }
}
