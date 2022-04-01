using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour {
    #region Variables
    [Header("Nothing listed below should be changed.")]
    [Space(20)]

    public Transform playerPos;
    public PlayerMovement pm;
    public float speakRange = 5f;
    public LayerMask speakLayer;
    public TextMeshProUGUI wordText;
    public AudioSource speakSound;
    public Animator animator;
    public GameObject gameplayUI;
    public bool isTalking;
    public bool currentlyMidSentence;
    public float speakingSpeed = 0.05f;
    public bool intro = false;
    public bool canSkip = true;
    public Animator introAnim;
    float setSpeakingSpeed;
    float skipDelay;
    float skipTarget = 0.2f;
    public bool canTalk;
    private Queue<string> words;
    public bool triggerobjectAfter;
    public GameObject triggerableObject;
    #endregion


    void Start() {
        words = new Queue<string>();
        pm.canMove = true;
    }

    private void Update() {

        if(intro == true) {
            speakingSpeed = 0.05f;
        }

        if (Input.GetButtonDown("Interact") && canTalk && isTalking == false) {
            Collider2D hitNPC = Physics2D.OverlapCircle(playerPos.position, speakRange, speakLayer);
            speakSound = hitNPC.transform.gameObject.GetComponent<AudioSource>();
            speakingSpeed = hitNPC.transform.gameObject.GetComponent<DialogueTrigger>().speakingSpeed;
            setSpeakingSpeed = speakingSpeed;
            hitNPC.transform.gameObject.GetComponent<DialogueTrigger>().Speak();
        }

        if (isTalking == true) {
            pm.canMove = false;
            gameplayUI.gameObject.SetActive(false);
            skipDelay += Time.deltaTime;
            if (Input.GetButtonDown("Interact") && !currentlyMidSentence) {
                DisplayNextSentence();
            }
            if (Input.GetButtonDown("Interact") && canSkip && skipDelay >= skipTarget && currentlyMidSentence) {
                speakingSpeed = 0f;
            }
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("IsOpen", true);
        words.Clear();
        foreach (string word in dialogue.words) {
            words.Enqueue(word);
        }
        isTalking = true;
    }

    public void DisplayNextSentence() {
        skipDelay = 0f;
        if (words.Count == 0) {
            EndDialogue();
            if (intro) {
                introAnim.SetBool("end", true);
            }
            canTalk = false;
            return;
        }
        string word = words.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(word));
    }

    IEnumerator TypeSentence(string word) {
        speakSound.Play();
        currentlyMidSentence = true;
        wordText.text = "";
        foreach (char letter in word.ToCharArray()) {
            wordText.text += letter;
            yield return new WaitForSeconds(speakingSpeed);
        }
        currentlyMidSentence = false;
        speakingSpeed = setSpeakingSpeed;
        speakSound.Stop();
    }

    public void EndDialogue() {
        if (triggerobjectAfter) {
            triggerableObject.gameObject.SetActive(true);
        }
        currentlyMidSentence = false;
        speakSound.Stop();
        animator.SetBool("IsOpen", false);
        isTalking = false;
        gameplayUI.gameObject.SetActive(true);
        pm.canMove = true;
    }
}
