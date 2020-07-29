using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public float damageAmount = 10f;

    public GameObject hitParticlePrefab;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Damage(damageAmount);
            }
        }
        else if (collision.gameObject.CompareTag("Meteoritos"))
        {
            Meteoritos meteoritos = collision.gameObject.GetComponent<Meteoritos>();

            if (meteoritos != null)
            {
                meteoritos.DestroyMeteorite();

                GameObject particlesEnemy = Instantiate(hitParticlePrefab, transform.position, transform.rotation);
                Destroy(particlesEnemy, 1f);
                Destroy(this.gameObject);
            }
        }

        GameObject particles = Instantiate(hitParticlePrefab, transform.position, transform.rotation);
        Destroy(particles, 1f);
        Destroy(this.gameObject);
    }

public void DestroyMeteoritos()
    {

        Destroy(this.gameObject);
    }

}
