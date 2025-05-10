using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager Instance;   

    [Header("과일 프리팹 배열")]   
    public GameObject[] flowerPrefabs;

    private void Awake()
    {
        Instance = this;
    }

    
    public void MergeFlower(GameObject flowerA, GameObject flowerB)
    {
        FlowerMerge flowerScript = flowerA.GetComponent<FlowerMerge>();
        FlowerType currentType = flowerScript.flowerType;

        FlowerType nextType = GetNextFlowerType(currentType);

        if (nextType == FlowerType.None)
        {
            return;
        }

        Vector3 createPosition = (flowerA.transform.position +  flowerB.transform.position) / 2f;
        createPosition.y += 0.2f;

        GameObject newFlower = Instantiate(flowerPrefabs[(int)nextType], createPosition, Quaternion.identity);

        Rigidbody2D rb = newFlower.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
            rb.isKinematic = false;
            rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f), -2f);
            rb.angularVelocity = Random.Range(-50f, 50f);

            Destroy(flowerA);
            Destroy(flowerB);
        }    
    }

    private FlowerType GetNextFlowerType(FlowerType current)
    {
        int nextIndex = (int)current + 1;

        if (nextIndex < flowerPrefabs.Length)
        {
            return (FlowerType)nextIndex;
        }
        return FlowerType.None;
    }


}
