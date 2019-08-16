using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{//controles del las teclas para el heroe
    public static Vector3 pos;
    public Color col;
    public static float speed;
    bool canJump = false;
    void Start()
    {
        speed =  Random.Range(3, 7);
        GetComponent<MeshRenderer>().material.color = col;
    }
    void Update()
    {        transform.eulerAngles = new Vector3(0, FPSim.rotY, 0);
        if (Input.GetKey("w")) { transform.position += transform.forward * (speed / 20); }
        if (Input.GetKey("s")) { transform.position -= transform.forward * (speed / 20); }
        if (Input.GetKey("d")) { transform.position += transform.right * (speed / 20); }
        if (Input.GetKey("a")) { transform.position -= transform.right * (speed / 20); }
        pos = transform.position;

        if ((Input.GetKeyDown(KeyCode.Space)) && (canJump))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
            canJump = false;
        }
    }
    private void OnCollisionEnter(Collision col)
    {//mesage asignado al zombie en la consola del heroe 
        canJump = true;
        if (col.gameObject.GetComponent<Zombies>())
        {
            Debug.Log("Waaaarrrr quiero comer "+ col.gameObject.GetComponent<Zombies>().zombie.taste);
        }//mesage asignado al citizen en la consola del heroe 
        else if (col.gameObject.GetComponent<Citizen>())
        {
            Debug.Log("Holandas! soy " + col.gameObject.GetComponent<Citizen>().citizen.name
                + " y tengo " + col.gameObject.GetComponent<Citizen>().citizen.age + " años");
            col.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
