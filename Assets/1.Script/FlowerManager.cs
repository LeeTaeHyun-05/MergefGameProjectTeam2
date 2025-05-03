using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager Instance;

    public GameObject[] flowerPrefabs;

    private void Awake()
    {
        Instance = this;
    }

    public void spawnFlower(FlowerType type, Vector3 position)
    {
        int index = (int)type;
        if (index >= 0 && index < flowerPrefabs.Length)
        {
            Instantiate(flowerPrefabs[index], position, Quaternion.identity);
        }
    }
}
