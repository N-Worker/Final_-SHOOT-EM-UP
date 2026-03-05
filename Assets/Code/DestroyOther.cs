using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOther : MonoBehaviour
{
    public int hp = 20;
    public int score = 5;
    private int hpdamge = 0;

    public float dropRate = 50f;
    public GameObject powerUpPe;

    private void OnTriggerEnter(Collider other)
    {
        if (transform.position.x > 8.5f)
        {
            return;
        }

        Bull collBullet = other.GetComponent<Bull>();
        
        if (collBullet != null && other.tag != "Enemy")
        {
            hpdamge += collBullet.damge;

            if (hpdamge >= hp)
            {
                float r = Random.Range(0, 100);
                if (r < dropRate)
                {
                    Instantiate(powerUpPe, transform.position, Quaternion.identity);
                }

                GameManager.instance.AddScore(score);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
