using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public VariableJoystick joystick;
    public Animator animCtrl;
    public Button carBtn, yatchBtn;
    public float xMax, xMin, zMax, zMin;

    public float Speed = 5f;
    public float RotationSpeed = 10f;

    void Start()
    {
        carBtn.gameObject.SetActive(false);
        yatchBtn.gameObject.SetActive(false);
    }
    void Update()
    {
        if (joystick == null)
            return;

        if (animCtrl == null)
            return;

        
            Vector2 direction = joystick.Direction;

            Vector3 movementVector = new Vector3(direction.x, 0, direction.y);

            movementVector = movementVector * Time.deltaTime * Speed;

            transform.position += movementVector;
        //movementCache += movementVector;
        if (transform.position.x < xMax && transform.position.x > xMin && transform.position.z < zMax && transform.position.z > zMin)
        {
            if (movementVector.magnitude != 0)
            {
                //transform.forward = movementVector;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movementVector, Vector3.up), Time.deltaTime * RotationSpeed);
            }


            //bool isWalking = direction != Vector2.zero;
            bool isWalking = direction.magnitude > 0;

            animCtrl.SetBool("IsWalking", isWalking);

            animCtrl.SetFloat("SpeedValue", direction.magnitude);
        }
        else
        {
            transform.position -= movementVector;
        }


    }

    //private void FixedUpdate()
    //{
    //    if (movementCache != Vector3.zero)
    //    {
    //        transform.position += movementCache;
    //        movementCache = Vector3.zero;  
    //    }

    //}

}
