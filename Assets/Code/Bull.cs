using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    public float lifeTime = 2f;
    public Vector3 direction = Vector3.right;
    public float speed = 50f;

    public int damge = 5;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos;
    }
}
