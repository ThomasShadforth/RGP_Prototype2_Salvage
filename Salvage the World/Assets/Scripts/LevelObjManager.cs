using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjManager : MonoBehaviour
{
    public string levelName;
    public List<Obstacle> levelObstacles = new List<Obstacle>();
    public List<Salvage_Object> levelSalvageObjects = new List<Salvage_Object>();

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        checkObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        checkObjects();
    }

    public void checkObjects()
    {
        Debug.Log("AAAAAAAAAAA");

        List<Obstacle> tempObstacleList = new List<Obstacle>();
        List<Salvage_Object> tempSalvageList = new List<Salvage_Object>();

        Obstacle[] obsArray = FindObjectsOfType<Obstacle>();

        tempObstacleList.AddRange(obsArray);

        Salvage_Object[] salvArray = FindObjectsOfType<Salvage_Object>();

        tempSalvageList.AddRange(salvArray);

        if(levelObstacles.Count == 0)
        {
            for(int i = 0; i < tempObstacleList.Count; i++)
            {
                levelObstacles.Add(tempObstacleList[i]);
            }
        }
        else
        {
            for(int i = 0; i < tempObstacleList.Count; i++)
            {
                bool doesExist = false;
                int listIndex = 0;

                for(int j = 0; j < levelObstacles.Count; j++)
                {
                    if(tempObstacleList[i] == levelObstacles[j])
                    {
                        doesExist = true;
                        listIndex = j;
                    }
                }

                if (!doesExist)
                {
                    levelObstacles.Add(tempObstacleList[i]);
                }
                else
                {
                    //Run checks for the obstacles (if it's active, etc)
                }
            }
        }

        if(levelSalvageObjects.Count == 0)
        {
            for(int i = 0; i < tempSalvageList.Count; i++)
            {
                levelSalvageObjects.Add(tempSalvageList[i]);
            }
        }
        else
        {
            for(int i = 0; i < tempSalvageList.Count; i++)
            {
                bool doesExist = false;
                int listIndex = 0;

                for(int j = 0; j < levelSalvageObjects.Count; j++)
                {
                    if(tempSalvageList[i] == levelSalvageObjects[j])
                    {
                        doesExist = true;
                        listIndex = j;
                    }
                }

                if (!doesExist)
                {
                    levelSalvageObjects.Add(tempSalvageList[i]);
                }
                else
                {

                }
            }
        }
    }
}
