using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP = 100f;
    private float currentHP;
    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    public float timeBetweenShoots = 0.5f;
    private float timeOfLastShoot;

    private void Start()
    {
        currentHP = maxHP;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > timeOfLastShoot + timeBetweenShoots)
                shoot();
        }
    }

    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
    }
    private void shoot()
    {
        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        timeOfLastShoot = Time.time;
    }
}
