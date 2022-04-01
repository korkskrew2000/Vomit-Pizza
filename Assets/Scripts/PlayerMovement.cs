using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;
    public Vector2 faceDirection;
    public bool canMove = true;

    Animator anim;
    Rigidbody2D rb;
    Vector2 moveDirection;



    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        faceDirection.y = -1;
    }

    // Update is called once per frame
    void Update() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;


        if (moveDirection != Vector2.zero) {
            faceDirection = moveDirection;
        }

        anim.SetFloat("lastMoveX", faceDirection.x);
        anim.SetFloat("lastMoveY", faceDirection.y);

    }

    private void FixedUpdate() {
        if (canMove) {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            if (rb.velocity.magnitude <= 0f) {
                anim.SetBool("walking", false);
            } else {
                anim.SetBool("walking", true);
            }
        }

        if (!canMove) {
            rb.velocity = new Vector2(0,0);
            anim.SetBool("walking", false);
            anim.SetBool("shooting", false);
            anim.SetBool("kicking", false);
        }
    }

}
