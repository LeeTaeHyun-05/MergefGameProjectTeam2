using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{

    public static FlowerManager Instance;

    [Header("과일 프리팹 배열")]
    public GameObject[] flowerPrefabs;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnMergedFlower(FlowerType type, Vector3 position)
    {
        GameObject fruit = Instantiate(flowerPrefabs[(int)type], position, Quaternion.identity);
        fruit.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

    public GameObject SpawnFlower(FlowerType type, Vector3 position)
    {
        GameObject flower = Instantiate(flowerPrefabs[(int)type], position, Quaternion.identity);
        flower.GetComponent<Rigidbody2D>().gravityScale = 0f; 
        return flower;
    }
}
