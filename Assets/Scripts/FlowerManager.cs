using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{

    public static FlowerManager Instance;

    [Header("²É ¼ø¼­ ¹è¿­")]
    public GameObject[] flowerPrefabs;

    [Header("²É Å©±â ¹è¿­")]
    public float[] flowerSizes = { 0.29f, 0.42f, 0.61f, 0.89f, 1.29f };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnMergedFlower(FlowerType type, Vector3 position)
    {
        GameObject flower = Instantiate(flowerPrefabs[(int)type], position, Quaternion.identity);

        float scale = flowerSizes[(int)type];
        flower.transform.localScale = new Vector3(scale, scale, 1f);

        flower.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }

    public GameObject SpawnFlower(FlowerType type, Vector3 position)
    {
        GameObject flower = Instantiate(flowerPrefabs[(int)type], position, Quaternion.identity);

        float scale = flowerSizes[(int)type];
        flower.transform.localScale = new Vector3(scale, scale, 1f);

        flower.GetComponent<Rigidbody2D>().gravityScale = 0f; 
        return flower;
    }
}
