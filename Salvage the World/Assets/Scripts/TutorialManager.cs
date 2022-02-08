using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    AudioSource audioSource;
    public AudioClip[] tutorialLines;
    public bool[] tutorialFlags;

    public Text tutorialTextPrompt;
    public GameObject tutorialPanel;

    string promptStorage;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerTutorial(int tutorialNumber, string tutorialPrompt)
    {
        if (tutorialNumber != 0)
        {
            if (!tutorialFlags[tutorialNumber] && tutorialFlags[tutorialNumber - 1])
            {
                //If false, play the tutorial clip and set the flag to true
                audioSource.clip = tutorialLines[tutorialNumber];
                audioSource.Play();
                tutorialFlags[tutorialNumber] = true;
                promptStorage = tutorialPrompt;
                Invoke("panelDelay", audioSource.clip.length);
            }
        }
        else
        {
            if (!tutorialFlags[tutorialNumber])
            {
                audioSource.clip = tutorialLines[tutorialNumber];
                audioSource.Play();
                tutorialFlags[tutorialNumber] = true;
                promptStorage = tutorialPrompt;
                Invoke("panelDelay", audioSource.clip.length);
            }
        }

        
        
    }


    public void panelDelay()
    {
        setPanel(promptStorage);
    }
    public void setPanel(string tutorialPrompt)
    {
        tutorialPanel.SetActive(true);
        tutorialTextPrompt.text = tutorialPrompt;
        Invoke("resetPanel", 2.5f);
    }

    public void resetPanel()
    {
        tutorialPanel.SetActive(false);
    }
}
