using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA_CONTROLLER : MonoBehaviour
{
    float xRotation=0f;
    //float yRotation=0f;
    float mouseSenstivity=10f;
    public Transform playerBody;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenstivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenstivity*Time.deltaTime;
        //control playerBody gameObject rotation in Y-axis(unity)
        playerBody.Rotate(Vector3.up*5*mouseX);
        xRotation -= 5*mouseY;
        xRotation=Mathf.Clamp(xRotation,-90,45);
        //control camera rotation in X-axis(unity)
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

    }
}
