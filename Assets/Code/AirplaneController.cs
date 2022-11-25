using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float flySpeed = 5;
    private float yaw;
    
    public float yawAmount = 120;
    public float pitchAmount = 40;
    public float rollAmount = 40;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //forward movment
        transform.position += transform.forward * flySpeed * Time.deltaTime;

        //inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        //yaw pitch roll
        yaw += horizontalInput * yawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, pitchAmount, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, rollAmount, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);
        
        

        //rotation
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right *pitch + Vector3.forward * roll);

    }
}
