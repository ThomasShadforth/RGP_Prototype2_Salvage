using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //Will attach itemManager as an empty below the gamemanager
    //Ensures it remains within the same objects while keeping values, methods and so on separate

    //Stores the item names and the corresponding item quantities
    [Header("Item Inventory")]
    public string[] items;
    public int[] itemNumbers;

    //Used to store the crafted items the player can use to explore the world
    [Header("Item Hotbar")]
    public CraftedItem[] itemHotbar;
    public CraftedItem selectedItem;

    //Stores a list of the items the player can make
    [Header("Item Databases")]
    public CraftedItem[] itemDatabase;
    public string[] materialDatabase;
    public string[] materialDescriptions;
    public Sprite[] materialSprites;

    [Header("TEST: Mouse Scroll Val")]
    public int currentItemIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkWheelScroll();
    }

    public void addItem(string itemName, int numToAdd)
    {
        //Later, nest inside a for loop that checks if the object name
        //matches a registered object, if it does, carry out the remaining steps,
        //if not, then return an error message
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == itemName)
            {
                if(itemNumbers[i] == 19)
                {
                    itemNumbers[i] += 1;
                    numToAdd -= 1;

                    for(int j = 0; j < items.Length; j++)
                    {
                        if(items[j] == null)
                        {
                            items[j] = itemName;
                            itemNumbers[j] += numToAdd;
                            break;
                        }
                    }
                }
                else
                {
                    itemNumbers[i] += numToAdd;
                    break;
                }
                //itemNumbers[i] += itemNum;
            } else if(items[i] == "")
            {
                
                items[i] = itemName;
                itemNumbers[i] += numToAdd;
                break;
            }
        }
    }

    public void removeItem(string itemName, int numToRemove)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] == itemName)
            {
                itemNumbers[i] -= numToRemove;
                if(itemNumbers[i] <= 0)
                {
                    items[i] = "";
                    shiftItems();
                    //Rearrange inventory (Find a method to shift items up)
                }
            }
        }
    }

    //Method that is executed after successfully crafting an item
    
    //After an item reaches 0 or negative durability, destroy it
    public void destroyTool(CraftedItem toolToDestroy)
    {
        for(int i = 0; i < itemHotbar.Length; i++)
        {
            if(itemHotbar[i] == toolToDestroy && itemHotbar[i].durability <= 0)
            {

            }
        }
    }

    //Executed when an item is removed from the inventory, or when the inventory is opened
    //Ensures that the inventory items are kept grouped together
    public void shiftItems()
    {
        bool itemAfterSpace = true;

        while (itemAfterSpace)
        {
            itemAfterSpace = false;
            for (int i = 0; i < items.Length - 1; i++)
            {
                if(items[i] == "")
                {
                    items[i] = items[i + 1];
                    items[i + 1] = "";

                    itemNumbers[i] = itemNumbers[i + 1];
                    itemNumbers[i + 1] = 0;

                    if(items[i] != "")
                    {
                        itemAfterSpace = true;
                    }
                }
            }
        }
        
    }

    public void createCraftedItem(string nameOfItem)
    {
        for(int i = 0; i < itemDatabase.Length; i++)
        {
            if(itemDatabase[i].ItemName == nameOfItem)
            {
                CraftedItem itemToCreate = itemDatabase[i];
                checkItemHotbar(false, itemToCreate);
            }
        }
    }

    public void checkItemHotbar(bool willDestroy, CraftedItem item)
    {
        if (!willDestroy)
        {
            for(int i = 0; i < itemHotbar.Length; i++)
            {
                if(itemHotbar[i] != null)
                {
                    continue;
                }
                else
                {
                    itemHotbar[i] = Instantiate(item);
                    selectedItem = itemHotbar[i];
                    currentItemIndex = i;
                    break;
                }
            }
        }
        else
        {

        }
    }

    public void checkWheelScroll()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0)
        {

            if(Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                
                currentItemIndex += 1;
                if(currentItemIndex > 9)
                {
                    currentItemIndex = 0;
                }
            } else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                
                currentItemIndex -= 1;
                if(currentItemIndex < 0)
                {
                    currentItemIndex = 9;
                }
            }
            if (itemHotbar[currentItemIndex] != null)
            {
                selectedItem = itemHotbar[currentItemIndex];
            }
            else
            {
                selectedItem = null;
            }
        }
    }

    public Sprite getInventorySprite(string materialName)
    {
        for(int i = 0; i < materialSprites.Length; i++)
        {
            if(materialSprites[i].name == materialName)
            {
                return materialSprites[i];
                
            }
        }

        return null;
    }

    public Sprite getCraftedItemSprite(int referenceIndex)
    {
        for(int i = 0; i < itemDatabase.Length; i++)
        {
            if(i == referenceIndex)
            {
                Debug.Log("FOUND ITEM");
                return itemDatabase[i].GetComponent<SpriteRenderer>().sprite;
            }
        }


        Debug.Log("COULDNT FIND");
        return null;
    }
}
