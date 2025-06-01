using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{ 
    public Image stunImage;
    public Image presentCooltimeMask;
    public Image presentSkillImage;

    private int PresentCount = 0;
    private float presentCoolTime = 8f;
    private float lastpresentTime = -999;

    private bool isCoolTime = false;
    private bool StunUsed = false;

    
    
    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) && !StunUsed)
        { 
            HungryGuage hg = FindObjectOfType<HungryGuage>();
            if (hg != null)
            {
                hg.PauseForSeconds(20.0f);
                StunUsed = true;

                if (stunImage != null)
                {
                    stunImage.color = new Color(167/ 255f, 167/ 255f, 167/ 255f);
                }
            }
        }


        if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && PresentCount < 2 && !isCoolTime)
        {
            HungryGuage hg = FindObjectOfType<HungryGuage>();
            if (hg != null)
            {
                hg.AddTime(10f);
                PresentCount++;
                lastpresentTime = Time.time;

                if (PresentCount < 2)
                {
                    isCoolTime = true;
                    presentCooltimeMask.fillAmount = 1f;
                    presentCooltimeMask.gameObject.SetActive(true);
                }
                else
                {
                    presentSkillImage.color = new Color(167 / 255f, 167 / 255f, 167 / 255f);
                    presentCooltimeMask.gameObject.SetActive(false);
                }
            }
        }

        if (isCoolTime)
        {
            float timePassed = Time.time - lastpresentTime;
            float ratio = 1f - (timePassed / presentCoolTime);
            presentCooltimeMask.fillAmount = Mathf.Clamp01(ratio);

            if (timePassed >= presentCoolTime)
            {
                isCoolTime = false;
                presentSkillImage.color = Color.white;
                presentCooltimeMask.gameObject.SetActive(false) ;
            }
        }
    }
}

 
