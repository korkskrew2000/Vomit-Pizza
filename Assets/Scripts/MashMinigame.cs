using UnityEngine;

public class MashMinigame : MonoBehaviour {
    public int mashGoal = 100;
    public int currentMashes = 0;
    public bool win;
    public bool ispressing;
    public MashBar mashbar;
    public AudioSource audios;
    public AudioClip clip;
    public Animator anim;


    private void Start() {
        mashbar.SetMaxMash(mashGoal);
    }

    void Update() {
        mashbar.SetMash(currentMashes);
        if (Input.GetButtonDown("Shoot") && !win) {
            currentMashes++;
            audios.PlayOneShot(clip);
            ispressing = true;
        }
        else if (Input.GetButtonDown("Kick") && !win) {
            currentMashes++;
            audios.PlayOneShot(clip);
            ispressing = true;
        }
        else if (Input.GetButtonDown("Interact") && !win) {
            currentMashes++;
            audios.PlayOneShot(clip);
            ispressing = true;
        } else {
            ispressing = false;
        }


        if (ispressing && !win) {
            
            anim.SetBool("pressing", true);
        } else {

            anim.SetBool("pressing", false);
        }

        if (currentMashes >= mashGoal) {

            win = true;
            anim.SetBool("win", true);
        }
    }
}
