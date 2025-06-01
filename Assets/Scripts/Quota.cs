using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quota : MonoBehaviour
{
    public static Quota Instance;
    private Slider slider;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = 4;
        slider.value = 0;   
    }

    public void AddHoneyProgress()
    {
        if (slider.value < slider.maxValue)
        {
            slider.value += 1;
        }
    }

    public int GetValue()
    {
        return (int)slider.value;
    }

    public void DecreaseQuota()
    {
        if (slider.value >= 1)
        {
            slider.value -= 1;
        }
    }
}
