using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftedItem : MonoBehaviour
{
    public bool isCrude;
    public bool isPassable;
    public bool isDurable;

    public int maxDurability;
    int durability;

    public CraftingRequirements[] requiredMaterials;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
