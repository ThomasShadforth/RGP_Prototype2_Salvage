using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManagerDB;
    public TutorialManager tutorialManager;

    public int currentLevel;
    public Vector2 levelStartPos;
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
        itemManagerDB = GetComponent<ItemManager>();
        tutorialManager = GetComponent<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void setAreaPos(Vector2 position)
    {
        levelStartPos = position;
    }
}
