using UnityEngine;

public class ParticleShooter : MonoBehaviour
{
    public GameObject fireballPrefab; // Prefab گلوله آتیش
    public Transform firePoint;       // نقطه‌ی شروع شلیک
    public float fireballSpeed = 10f;  // سرعت گلوله

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // وقتی Space فشار داده شد
        {
            Shoot();
        }
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
