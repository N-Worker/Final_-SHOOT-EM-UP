using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
    private EnemyMove enemyMove;
    public BossMovePaturn bossMove;

    // Start is called before the first frame update
    void Start()
    {
        
        enemyMove = GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossMove == null)
        {
            GameManager.instance.WinGG();
            this.enabled = false;
            return;
        }

        if (transform.position.x <= 0.2f)
        {
            transform.position = Vector3.zero;
            enemyMove.speed = 0;
            enemyMove.enabled = false;
            bossMove.isStarMove = false;
        }
        
    }
}
