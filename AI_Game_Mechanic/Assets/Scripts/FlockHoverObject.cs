using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockHoverObject : MonoBehaviour
{
    public StayInRadiusBehaviour point;

    void Start()
    {
        point.center = transform.GetChild(0).transform.position;
    }
}
