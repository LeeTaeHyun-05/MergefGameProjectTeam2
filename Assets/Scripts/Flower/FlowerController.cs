
using System.Collections;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    public FlowerType spawnType = FlowerType.Level1;
    public Camera mainCamera;
    public float spawnY = 8f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private GameObject currentFlower;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnNewFlowerWithDelay(0f)); // 시작하자마자 생성
    }

    void Update()
    {
        if (currentFlower != null)
        {
            MoveFlowerWithMouse();

            if (Input.GetMouseButtonDown(0))
            {
                DropFlower();
            }
        }
    }

    void MoveFlowerWithMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z); // Z 보정

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);

        currentFlower.transform.position = new Vector3(clampedX, spawnY, 0f);
    }

    void DropFlower()
    {
        if (currentFlower != null)
        {
            Rigidbody2D rb = currentFlower.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
            currentFlower = null;

            StartCoroutine(SpawnNewFlowerWithDelay(0.7f)); // 0.7초 후 새로 생성
        }
    }

    IEnumerator SpawnNewFlowerWithDelay(float delay)
    {
        if (isSpawning) yield break;
        isSpawning = true;

        yield return new WaitForSeconds(delay);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z); // Z 보정

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);
        Vector3 spawnPosition = new Vector3(clampedX, spawnY, 0f);

        currentFlower = FlowerManager.Instance.SpawnFlower(spawnType, spawnPosition);

        isSpawning = false;
    }
}
