using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataManager : MonoBehaviour
{
    public List<LevelObjManager> objectManagers = new List<LevelObjManager>();
    public LevelObjManager managerPrefab;
    public static LevelDataManager instance;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(objectManagers.Count == 0)
        {
            createNewObjectManager();
        }
        else
        {
            bool doesExist = false;
            for (int i = 0; i < objectManagers.Count; i++)
            {
                
                if(objectManagers[i].levelName == SceneManager.GetActiveScene().name)
                {
                    doesExist = true;
                }
            }

            if (!doesExist)
            {
                createNewObjectManager();
            }
        }
    }

    public void createNewObjectManager()
    {
        LevelObjManager newObjManager = Instantiate(managerPrefab);
        newObjManager.transform.parent = this.transform;
        objectManagers.Add(newObjManager);
    }
}
