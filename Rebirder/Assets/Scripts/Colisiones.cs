using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisiones : MonoBehaviour
{

public float speed=1;
public float tiempoOriginal=2f;
public float tiempoRestante=2f;
public GameObject paredDorada;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
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

    void OnTriggerEnter(Collider portal)
    {
        if(portal.gameObject.name=="Portal")
        {
            if(transform.localScale == new Vector3 (1,1,1)){
                transform.localScale = new Vector3 (0.5f,0.5f,0.5f);
                transform.position = new Vector3 (0,3,0);
            }
            else{
                transform.localScale = new Vector3(1,1,1);
                transform.position = new Vector3 (0,3,0);
            }
        }
    }

    void OnCollisionStay(Collision paredDorada)
    {
        if(paredDorada.gameObject.name=="Pared Dorada")
        {
            Tempo();
        }
    }

    void Tempo()
    {   
        if(tiempoRestante > 0)
        {
            tiempoRestante-=Time.deltaTime;
        }
        else
        {
            ResetTempo();
        }
    }

    void ResetTempo()
        {
            tiempoRestante=tiempoOriginal;
            paredDorada.transform.Translate(Random.Range(-5f,5f),Random.Range(-5f,5f),0);
        }

    void OnCollisionEnter(Collision obj)
    {
        Debug.Log("Ha colisionado contra "+obj.gameObject.name);
    }
    

}
