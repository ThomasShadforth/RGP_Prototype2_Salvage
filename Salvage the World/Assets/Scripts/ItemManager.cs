using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //Will attach itemManager as an empty below the gamemanager
    //Ensures it remains within the same objects will keeping values, methods and so on separate

    public string[] items;
    public int[] itemNumbers;
    //reserve for object array
    //public gameObject[] inGameObjects

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                //itemNumbers[i] += itemNum;
            } else if(items[i] == null)
            {
                items[i] = itemName;
                itemNumbers[i] += numToAdd;
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
                    items[i] = null;
                    //Rearrange inventory (Find a method to shift items up)
                }
            }
        }
    }

    public void shiftItems()
    {
        for(int i = 0; i < items.Length; i++)
        {

        }
    }
}
