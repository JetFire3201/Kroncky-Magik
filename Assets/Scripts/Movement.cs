using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public int MovementSpeed = 1; 
    public int SprintSpeed = 1;
    public Component Character;
    // Start is called before the first frame update
    public float LeftRight=0;
    public float Forward=0;
    public SetCameraRigging SetCameraRigging;
    public Component CameraRig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //The input from the keyboard

        LeftRight = Mathf.Lerp(LeftRight,Input.GetAxisRaw("Horizontal"),0.2f);
        Forward = Mathf.Lerp(Forward,Input.GetAxisRaw("Vertical"),0.2f);
        float multiplier = MovementSpeed;

        if(Input.GetKey(KeyCode.LeftShift)){ //If you press the shift key, Multiplier is the movementspeed plus the added sprint speed.
            multiplier = MovementSpeed+SprintSpeed;
        }
        Vector3 MovementTranslate = Vector3.Normalize(new Vector3(LeftRight,0,Forward))*Mathf.Max(Mathf.Abs(LeftRight),Mathf.Abs(Forward)) * multiplier * Time.deltaTime; //Normalize to prevent diagonal movement effect

        
        transform.Translate(MovementTranslate); //This is the final call to actually move the character
        
        if(SetCameraRigging.lockOn){//Have the Character Face the Target, not the child character.
            
            Vector3 LookAt = SetCameraRigging.LockOnTarget2.transform.position-transform.position;
            LookAt.y=0;
            transform.rotation = Quaternion.LookRotation(LookAt);


        }
        Character.transform.localRotation =Quaternion.LookRotation(MovementTranslate); //Rotate Player to move in the direction that it is going in.

        

       

    }
}
