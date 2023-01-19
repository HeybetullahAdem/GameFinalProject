using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public VariableJoystick joystick;
    public GameObject animCtrl = null;
    public Button carBtn;
    public GameObject oldPlayer;
    public Camera main;
    public Camera carCamera;
    public float xMax, xMin, zMax, zMin;
    public float Speed = 5f;
    public float RotationSpeed = 10f;

    //public Vector3 movementCache = Vector3.zero;
    void Start()
    {
        main.enabled = true;
        carCamera.enabled = false;
        carBtn.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            carBtn.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Player")
        {
            carBtn.gameObject.SetActive(false);
        }
    }

    public void getCar()
    {
        if (oldPlayer.gameObject.activeSelf)
        {
            carBtn.GetComponentInChildren<Text>().text = "Ýn";
            carBtn.image.color = Color.red;
            oldPlayer.gameObject.SetActive(false);
            main.enabled = false;
            carCamera.enabled = true;
            animCtrl = GameObject.FindGameObjectWithTag("car");
        }
        else
        {
            carBtn.GetComponentInChildren<Text>().text = "Bin";
            carBtn.image.color = Color.green;
            oldPlayer.transform.position = this.gameObject.transform.position + new Vector3(5, 0, 5);
            carBtn.gameObject.SetActive(false);
            oldPlayer.gameObject.SetActive(true);
            main.enabled = true;
            carCamera.enabled = false;
            animCtrl = null;
        }
        
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
