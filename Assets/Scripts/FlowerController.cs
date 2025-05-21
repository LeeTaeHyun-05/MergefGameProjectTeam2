
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
    private bool isDropped = false;
  


    void Update()
    {
        if (currentFlower == null && Input.GetMouseButtonDown(0))
        {
            SpawnNewFlower();
        }

        if (currentFlower != null)
        {
            MoveFlowerWithMouse();

            if (Input.GetMouseButtonDown(0))
            {
                DropFlower();
            }
        }
    }
    void SpawnNewFlower()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        float clampedX = Mathf.Clamp(worldPos.x, minX, maxX);

        Vector3 spawnPosition = new Vector3(clampedX, spawnY, 0);
        currentFlower = FlowerManager.Instance.SpawnFlower(spawnType, spawnPosition);
    }

    void MoveFlowerWithMouse()
    {
        Vector3 mousePos = Input.mousePosition;
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
        }
    }

   
}
