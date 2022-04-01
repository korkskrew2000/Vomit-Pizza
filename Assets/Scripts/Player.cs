using UnityEngine;

public class Player : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;



    Animator anim;
    public float invinsibilityFrames = 2f;
    public float frames = 2f;
    bool isInvins;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
        anim.SetBool("Death", false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() {
        if (isInvins) {
            invinsibilityFrames -= Time.deltaTime;
            if (invinsibilityFrames <= 0) {
                isInvins = false;
            }
        }
    }

    public void TakeDamage(int damage) {
        if (isInvins == false) {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0) {
                PlayerDeath();
            }
            invinsibilityFrames = frames;
            isInvins = true;
        }
    }

    public void PlayerDeath() {
        anim.SetBool("Death", true);
    }
}