using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setKeyObjectStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToLevel()
    {
        setKeyObjectStatus();
        SceneManager.LoadScene(GameManager.instance.currentLevel);
        PlayerBase.instance.transform.position = GameManager.instance.levelStartPos;
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    void setKeyObjectStatus()
    {
        //Set all to false
        if (GameManager.instance.gameObject.activeInHierarchy)
        {
            PlayerBase.instance.gameObject.SetActive(false);
            GameManager.instance.gameObject.SetActive(false);
            GameplayUI.instance.gameObject.SetActive(false);
        }

        //Set all to true
        else
        {
            PlayerBase.instance.gameObject.SetActive(true);
            GameManager.instance.gameObject.SetActive(true);
            GameplayUI.instance.gameObject.SetActive(true);
        }
    }
}
