﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float shotCounter;
    public float minTimeBetweenShots = 0.2f;
    public float maxTimeBetweenShots = 3f;

	public GameObject projectile;
	public float projectileSpeed = 10f;

	public GameObject deathVFX;
	public float durationOfExplosion = 1f;

	public AudioClip deathSound;
	[Range(0, 1)] public float deathSoundVolume = 0.75f;

	public AudioClip shootSound;
	[Range(0, 1)] public float shootSoundVolume = 0.25f;

	// Start is called before the first frame update
	void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

	private void CountDownAndShoot() {
		shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f) {
            Fire();
			shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
		}
	}

	private void Fire() {
		GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity);
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
		AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
		if (!damageDealer) { return; }
		ProcessHit(damageDealer);
	}

	private void ProcessHit(DamageDealer damageDealer) {
		health -= damageDealer.GetDamage();
		damageDealer.Hit();

		if (health <= 0) {
			Die();
		}
	}

	private void Die() {
		Destroy(gameObject);
		GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
		Destroy(explosion, durationOfExplosion);
		AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
	}
}
