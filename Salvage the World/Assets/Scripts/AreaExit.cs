using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string sceneToLoad;
    public string areaTransitionName;
    public AreaEntrance entrance;
    public float waitToLoad;
    bool shouldLoad;

    void Start()
    {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
            shouldLoad = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerBase>())
        {
            PlayerBase.instance.areaTransitionName = areaTransitionName;
            shouldLoad = true;
        }
    }
}
