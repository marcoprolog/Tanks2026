using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public Transform shootingPoint;
    public float cooldown = 0.3f;
    public float range = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Fire), cooldown, cooldown);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            }
        }
    }
}
