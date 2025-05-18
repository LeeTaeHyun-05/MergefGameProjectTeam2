using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class FlowerGame : MonoBehaviour
{
    public GameObject[] flowerPrefabs;
    public float[] flowerSizes = { 0.5f, 0.9f, 1.3f, 1.7f, 1.9f };
    public GameObject currentFlower;
    public int currentFlowerType;
    public float flowerStartHeight = 6f;
    public float gameWidth = 5f;
    public bool isGameOver = false;
    public Camera mainCamera;
    public float flowerTimer;
    public float gameHeight;
    public float minX = -3.0f;
    public float maxX = 6.2f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SpawnNewFlower();
        flowerTimer = -3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        if ((flowerTimer >= 0))
            flowerTimer -= Time.deltaTime;  

        if (flowerTimer < 0 && flowerTimer > -2)
        {
            
            SpawnNewFlower();
            flowerTimer = -3.0f;
        }

        if (currentFlower != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);

            Vector3 newPosition = currentFlower.transform.position;
            newPosition.x = worldPosition.x;

            float halfFlowerSize = flowerSizes[currentFlowerType] / 2f;
            if (newPosition.x < -gameWidth / 2 + halfFlowerSize)
            {
                newPosition.x = -gameWidth / 2 + halfFlowerSize;
            }
            if (newPosition.x > gameWidth / 2 - halfFlowerSize)
            {
                newPosition.x = gameWidth / 2 - halfFlowerSize;
            }
            currentFlower.transform.position = newPosition;
        }

        if(Input.GetMouseButtonDown(0) && flowerTimer == -3.0f)
        {
            DropFlower();
        }

    }



    public void MergeFlowers(int flowerType , Vector3 position)
    {
        if(flowerType < flowerPrefabs.Length -1)
        {
            GameObject newFlower = Instantiate(flowerPrefabs[flowerType +1] , position, Quaternion.identity);

            newFlower.transform.localScale = new Vector3(flowerSizes[flowerType + 1], flowerSizes[flowerType + 1], 1.0f);
        }
            
    }

    void SpawnNewFlower()
    {
        if (!isGameOver)
        {
            currentFlowerType = 0;

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            Vector3 spawnPosition = new Vector3(worldPosition.x, flowerStartHeight, 0);

            float halfFlowerSize = flowerSizes[currentFlowerType] / 2f;
            spawnPosition.x = Mathf.Clamp(spawnPosition.x, minX + halfFlowerSize, maxX - halfFlowerSize);

            currentFlower = Instantiate(flowerPrefabs[currentFlowerType], spawnPosition, Quaternion.identity);

            currentFlower.transform.localScale = new Vector3(flowerSizes[currentFlowerType], flowerSizes[currentFlowerType], 1f);

            Rigidbody2D rb = currentFlower.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0f;
            } 
                
        }
    }

    void DropFlower()
    {
        Rigidbody2D rb = currentFlower.GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            rb.gravityScale = 1f;
            currentFlower = null;
            flowerTimer = 1.0f;
        }
    }    
}

