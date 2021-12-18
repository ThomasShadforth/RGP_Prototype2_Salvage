using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingMenu : MonoBehaviour
{
    CraftedItem currentItem;
    bool canCraft;
    int currentIndex;

    public static CraftingMenu instance;
    void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectItemToCraft(int selectIndex)
    {
        currentItem = GameManager.instance.itemManagerDB.itemDatabase[selectIndex];
        currentIndex = selectIndex;
        MenuSystem.instance.selectedCraftItem.text = currentItem.name;
        MenuSystem.instance.craftItemDescription.text = "";
        MenuSystem.instance.craftItemDur.text = "Durability: " + currentItem.durability;
        //MenuSystem.instance.craftItemMaterials.text = currentItem.requiredMaterials[]
        MenuSystem.instance.craftItemMaterials.text = "";
        for(int i = 0; i < currentItem.requiredMaterials.Length; i++)
        {
            MenuSystem.instance.craftItemMaterials.text = MenuSystem.instance.craftItemMaterials.text + currentItem.requiredMaterials[i].RequiredMaterialName + " x " + currentItem.requiredMaterials[i].RequiredMaterialNumber + "\n";
        }

        MenuSystem.instance.craftingButton.interactable = CheckCraft();

        if (MenuSystem.instance.craftingButton.interactable == false)
        {
            MenuSystem.instance.craftingButton.image.color = Color.red;
            
        }
        else
        {
            MenuSystem.instance.craftingButton.image.color = Color.white;
            MenuSystem.instance.craftingButtonText.text = "Craft";
        }
    }

    public bool CheckCraft()
    {
        canCraft = true;
        foreach(CraftingRequirements requirement in currentItem.requiredMaterials)
        {
            string requiredName = "";
            for(int j = 0; j < GameManager.instance.itemManagerDB.items.Length; j++)
            {
                if(requirement.RequiredMaterialName == GameManager.instance.itemManagerDB.items[j])
                {
                    //check the corresponding item number, see if it matches the required material number
                    if(GameManager.instance.itemManagerDB.itemNumbers[j] >= requirement.RequiredMaterialNumber)
                    {
                        //Test debug to say that the player has enough of that material
                        
                        requiredName = requirement.RequiredMaterialName;
                    }
                    else {
                        Debug.Log("Cannot craft!");
                        canCraft = false;
                        break;
                    }
                }
            }

            if(requiredName == "")
            {
                canCraft = false;
                break;
            }
        }

        return canCraft;
        /*if (canCraft)
        {
            //create the item here
            foreach (CraftingRequirements requirements in currentItem.requiredMaterials)
            {
                GameManager.instance.itemManagerDB.removeItem(requirements.RequiredMaterialName, requirements.RequiredMaterialNumber);
                
            }

            //Create a method that creates an object prefab/array entry
            //This will tie into two areas:

            // - SelectedItem - A string variable that stores the currently selected tool
            // - SwitchItem - a method that changes the SelectedItem in addition to destroying/creating prefab object
        }*/
    }

    public void craftItem()
    {
        foreach(CraftingRequirements requirement in currentItem.requiredMaterials)
        {
            GameManager.instance.itemManagerDB.removeItem(requirement.RequiredMaterialName, requirement.RequiredMaterialNumber);
        }

        GameManager.instance.itemManagerDB.checkItemHotbar(false, currentItem);
        selectItemToCraft(currentIndex);
        CheckCraft();
    }

    public void setDefaultCraftingItem()
    {
        selectItemToCraft(0);
    }
}
