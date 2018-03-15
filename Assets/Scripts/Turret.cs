﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Turret Stats")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
    /// <summary>
    /// Update turret target
    /// </summary>
    void UpdateTarget()
    {
        //Create list of all enemies in the map (all objects with 'enemyTag' tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //Loop through all enemies
        foreach (GameObject enemy in enemies)
        {
            //Get distance to the enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            //Update shortestDistance
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //Move in the direction of the closest enemy that is in range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        //Do nothing
        else
        {
            target = null;
        }
    }

	/// <summary>
    /// All turret actions
    /// </summary>
	void Update ()
    {
        //Do nothing if target there is no target
		if (target == null)
        {
            return;
        }

        //Target lock-on
        Vector3 direction = target.position - transform.position;
        //Rotate the turret in the same direction as the target/enemy
        Quaternion turretRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, turretRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Only shoot if fireCountdown <= 0 (creates a firerate)
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        //Decrease fireCountdown with the time it took between frames
        fireCountdown -= Time.deltaTime;
    }

    /// <summary>
    /// Shoot action for turret
    /// </summary>
    void Shoot()
    {
        //Create direction for the bullet to go
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Create new bullet
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        //If there is a bullet, give it a target
        if (bullet != null)
        {
            bullet.Lock_On(target);
        }
    }
}