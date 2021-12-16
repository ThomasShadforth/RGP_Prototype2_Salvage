using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftedItem : MonoBehaviour
{
    [Header("Name")]
    public string ItemName;

    [Header("Item Grade Flags")]
    public bool isCrude;
    public bool isPassable;
    public bool isDurable;

    [Header("Item Type Flags")]
    public bool isAxe;
    public bool isPickaxe;
    public bool isShovel;

    [Header("Durability & Efficiency")]
    public float maxDurability;
    public float durability;
    public float efficiency;

    public CraftingRequirements[] requiredMaterials;
    void Start()
    {
        durability = maxDurability;
        gameObject.SetActive(false);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
