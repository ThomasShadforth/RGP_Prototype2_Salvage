using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    CraftedItem currentItem;
    bool canCraft;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectItemToCraft(int selectIndex)
    {
        currentItem = GameManager.instance.itemManagerDB.itemDatabase[selectIndex];
        Debug.Log("ITEM SELECTED");
    }

    public void craft()
    {
        canCraft = true;
        for(int i = 0; i < currentItem.requiredMaterials.Length; i++)
        {
            for(int j = 0; j < GameManager.instance.itemManagerDB.items.Length; j++)
            {
                
            }
        }
    }
}
