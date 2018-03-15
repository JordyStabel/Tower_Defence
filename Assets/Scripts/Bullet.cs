using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public float speed = 70f;
    public float explosiveRadius = 0f;
    public GameObject impactEffect;
    
    /// <summary>
    /// Set target for bullet to follow
    /// </summary>
    /// <param name="_target"></param>
    public void Lock_On(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Destroy bullet if it doesn't have a target
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //Hit detection 
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        //Movement of the bullet
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        //Points object towards the target (visual)
        transform.LookAt(target);
	}

    /// <summary>
    /// Target is hit
    /// </summary>
    void HitTarget()
    {
        //Visual effect of bullet impact
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Max duration of the animation
        Destroy(effectInstance, 5f);

        //If bullet has AOE, destroy all objects in range
        if (explosiveRadius > 0f)
        {
            Explode();
        }
        //If bullet is just a bullet, only destroy hit object
        else
        {
            Damage(target);
        }
        //Destroy  bullet
        Destroy(gameObject);
    }

    /// <summary>
    /// Destroy the target/enemy
    /// </summary>
    /// <param name="enemy"></param>
    void Damage (Transform enemy)
    {
        Destroy(enemy.gameObject);
        //Add $25 per killed Enemy
        PlayerStats.Money += 25;
    }

    /// <summary>
    /// Destory all object in range of the AEO
    /// </summary>
    void Explode()
    {
        //Create list of all object that are in range of the explosion
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveRadius);
        //Loop through list of all effected targets/enemies --> destroy them
        foreach (Collider collider in colliders)
        {
            //Make sure to only destroy object with 'enemy' tag --> don't destroy Nodes & turrets
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
}