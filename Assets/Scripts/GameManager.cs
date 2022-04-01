using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public bool pauseGame;
    public PlayerMovement playerMovement;
    public Shoot playerShoot;
    public float seconds = 00;
    public float minutes = 00;

    public static GameManager Instance { get; private set; }
    void Awake() {
        //Remove others if scene contains multiple game managers
        if (Instance != null) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
    }
    void Start() {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerShoot = FindObjectOfType<Shoot>();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update() {
        seconds += Time.unscaledDeltaTime;
        if (seconds >= 60) {
            minutes++;
            seconds = 00;
        }
    }

    public IEnumerator GamePause() {
        pauseGame = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Cursor.visible = true;
        AudioListener.pause = true;
        yield return null;
    }

    public IEnumerator GameUnpause() {
        pauseGame = false;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        Cursor.visible = true;
        AudioListener.pause = false;
        yield return null;
    }

}
