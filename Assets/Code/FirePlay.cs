using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlay : MonoBehaviour
{
    public float atkRange = 10f;
    public GunSet gun;
    public float fireRate = 1f;
    private float timer = 0;

    public bool isLockOnPlayer = true;

    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= atkRange)
        {
            if (timer <= 0)
            {
                if (isLockOnPlayer)
                {
                    Vector3 dir = (player.position - transform.position).normalized;
                    Quaternion argle = Quaternion.FromToRotation(Vector3.right, dir);
                    gun.transform.rotation = argle;
                }
                gun.Shoot();
                timer = 2f / fireRate;
            }
        }
        timer -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
}
