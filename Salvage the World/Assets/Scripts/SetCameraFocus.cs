using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SetCameraFocus : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = PlayerBase.instance.transform;
        cam.LookAt = PlayerBase.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
