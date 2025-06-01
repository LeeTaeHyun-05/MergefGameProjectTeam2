using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class HungryGuage : MonoBehaviour
{
    private Slider slTimer;
    private Quota quota;

    private float timerMax = 40f;
    private bool isRunning = true;

    private bool isPaused = false;
    private float resumeTime = 0f;


    void Start()
    {
        slTimer = GetComponent<Slider>();
        if (slTimer == null )
        {
            return;
        }
        slTimer.maxValue = timerMax;
        slTimer.value = timerMax;   

        quota = Quota.Instance;
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
            if(quota.GetValue() >= 1)
            {
                quota.DecreaseQuota();
                slTimer.value = timerMax;
            }
            else
            {
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
