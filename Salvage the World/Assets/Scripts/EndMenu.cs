using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(PlayerBase.instance.gameObject);

        for(int i = 0; i < GameManager.instance.itemManagerDB.itemHotbar.Length; i++)
        {
            if(GameManager.instance.itemManagerDB.itemHotbar != null)
            {
                if (GameManager.instance.itemManagerDB.itemHotbar[i] != null)
                {
                    Destroy(GameManager.instance.itemManagerDB.itemHotbar[i]);
                }
            }
            else
            {
                break;
            }
        }

        Destroy(GameManager.instance.gameObject);
        Destroy(GameplayUI.instance.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
