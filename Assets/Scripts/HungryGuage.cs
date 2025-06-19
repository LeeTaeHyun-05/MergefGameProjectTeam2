using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class HungryGuage : MonoBehaviour
{
    private Slider slTimer;
    private Quota quota;

    private float timerMax;
    private bool isRunning = true;

    private bool isPaused = false;
    private float resumeTime = 0f;
    private IStageManager stageManager;


    void Start()
    {
        slTimer = GetComponent<Slider>();
        timerMax = slTimer.maxValue;
        slTimer.value = timerMax;   

        quota = Quota.Instance;
        stageManager = FindObjectOfType<MonoBehaviour>() as IStageManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (slTimer == null || quota == null) return;

        if (isPaused)
        {
            if (Time.time >= resumeTime)
            {
                isPaused = false;
                isRunning = true;
            }
            else
            {
                return;
            }
        }


        if (!isRunning) return;


        if (slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime;
        }
        else
        { 
            quota.DecreaseQuota();
            slTimer.value = timerMax;
            
            if (quota.GetValue() <0)
            {
                stageManager?.TriggerDefeat();
                isRunning = false;
            }
        }
    }
    public void PauseForSeconds(float seconds)
    {
        if (isPaused) return;

        isPaused = true;
        isRunning = false;
        resumeTime = Time.time + seconds;
    }

    public void AddTime(float seconds)
    {
        if (slTimer == null) return;

        slTimer.value += seconds;

        if (slTimer.value > slTimer.maxValue)
        {
            slTimer.value = slTimer.maxValue;
        }
    }
}
