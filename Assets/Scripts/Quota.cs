using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quota : MonoBehaviour
{
    private Slider slider;
    public static Quota Instance;

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
}
