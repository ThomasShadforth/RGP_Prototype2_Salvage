using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salvage_Object : MonoBehaviour
{
    public string materialType;
    public int materialYield;

    public bool hasBeenSalvaged;

    public bool isTimerActive;

    public float timerVal;
    float timer;
    void Start()
    {
        timer = timerVal;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenSalvaged)
        {
            if (isTimerActive && timer > 0)
            {
                //Test debug for timer when object has been set
                timer -= GamePause.deltaTime;
                Debug.Log(timer);
            }
            if(timer <= 0)
            {
                //Trigger the salvage method, set hasBeenSalvaged to true
                hasBeenSalvaged = true;
                isTimerActive = false;
                salvage();
            }
        }
    }

    public void salvage()
    {
        
        GameManager.instance.itemManagerDB.addItem(materialType, materialYield);
    }

    public void resetTimer()
    {
        //Resets the salvage timer if the player moves while it is active
        isTimerActive = false;
        timer = timerVal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            Debug.Log("PLAYER ENTERED");
            PlayerBase.instance.objectInRange = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            Debug.Log("PLAYER LEFT");
            PlayerBase.instance.objectInRange = null;
        }
    }
}
