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
        rb.linearVelocity = transform.right * fireballSpeed; // حرکت به جلو
    }
}
