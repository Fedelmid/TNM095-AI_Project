using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator characterAnimator;

    public float speed = 6f;
    [HideInInspector]
    public bool speedBoost = false;
    public float speedBoostDuration = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // avoid snapping when chaning direction
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

            characterAnimator.SetBool("isRunning", true);
            characterAnimator.speed = speed/2.0f;
        }
        else
        {
            characterAnimator.SetBool("isRunning", false);
        }
    }

    private IEnumerator SpeedBoost()
    {
        if(!speedBoost)
        {
            speedBoost = true;
            speed = 10f;
            Debug.Log("SPEED BOOST");
            yield return new WaitForSeconds(speedBoostDuration);
            speed = 6f;
            speedBoost = false;
        }
    }
}
