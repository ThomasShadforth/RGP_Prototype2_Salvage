using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Salvage_Object : MonoBehaviour
{
    public string materialType;
    public int materialYield;

    public bool hasBeenSalvaged;

    public bool isTimerActive;

    public float timerVal;
    float timer;

    public Text timerText;
    public Image timerBar;

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
                timerBar.fillAmount = timer / timerVal;
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

        checkTimerStatus();
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
        timerBar.fillAmount = timer / timerVal;
        timerBar.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            
            PlayerBase.instance.objectInRange = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBase>())
        {
            
            PlayerBase.instance.objectInRange = null;
        }
    }
    void checkTimerStatus()
    {
        if (isTimerActive)
        {
            timerBar.gameObject.SetActive(true);
        }
        else
        {
            timerBar.gameObject.SetActive(false);
        }
    }
}
