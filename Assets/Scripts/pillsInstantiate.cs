using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillsInstantiate : MonoBehaviour
{
    public GameObject pillInstantiate;
    public GameObject location;
    Vector3 pillPos;
    int colorInt;

    void Start()
    {
        pillPos = location.transform.position;
        colorInt = Random.Range(0, 3);
        Invoke("CreatePill", 1);
    }

    void CreatePill()
    {
        Instantiate(pillInstantiate.transform.GetChild(colorInt), pillPos, Quaternion.identity);
        Invoke("Start", 2);
    }

}
