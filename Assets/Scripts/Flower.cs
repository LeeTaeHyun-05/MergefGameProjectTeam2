using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public FlowerType flowerType;
    public bool isMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMerged)
            return;

        Flower other = collision.gameObject.GetComponent<Flower>();

        if (other != null && !other.isMerged && other.flowerType == this.flowerType)
        {
            isMerged = true;
            MergeWith(other);
        }
    }
    
    private void MergeWith(Flower other)
    {
        Vector3 mergePosition = (transform.position + other.transform.position) / 2f;

        if ((int)flowerType + 1 < System.Enum.GetValues(typeof(FlowerType)).Length)
        {
            FlowerManager.Instance.SpawnMergedFlower(flowerType + 1, mergePosition);
        }

        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
