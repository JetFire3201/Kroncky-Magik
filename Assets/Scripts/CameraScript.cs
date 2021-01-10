using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This Script is for moving the camera around.
public class CameraScript : MonoBehaviour
{
    public float mouseSensitivity;
    public bool invertMouse;
    public bool autoLockCursor;
 
    private Camera cam;
    public Transform character;
   
    void Awake () {
        cam = this.gameObject.GetComponent<Camera>();
        this.gameObject.name = "SpectatorCamera";
        
        Cursor.lockState = (autoLockCursor)?CursorLockMode.Locked:CursorLockMode.None;
    }
   
    void Update () {
        
        float x = Input.GetAxis("Mouse X");
        float y = -1*Input.GetAxis("Mouse Y");

        transform.RotateAround(this.transform.position,this.transform.up,x*mouseSensitivity); //Rotate the parent object to rotate around itself.
        
    
 
        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
