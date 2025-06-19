using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Quota : MonoBehaviour
{
    public static Quota Instance;
    [Header("�Ҵ緮")]
    public int maxQuota = 4;

    private int currentQuota;
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
        currentQuota = 0;

        slider.maxValue = maxQuota;
        slider.value = currentQuota;
    }

    public void AddHoneyProgress()
    {
        if (currentQuota < maxQuota)
        {
            currentQuota++;
            slider.value = currentQuota;
        }
    }

    public int GetValue()
    {
        return currentQuota;
    }

    public void DecreaseQuota()
    {
        currentQuota--;
        slider.value = currentQuota;
    }

    public bool IsFull()
    {
        return currentQuota >= maxQuota;
    }

    public bool ISMinus()
    {
        return currentQuota < 0;
    }

    
}
