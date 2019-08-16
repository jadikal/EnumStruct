using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{
    public GameObject body;
    public static GameObject[] zombies, citizens;
    public Color CityColor;
    void Start()
    {
        int limit = Random.Range(9, 21), cantZ=Random.Range(1,limit-1);
        zombies = new GameObject[cantZ];
        citizens = new GameObject[limit-cantZ];
        for (int i = 0; i < zombies.Length; i++)        {
            zombies[i] = GameObject.Instantiate(body) as GameObject;
            zombies[i].transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            zombies[i].AddComponent<Zombies>();
            zombies[i].GetComponent<Zombies>().zombie.col = Zombies.zCol[Random.Range(0, 3)]; ;
            zombies[i].GetComponent<Zombies>().zombie.taste = Zombies.zTaste[Random.Range(0, 5)];
            zombies[i].GetComponent<MeshRenderer>().material.color = zombies[i].GetComponent<Zombies>().zombie.col;
             
        }//genera los zombies
        for (int i = 0; i < citizens.Length; i++)        {
            citizens[i] = GameObject.Instantiate(body) as GameObject;
            citizens[i].transform.position = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            citizens[i].AddComponent<Citizen>();
            citizens[i].GetComponent<Citizen>().citizen.age = Random.Range(15, 101);
            citizens[i].GetComponent<Citizen>().citizen.name = Citizen.cNames[Random.Range(0, 20)];
            citizens[i].GetComponent<MeshRenderer>().material.color = CityColor;
        }//genera los ciudadanos
        StartCoroutine("AzarMoveVar");
    }
    void Update()
    {
        for (int i = 0; i < zombies.Length; i++)
        {
            Zombies.ZombMove(zombies[i], zombies[i].GetComponent<Zombies>().state);
        }
    }
    IEnumerator AzarMoveVar()
    {
        for (; ; )
        {
            for (int i = 0; i < zombies.Length; i++)
            {
                int index = Random.Range(0, 2);
                zombies[i].GetComponent<Zombies>().state=(Zombies.State)index;
                zombies[i].GetComponent<Zombies>().zombie.rotY = (Random.Range(0, 360));
            }
            yield return new WaitForSeconds(5);
        }
    }
}


