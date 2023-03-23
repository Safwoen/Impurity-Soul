using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 lookInput, screenCentre, mouseDistance;
    public float lookRateSpeed = 90f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseDistance.y = Input.GetAxis("Mouse Y");
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, 0f,0f , Space.Self);
    }
}
