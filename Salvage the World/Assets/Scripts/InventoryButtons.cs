using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtons : MonoBehaviour
{
    public Image buttonImage;
    public Text itemAmount;
    public int buttonValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void press()
    {
        if (MenuSystem.instance.menuPanel.activeInHierarchy)
        {
            if (MenuSystem.instance.craftingWindow.activeInHierarchy)
            {
                CraftingMenu.instance.selectItemToCraft(buttonValue);
                CraftingMenu.instance.CheckCraft();
            }
            else if (MenuSystem.instance.inventoryWindow.activeInHierarchy)
            {
                if (GameManager.instance.itemManagerDB.items[buttonValue] != "")
                {
                    MenuSystem.instance.setItemDetails(buttonValue);
                    //Create method to get item details when clicking on it
                }
            }
        }
    }
}
