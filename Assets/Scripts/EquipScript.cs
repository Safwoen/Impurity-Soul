using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Garbage;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Garbage.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            UnequipObject();
            Shoot();
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                EquipObject();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();
        Garbage.transform.eulerAngles = new Vector3(Garbage.transform.eulerAngles.x, Garbage.transform.eulerAngles.y, Garbage.transform.eulerAngles.z - 45);
        Garbage.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Garbage.GetComponent<Rigidbody>().isKinematic = true;
        Garbage.transform.position = PlayerTransform.transform.position;
        Garbage.transform.rotation = PlayerTransform.transform.rotation;
        Garbage.transform.SetParent(PlayerTransform);
    }
}
