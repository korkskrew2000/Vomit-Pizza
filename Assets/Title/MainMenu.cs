using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject settingsMenu, instructionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame() {
        anim.SetBool("StartGame", true);
    }

    public void ViewInstructions() {
        instructionsMenu.gameObject.SetActive(true);
    }

    public void ExitInstructions() {
        instructionsMenu.gameObject.SetActive(false);
    }


    public void ViewSettings() {
        settingsMenu.gameObject.SetActive(true);
    }

    public void ExitSettings() {
        settingsMenu.gameObject.SetActive(false);
    }

    public void PlayABetterGame() {
        Application.Quit();
    }

}
