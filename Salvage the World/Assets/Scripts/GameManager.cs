using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManagerDB;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
