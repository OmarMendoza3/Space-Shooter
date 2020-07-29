using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float maxHP = 100;
    public float timeBetweenShoots = 0.5f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    public Text hpText;

    public GameObject deadParticlePrefab;

    public AudioClip shootAudioClip;
    public AudioClip explosionPlayerAudioClip;
    private float currentHP;
    private float timeOfLastShoot;



    private void Start()
    {
        currentHP = maxHP;
        hpText.text = "HP: " + currentHP;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > timeOfLastShoot + timeBetweenShoots)
                Shoot();
        }

    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        hpText.text = "HP: " + currentHP;

        if (currentHP <= 0f)
        {
            Debug.Log("Game Over");
            Dead();
            Destroy(this.gameObject);
        }
    }

    private void Shoot()
    {
        GameObject Bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(Bullet, 5f);
        timeOfLastShoot = Time.time;

        AudioSource.PlayClipAtPoint(shootAudioClip, transform.position, 0.7f);
    }
    private void Dead()
    {
       

        FindObjectOfType<GameManager>().GameOver();

        Destroy(this.gameObject);
    }
}