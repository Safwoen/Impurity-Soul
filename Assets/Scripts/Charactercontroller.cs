using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroller : MonoBehaviour
{
   
    
    public float forwardSpeed =25f, strafeSpeed =7.5f, hoverSpeed =5f;
    private float  activeForwardSpeed , activeStrafeSpeed , activeHoverSpeed ;
    private float forwardAcceleration = 2.5f, strafeAcceleration = 2f, hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCentre, mouseDistance;
    bool inWater;

    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
       screenCentre.x = Screen.width * .5f;
        screenCentre.y = Screen.height * .5f;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
       
        mouseDistance.x = Input.GetAxis("Mouse X");
        mouseDistance.y = Input.GetAxis("Mouse Y");

        //transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime,0f , Space.Self);
        transform.Rotate(0f, mouseDistance.x * lookRateSpeed * Time.deltaTime,0f , Space.Self);

        activeForwardSpeed =    Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed,strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        Vector3 delta = transform.forward * activeForwardSpeed;
        delta += transform.right * activeStrafeSpeed;
        delta += transform.up * activeHoverSpeed;

        delta = new Vector3(delta.x, rigidBody.velocity.y, delta.z);

        /*transform.position +=transform.forward * activeForwardSpeed * Time.deltaTime;
        transform.position +=(transform.right * activeStrafeSpeed * Time.deltaTime ) ;
        transform.position +=(transform.up * activeHoverSpeed * Time.deltaTime ) ;*/

        rigidBody.velocity = delta;

      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ashdgfj")
        {
            inWater = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "asdawsd")
        {
            inWater = false;
        }
    }

}
