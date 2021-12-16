using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public static MenuSystem instance;

    public GameObject menuPanel;
    public GameObject craftingWindow, inventoryWindow;
    public GameObject[] menuWindows;

    [Header("Button Arrays")]
    public InventoryButtons[] inventoryButtons;
    public InventoryButtons[] craftingMenuButtons;
    public ItemHotbarButton[] hotbarButtons;

    [Header("Crafting Menu UI")]
    public Text selectedCraftItem, craftItemDescription, craftItemDur, craftItemMaterials, craftingButtonText;
    public Button craftingButton;

    [Header("Inventory UI")]
    public Text inventoryItemName, inventoryItemDescription, inventoryButtonText;
    string activeItem;
    void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        for(int i = 0; i < hotbarButtons.Length; i++)
        {
            hotbarButtons[i].slotValue = i;

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseUnPause();
        }
    }

    public void pauseUnPause()
    {
        if (!menuPanel.activeInHierarchy)
        {
            menuPanel.SetActive(true);
            GamePause.GamePaused = true;
            menuWindows[0].SetActive(true);
        }
        else
        {
            menuPanel.SetActive(false);

            for (int i = 0; i < menuWindows.Length; i++)
            {
                menuWindows[i].SetActive(false);
            }

            GamePause.GamePaused = false;

            
        }
    }

    public void openMenuWindow(int windowIndex)
    {
        for(int i = 0; i < menuWindows.Length; i++)
        {
            if(i == windowIndex)
            {
                menuWindows[i].SetActive(!menuWindows[i].activeInHierarchy);
            }
            else
            {
                menuWindows[i].SetActive(false);
            }
        }
    }

    //Run this method when opening the inventory

    public void displayInventoryItems()
    {
        GameManager.instance.itemManagerDB.shiftItems();

        for(int i = 0; i < inventoryButtons.Length; i++)
        {
            inventoryButtons[i].buttonValue = i;

            if(GameManager.instance.itemManagerDB.items[i] != "")
            {
                inventoryButtons[i].buttonImage.gameObject.SetActive(true);
                //Get item details here via the itemManager (To get sprite)
                inventoryButtons[i].itemAmount.text = GameManager.instance.itemManagerDB.itemNumbers[i].ToString();
            }
            else
            {
                inventoryButtons[i].buttonImage.gameObject.SetActive(false);
                inventoryButtons[i].itemAmount.text = "";
            }
        }
    }

    public void displayCraftingMenuItems()
    {
        for(int i = 0; i < craftingMenuButtons.Length; i++)
        {
            craftingMenuButtons[i].buttonValue = i;
            //Get sprite for crafting menu button (Corresponds to position in reference item array)

        }
    }

    public void setItemDetails(int itemIndex)
    {
        string itemInfoName = GameManager.instance.itemManagerDB.items[itemIndex];
        activeItem = GameManager.instance.itemManagerDB.items[itemIndex];
        inventoryItemName.text = "" + itemInfoName;

        for(int i = 0; i < GameManager.instance.itemManagerDB.materialDatabase.Length; i++)
        {
            if(GameManager.instance.itemManagerDB.materialDatabase[i] == itemInfoName)
            {
                inventoryItemDescription.text = "" + GameManager.instance.itemManagerDB.materialDescriptions[i];
            }
        }
    }

    public void scrapItem()
    {
        for(int i = 0; i < GameManager.instance.itemManagerDB.items.Length; i++)
        {
            if(GameManager.instance.itemManagerDB.items[i] == activeItem)
            {
                GameManager.instance.itemManagerDB.removeItem(activeItem, GameManager.instance.itemManagerDB.itemNumbers[i]);
                displayInventoryItems();
                resetInventoryInfoText();
                break;
            }
        }
    }

    public void resetInventoryInfoText()
    {
        inventoryItemName.text = "";
        inventoryItemDescription.text = "";
    }
}
