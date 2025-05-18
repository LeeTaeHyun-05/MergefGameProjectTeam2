using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public int flowertype;
    public bool isMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isMerged)
            return;
        
        Flower otherFlower = collision.gameObject.GetComponent<Flower>();

        if (otherFlower != null && !otherFlower.isMerged && otherFlower.flowertype == flowertype)
        {
            isMerged = true;
            otherFlower.isMerged = true;

            Vector3 mergePosition = (transform.position + otherFlower.transform.position) / 2f;

            FlowerGame gamemanager = FindObjectOfType<FlowerGame>();
            if (gamemanager != null)
            {
                gamemanager.MergeFlowers(flowertype, mergePosition);


                Destroy(gameObject);
                Destroy(otherFlower.gameObject);
            }

        }
    }
   
   
}
