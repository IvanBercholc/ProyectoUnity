using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float speed=1;

    public GameObject cam1;
    public GameObject cam2;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Camara();
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
    }

    void Camara()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(cam1.activeInHierarchy)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else
            {
                cam2.SetActive(false);
                cam1.SetActive(true);
            }
        }
    }
}
