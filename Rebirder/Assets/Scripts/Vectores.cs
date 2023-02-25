using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes 
{
    Enemy1,Enemy2
}

public class Vectores : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    public float enemySpeed;
    public float stopDistance;
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy;
    public EnemyTypes enemyType;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Enemy1();
        Enemy2();
        Enemy();
    }

    void Move()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.Translate(new Vector3 (hor, 0, ver)*speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed=3;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed=1;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0,-1,0)*speedRotation*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0,1,0)*speedRotation*Time.deltaTime);        
        }
    }

    void Enemy1()
    {
        Quaternion newRotation = Quaternion.LookRotation(enemy1.transform.position-player.transform.position);
        enemy1.transform.rotation = Quaternion.Lerp(enemy1.transform.rotation, newRotation, speedRotation*Time.deltaTime);
    }

    void Enemy2()
    {
        float dist = Vector3.Distance(enemy2.transform.position,player.transform.position);
        if(dist <= stopDistance)
        {
            enemySpeed=0;
        }
        if(dist >= stopDistance)
        {
            enemySpeed=1;
            enemy2.transform.position = Vector3.MoveTowards(enemy2.transform.position, player.transform.position, enemySpeed*Time.deltaTime);
        }
    }

    void Enemy()
    {
        switch(enemyType)
        {
            case EnemyTypes.Enemy1:
            Quaternion newRotation = Quaternion.LookRotation(enemy.transform.position-player.transform.position);
            enemy.transform.rotation = Quaternion.Lerp(enemy.transform.rotation, newRotation, speedRotation*Time.deltaTime);
            break;

            case EnemyTypes.Enemy2:
            float dist = Vector3.Distance(enemy.transform.position,player.transform.position);
            if(dist <= stopDistance)
            {
                enemySpeed=0;
            }
            if(dist >= stopDistance)
            {
                enemySpeed=1;
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, enemySpeed*Time.deltaTime);
            }
            break;

        }
    }
    
}
