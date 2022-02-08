using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectManager : MonoBehaviour
{
    public List<Obstacle> obstacleList = new List<Obstacle>();
    public List<Salvage_Object> salvageList = new List<Salvage_Object>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void checkObjectLists()
    {
        List<Obstacle> tempObstacleList = new List<Obstacle>();
        List<Salvage_Object> tempSalvList = new List<Salvage_Object>();

        Obstacle[] obArray = FindObjectsOfType<Obstacle>();

        tempObstacleList.AddRange(obArray);

        if(obstacleList.Count == 0)
        {
            for(int i = 0; i < tempObstacleList.Count; i++)
            {
                obstacleList.Add(tempObstacleList[i]);
            }
        }
        else
        {
            //Add checks for whether the obstacle has been destroyed/disabled
            for(int i = 0; i < tempObstacleList.Count; i++)
            {
                bool doesExist = false;
                int listIndex = 0;
                
                for(int j = 0; j < obstacleList.Count; j++)
                {
                    if(tempObstacleList[i].gameObject == obstacleList[j])
                    {
                        Debug.Log("Exists");
                        doesExist = true;
                        listIndex = j;
                    }
                }

                if (!doesExist)
                {
                    //Add to the list
                    obstacleList.Add(tempObstacleList[i]);
                }
                else
                {
                    //Checks to be performed if it does exist in the list
                    if (!obstacleList[listIndex].gameObject.activeInHierarchy)
                    {
                        tempObstacleList[i].gameObject.SetActive(false);
                    }
                }

            }
        }

        Salvage_Object[] salvArray = FindObjectsOfType<Salvage_Object>();

        tempSalvList.AddRange(salvArray);

        if(salvageList.Count == 0)
        {
            
            for (int i = 0; i < tempSalvList.Count; i++)
            {
                salvageList.Add(tempSalvList[i]);
            }
        }
        else
        {
            //Add checks for whether the salvage has already been performed
            for(int i = 0; i < tempSalvList.Count; i++)
            {
                bool doesExist = false;
                int listIndex = 0;
                
                for(int j = 0; j < salvageList.Count; j++)
                {
                    if(tempSalvList[i].gameObject == salvageList[j])
                    {
                        
                        doesExist = true;
                        listIndex = j;
                    }
                }

                if (!doesExist)
                {
                    salvageList.Add(tempSalvList[i]);
                }
                else
                {
                    if (!salvageList[listIndex].gameObject.activeInHierarchy)
                    {
                        tempSalvList[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        checkObjectLists();
    }
}
