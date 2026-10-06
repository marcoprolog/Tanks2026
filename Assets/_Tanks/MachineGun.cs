using System.Collections;
using Tanks.Complete;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform shootingPoint;
    public float cooldown = 0.3f;
    public float range = 10f;
    public bool isShooting = false;
    public int damage = 1;
    public ParticleSystem particleEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InvokeRepeating(nameof(Fire), cooldown, cooldown);
        StartCoroutine(ShootingCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            isShooting=true;
            
        }
        else
        {
            isShooting=false;
            
        }
    }

    IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (isShooting)
            {
                //actually shoot
                Fire();
                particleEffect.Play();
                //wait
                yield return new WaitForSeconds(cooldown);
            }
            else
            {
                particleEffect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                yield return null;
            }
        }
    }

    void Fire()
    {
        Debug.DrawRay(shootingPoint.position, shootingPoint.forward * range, Color.red, 0.2f);
        RaycastHit hit;
        if(Physics.Raycast(shootingPoint.position, shootingPoint.forward, out hit, range)) 
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Hit a tank");
                hit.collider.GetComponent<TankHealth>().TakeDamage(damage);
            }
        }
    }
}
