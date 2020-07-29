using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;
    public GameObject hitparticlePrefab;



    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteoritos"))
        {
            Meteoritos meteoritos = collision.gameObject.GetComponent<Meteoritos>();

            if (meteoritos != null)
            {
                FindObjectOfType<Score>().AddPoints(10);

                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                GameObject particles = Instantiate(hitparticlePrefab, transform.position, transform.rotation);
                Destroy(particles, 5f);
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                FindObjectOfType<Score>().AddPoints(10);

                enemy.Damage(damageAmount);

                GameObject particles2 = Instantiate(hitparticlePrefab, transform.position, transform.rotation);
                Destroy(particles2, 1f);
                Destroy(this.gameObject);
            }
        }


    }


}