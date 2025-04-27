using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {


        moveInput = Input.GetAxisRaw("Horizontal");

   
        if (moveInput > 0)
            transform.localScale = new Vector3(-1, 1, 1); 
        else if (moveInput < 0)
            transform.localScale = new Vector3(1, 1, 1);

        if (Mathf.Abs(moveInput) > 0.5f)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

}
