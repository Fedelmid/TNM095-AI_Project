using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmArea : MonoBehaviour
{

    public StayInBoxBehaviour boxed;
    public GameObject swarmArea;

    void Start()
    {
        swarmArea.transform.localScale = boxed.boxLimit;
        swarmArea.transform.position = boxed.center;
    }
}
