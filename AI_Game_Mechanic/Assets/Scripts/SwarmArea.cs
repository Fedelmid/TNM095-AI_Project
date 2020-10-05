using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmArea : MonoBehaviour
{

    public StayInBoxBehaviour boxed;
    public GameObject swarmArea;
    //public Material c;

    void Start()
    {
        //swarmArea = GameObject.CreatePrimitive(PrimitiveType.Cube);
        swarmArea.transform.localScale = boxed.boxLimit;
        swarmArea.transform.position = boxed.center;
        //obj.GetComponent<BoxCollider>().enabled = false;
        //swarmArea.GetComponent<Collider>().isTrigger = true;
        //swarmArea.GetComponent<Renderer>().material = c;
    }
}
