using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSet : MonoBehaviour
{
    public GameObject bulletPe;
    public void Shoot()
    {
        GameObject clone = Instantiate(bulletPe, transform.position, transform.rotation);
        Bull bullGameobj = clone.GetComponent<Bull>();
        bullGameobj.direction = (transform.rotation * Vector3.right).normalized;
    }
}
