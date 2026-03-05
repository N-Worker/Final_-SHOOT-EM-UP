using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSet : MonoBehaviour
{
    public Vector2 minPosition, maxPosition;

    public float moveSpeed = 10f;
    public float boostSpeedMul = 3f;

    public float immortallTime = 1f;
    private float immortallTimer = 0f;

    public SpriteRenderer playerColor;
    private Color startColor;

    public GunSet[] Guns = new GunSet[0];
    private float fireTimer = 0;
    public float firerate = 2;

    public int myLevel = 0;

    public LevelData[] levels = new LevelData[0];

    // Start is called before the first frame update
    void Start()
    {
        Guns = levels[myLevel].guns;
        firerate = levels[myLevel].fireRate;
        startColor = playerColor.color;
        immortallTimer = 0;
    }   

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        float moveDel = moveSpeed * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, v, 0)* moveDel;

        if (movement.magnitude > moveDel)
        {
            float retio = moveDel / movement.magnitude;
            movement *= retio;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            movement *= boostSpeedMul;
        }

        pos += movement;

        if (pos.x <= minPosition.x)
        {
            pos.x = minPosition.x;
        }
        if (pos.x >= maxPosition.x)
        {
            pos.x = maxPosition.x;
        }
        if (pos.y <= minPosition.y)
        {
            pos.y = minPosition.y;
        }
        if (pos.y >= maxPosition.y)
        {
            pos.y = maxPosition.y;
        }

        transform.position = pos;

        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                for (int i = 0; i < Guns.Length; i++)
                {
                     Guns[i].Shoot();
                }
            }
            fireTimer = 1 / firerate;
        }
        if (immortallTimer >= 0)
        {
            immortallTimer -= Time.deltaTime;
            Color c = startColor;
            c.a = Mathf.PingPong(Time.time * 15,1);
            playerColor.color = c; 
        }
        else
        {
            playerColor.color = startColor;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (immortallTimer > 0)
            {
                return;
            }
            immortallTimer = immortallTime;
            
            GameManager.instance.DecLife();
            if(GameManager.instance.life <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (other.tag == "PowerUp")
        {
            myLevel++;
            if (myLevel >= levels.Length)
            {
               myLevel = levels.Length - 1;
            }
            Guns = levels[myLevel].guns;
            firerate = levels[myLevel].fireRate;
            Destroy(other.gameObject);
            GameManager.instance.level.text = myLevel.ToString();
        }
    }
}
[System.Serializable]
public class LevelData
{
    public GunSet[] guns = new GunSet[0];
    public float fireRate = 0f;
}
