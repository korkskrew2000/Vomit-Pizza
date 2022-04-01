using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseNStuff : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause")) {
            
            paused = true;
            pauseMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            Cursor.visible = true;
            AudioListener.pause = true;
        }
    }

    public void ContinueButton() {
        paused = false;
        pauseMenu.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        Cursor.visible = false;
        AudioListener.pause = false;
    }

    public void QuitButton() {
        Application.Quit();
    }

}
