using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage3Manager : MonoBehaviour, IStageManager
{
    public GameObject ClearUI;
    public GameObject DefeatUI;
    private Quota quota;

    private bool isCleared = false;
    // Start is called before the first frame update
    void Start()
    {
        quota = FindObjectOfType<Quota>();
        if (quota == null)
        {
            Debug.Log("Quota를 찾을 수 없습니다");
        }

        if(ClearUI != null) ClearUI.SetActive(false);
        if (DefeatUI != null) DefeatUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCleared || quota == null) return;

        if (quota.IsFull())
        {
            TriggerClear();
        }
        
        if (quota.ISMinus())
        {
            TriggerDefeat();
        }
    }
    private void TriggerClear()
    {
        isCleared = true;
        if (ClearUI != null) ClearUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TriggerDefeat()
    {
        if (isCleared) return;

        isCleared = true;
        if (DefeatUI != null) DefeatUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
