using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public Vector3 velocity = new Vector3();
    public float walkingSpeed;
    public float jumpPower;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * Time.deltaTime * walkingSpeed;
            

        if (Input.GetKey(KeyCode.A))
            transform.position += -transform.right * Time.deltaTime * walkingSpeed;

        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime * walkingSpeed;

        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * Time.deltaTime * walkingSpeed;

        if (Input.GetKey(KeyCode.Space))
            transform.position += transform.up * Time.deltaTime * jumpPower;
    }
}
