using UnityEngine;

public class Gun : MonoBehaviour
{
    //based off of brackeys gun tutorial
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 10f;
    //how can I disable mouse input when the player is in a menu???
    //that does not have references to other things??
    public bool fireable = true;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && fireable)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("fired" + name);
        //I dont have a particle system but if it would work like this
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }
    }
}
