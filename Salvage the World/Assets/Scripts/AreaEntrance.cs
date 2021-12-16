using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    void Start()
    {
        if(transitionName == PlayerBase.instance.areaTransitionName)
        {
            
            PlayerBase.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
