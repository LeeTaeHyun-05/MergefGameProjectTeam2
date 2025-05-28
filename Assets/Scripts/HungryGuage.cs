using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HungryGuage : MonoBehaviour
{
    Slider slTimer;
    float fSliderBarTime;

    void Start()
    {
        slTimer = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slTimer.value > 0.0f)
        {
            slTimer.value -= Time.deltaTime;
        }
        else
        {
            slTimer.value = float.MaxValue;
        }
        //else if (할당량이 1이상이라면)
        
    }
}
