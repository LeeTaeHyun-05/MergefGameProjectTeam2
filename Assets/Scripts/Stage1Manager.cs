using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
{
    public GameObject Clear;
    private Quota quota;

    private bool isCleared = false;
    // Start is called before the first frame update
    void Start()
    {
        quota = FindObjectOfType<Quota>();
        if (quota == null)
        {
            Debug.Log("Quota�� ã�� �� �����ϴ�");
        }

        Clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCleared || quota == null) return;

        if (quota.IsFull())
        {
            isCleared = true;
            Clear.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Stage1 Ŭ����");
        }
    }
}
