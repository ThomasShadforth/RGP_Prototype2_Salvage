using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHotbarButton : MonoBehaviour
{
    public bool selected;
    public int slotValue;

    public Image hotbarImage, hotbarDurability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.itemManagerDB.currentItemIndex == slotValue)
        {
            selected = true;
        }
        else
        {
            selected = false;
        }

        if (selected)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
        }



        checkForItem();
        if (hotbarDurability.fillAmount < .5)
        {
            hotbarDurability.color = Color.red;
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void checkForItem()
    {
        if(GameManager.instance.itemManagerDB.itemHotbar[slotValue] != null)
        {
            hotbarImage.gameObject.SetActive(true);
            hotbarDurability.gameObject.SetActive(true);
            hotbarDurability.fillAmount = GameManager.instance.itemManagerDB.itemHotbar[slotValue].durability / GameManager.instance.itemManagerDB.itemHotbar[slotValue].maxDurability;
        }
        else
        {
            hotbarImage.gameObject.SetActive(false);
            hotbarDurability.gameObject.SetActive(false);
        }
    }

    
}
