using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForDebugging : MonoBehaviour
{

    public StayInBoxBehaviour boxed;
    public Material c;

    void Start()
    {
        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.localScale = boxed.boxLimit;
        obj.transform.position = boxed.center;
        obj.GetComponent<BoxCollider>().enabled = false;

        obj.GetComponent<Renderer>().material = c;
    }
}
