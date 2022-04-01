using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    #region Public Variables
    public AudioSource speakSound;
    [Range(0, 1)]
    public float speakingSpeed = 0f;
    public Dialogue dialogue;
    #endregion

    private void Start() {
        speakSound = GetComponent<AudioSource>();
    }

    public void Speak() {
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            FindObjectOfType<DialogueSystem>().canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            FindObjectOfType<DialogueSystem>().canTalk = false;
        }
    }
}

