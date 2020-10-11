using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmArea : MonoBehaviour
{

    public StayInBoxBehaviour swarmBoxArea;
    public GameObject swarmArea;

    void Start()
    {
        swarmArea.transform.localScale = swarmBoxArea.boxLimit;
        swarmArea.transform.position = swarmBoxArea.center; 
    }

    // Draw a red wire box
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(swarmBoxArea.center, swarmBoxArea.boxLimit);
    }
}
