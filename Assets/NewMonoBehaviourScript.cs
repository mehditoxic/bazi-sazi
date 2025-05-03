using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject fireballPrefab; // Prefab گلوله آتیش
    public Transform firePoint;       // نقطه‌ی شروع شلیک
    public float fireballSpeed = 10f;  // سرعت گلوله
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
    public AudioSource moveAudio;
    public float minPitch = -3f;
    public float maxPitch =3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // وقتی Space فشار داده شد
        {
            Shoot();
        }
        moveInput = Input.GetAxisRaw("Horizontal");

        // تغییر جهت ظاهر کاراکتر
        if (moveInput > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(1, 1, 1);

        // کنترل انیمیشن‌ها
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

        // کنترل صدا
        if (Mathf.Abs(moveInput) > 0)
        {
            if (!moveAudio.isPlaying)
                moveAudio.Play();

            moveAudio.pitch = (moveInput > 0) ? 1.2f : 0.8f;
        }
        else
        {
            moveAudio.Stop();
        }
    }


    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
    void Shoot()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        // بررسی جهت نگاه کاراکتر
        float direction = transform.localScale.x > 0 ? -1f : 1f;

        rb.linearVelocity = new Vector2(direction * fireballSpeed, 0);

        // چرخش گلوله اگر لازم بود (مثلاً sprite رو بچرخونی)
        fireball.transform.localScale = new Vector3(direction, 1, 1);
        Destroy(fireball, 3f);
    }
}
