using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMerge : MonoBehaviour
{

    public FlowerType flowerType;

    private bool isMerging = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMerging) return;

        FlowerMerge otherFlower = collision.gameObject.GetComponent<FlowerMerge>();

        if (otherFlower != null && otherFlower.flowerType == flowerType && !otherFlower.isMerging)
        {
            StartCoroutine(MergeWith(otherFlower));
        }
    }

    private IEnumerator MergeWith(FlowerMerge other)
    {
        isMerging = true;
        other.isMerging = true;

        yield return new WaitForSeconds(0.1f);

        Vector3 mergePosition = (transform.position + other.transform.position) / 2f;

        Destroy(gameObject);
        Destroy(other.gameObject);

        FlowerType nextType = GetNextFlowerType(flowerType);
        if (nextType != flowerType)
        {
            FlowerManager.Instance.spawnFlower(nextType, mergePosition);
        }
    }
    private FlowerType GetNextFlowerType(FlowerType type)
    {
        int next = (int)type + 1;
        if (next >= System.Enum.GetValues(typeof(FlowerType)).Length)
        {
            return type;
        }
        return (FlowerType)next;
    }

    
}
