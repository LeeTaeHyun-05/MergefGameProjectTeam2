using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    public GameObject[] flowerPrefabs;
    public float spawnY = 8f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private GameObject currentFlower;
    private bool isDropping = false;
    private bool isSpawning = false;

    private void Update()
    {
        if (currentFlower == null && !isDropping && !isSpawning)
        {
            StartCoroutine(SpawnFlowerAfterDelay(0.5f));
        }

        if (currentFlower != null && !isDropping)
        {
            MoveFlowerWithMouse();

            if (Input.GetMouseButtonDown(0))
            {
                DropFlower();
            }
        }
    }

    private IEnumerator SpawnFlowerAfterDelay (float delay)
    {
        isSpawning = true;  

        yield return new WaitForSeconds(delay);

        SpawnFlowerAtMouseX();

        isSpawning = false ;
    }

    void SpawnFlowerAtMouseX()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnPosition = new Vector3(mouseWorldPos.x, spawnY, 0f);
        float clampedX = Mathf.Clamp(mouseWorldPos.x, minX, maxX);

        currentFlower = Instantiate(flowerPrefabs[0], spawnPosition, Quaternion.identity);

        Rigidbody2D rb = currentFlower.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = false;
        }

        
    }

    void MoveFlowerWithMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float clampedX = Mathf.Clamp(mouseWorldPos.x, minX, maxX);
        Vector3 newPosition = new Vector3(clampedX, spawnY, 0f);

        currentFlower.transform.position = newPosition;
    }

    void DropFlower()
    {
        isDropping = true;

        Rigidbody2D rb = currentFlower.GetComponent<Rigidbody2D> ();
        if (rb != null)
        {
            rb.simulated = true;
        }

        currentFlower = null;
        isDropping = false;
    }
}
