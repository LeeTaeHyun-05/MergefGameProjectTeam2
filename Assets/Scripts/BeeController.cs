using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    [Header("�̵� ���� ����")]
    public float minX = -2.5f;
    public float maxX = 2.5f;

    [Header("���� Y ��ġ")]
    public float fixedY = -3.5f; 

    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float clampedX = Mathf.Clamp(mouseWorldPos.x, minX, maxX);

        transform.position = new Vector3(clampedX, fixedY, transform.position.z);
    }
}
