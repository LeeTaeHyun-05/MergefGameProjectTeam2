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
            FlowerType nextType = flowerType + 1;

            GameObject merged = FlowerManager.Instance.SpawnMergedFlower(nextType, mergePosition);

            if (nextType == FlowerType.Level5)
            {
                Quota.Instance.AddHoneyProgress();
                Destroy(merged, 0.5f);
            }
        }

        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
