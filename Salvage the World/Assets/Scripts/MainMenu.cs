using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject howToPlayMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void openCloseHowToPlay()
    {
        if (!howToPlayMenu.activeInHierarchy)
        {
            howToPlayMenu.SetActive(true);
        }
        else
        {
            howToPlayMenu.SetActive(false);
        }
    }
}
