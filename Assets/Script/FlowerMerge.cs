using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerMerge : MonoBehaviour
{

    public FlowerType flowerType;

    private bool isMerging = false;

    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMerging) return;

        FlowerMerge otherFlower = collision.gameObject.GetComponent<FlowerMerge>();

        if (otherFlower != null && !otherFlower.isMerging && otherFlower.flowerType == this.flowerType)
        {
            isMerging = true;
            otherFlower.isMerging = true;

            FlowerManager.Instance.MergeFlower(this.gameObject, otherFlower.gameObject);    
        }
    }

   
}
