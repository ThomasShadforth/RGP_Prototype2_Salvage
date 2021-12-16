using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool needsAxe;
    public bool needsPickaxe;
    public bool needsShovel;

    public int requiredHits;
    [SerializeField]
    float hitNum;

    void Start()
    {
        hitNum = requiredHits;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceHitCount(float hitEfficiency)
    {
        hitNum -= hitEfficiency;

        if(hitNum <= 0)
        {
            Invoke("destroyObject", 1.5f);
        }
    }

    public void destroyObject()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            PlayerBase.instance.obstacleInRange = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            PlayerBase.instance.obstacleInRange = null;
        }
    }
}
