using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = PlayerBase.instance.playerHealth;

        if(healthImage.fillAmount < .6)
        {
            healthImage.color = Color.red;
        }
        else
        {
            healthImage.color = Color.green;
        }
    }
}
