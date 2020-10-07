using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmArea : MonoBehaviour
{

    public StayInBoxBehaviour boxed;
    public GameObject swarmArea;
    public GameObject swarmAreaColored;

    void Start()
    {
        swarmArea.transform.localScale = boxed.boxLimit;
        swarmArea.transform.position = boxed.center; 

        swarmAreaColored.transform.localScale = boxed.boxLimit;
        swarmAreaColored.transform.position = new Vector3(boxed.center.x, -1.95f, boxed.center.z);



    }
}
