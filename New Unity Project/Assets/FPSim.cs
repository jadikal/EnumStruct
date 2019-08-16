using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSim : MonoBehaviour
{//control de camara para el heroe con el mouse
    public static float rotY;    
    void Start()
    {
    }
    float x = 0;
    float y = 0;
    void Update()
    {
        transform.position = HeroControl.pos;
        x -= Input.GetAxis("Mouse Y");
        y += Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(x, y, 0);
        rotY = transform.eulerAngles.y;
    }
}
