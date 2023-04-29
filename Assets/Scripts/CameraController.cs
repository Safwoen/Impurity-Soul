using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   
    float totalRotation = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalRotation -= Input.GetAxis("Mouse Y");

        totalRotation = Mathf.Clamp(totalRotation, -33f, 54f);

       

        transform.rotation = Quaternion.Euler(totalRotation, transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
    }
}
