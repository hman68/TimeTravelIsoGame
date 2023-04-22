using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursorIso : MonoBehaviour
{
    Ray r;
    RaycastHit rh;
    Camera c;
    Rigidbody rb;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main;
        rb = GetComponent<Rigidbody>();
        rotation = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        r = c.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(r, out rh);
       // rotation.SetFromToRotation(rb.position, rh.point);
       // rotation.eulerAngles = new Vector3(0,rotation.eulerAngles.y,0);
       // rb.MoveRotation(rotation);
       rh.point = new Vector3(rh.point.x, rb.position.y, rh.point.z);
       GetComponent<Transform>().LookAt(rh.point);
    }
}
