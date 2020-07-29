using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 20;
    private float currentHP;

    public float speed = 5f;

    public float timeBetweenShoots = 0.5f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    private float timeOfLastShoot;

    public AudioClip explosionEnemyAudioClip;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;

        currentHP = maxHP;
    }
    private void Update()
    {
        if (Time.time > timeOfLastShoot + timeBetweenShoots)
            Shoot();
    }
    private void Shoot()
    {
        GameObject particles = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(particles, 1f);
        timeOfLastShoot = Time.time;

        //AudioSource.PlayClipAtPoint(shootAudioClip, transform.position, 0.8f);
    }
    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            AudioSource.PlayClipAtPoint(explosionEnemyAudioClip, transform.position, 1f);

            Destroy(this.gameObject);
        }
    }
}