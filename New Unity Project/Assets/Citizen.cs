using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    public sCitizen citizen = new sCitizen();
    public static string[] cNames;

    private void Awake()
    {
        cNames = new string[]
        {
            "Ruby","Yang","Weiss","Blake","Glynda","Ozpin","Jaune","Pyrrha","Nora","Ren","Coco","Velvet","Salem","Penny","Neo","Kali","Sumer","Qrow","Raven","Zwei"           
        };
        
    }
    
}

public struct sCitizen
{
    public string name;
    public int age;
}