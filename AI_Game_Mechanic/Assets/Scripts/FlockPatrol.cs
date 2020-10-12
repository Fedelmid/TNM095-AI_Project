using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockPatrol : MonoBehaviour
{
    public StayInRadiusBehaviour target;
    public float changeTargetAfter = 3f;

    public Transform pointA, pointB;

    bool isTraveling = false;

    void Start()
    {
        
        target.center = pointA.position;
        Debug.Log("Start target "+target.center);
        //StartCoroutine("ChangeTarget");
    }

    void Update()
    {
        if(!isTraveling)
            StartCoroutine("ChangeTarget");
    }

    private IEnumerator ChangeTarget()
    {
        isTraveling = true;
        target.center = (target.center == pointA.position) ? pointB.position : pointA.position;
        Debug.Log("Changed target " + target.center);
        yield return new WaitForSeconds(changeTargetAfter);
        isTraveling = false;
    }
}
