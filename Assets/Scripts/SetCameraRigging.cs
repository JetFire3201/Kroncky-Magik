using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is for the looking/lockon/camera position
public class SetCameraRigging : MonoBehaviour
{
      // Start is called before the first frame update
    public Component Cam;
    public Component LookatTarget;
    bool run = true;
    public float Speed;
    public Component CameraRig;
    public bool lockOn;
    public Component LockOnTarget2;
    public Vector3 StartPositionLookatTarget;
    void Start()
    {
        
        if(Cam == null || CameraRig==null){
            Debug.Log("No Camera Set.");
            run=false;
        }
        if(LookatTarget != null){
            LookatTarget.transform.localPosition = StartPositionLookatTarget;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(run){ //If there are Components that are included.

            float y = 1*Input.GetAxis("Mouse Y"); //Invert since down is positive and up is negative.
            
            LookatTarget.transform.Translate(0,y*Time.deltaTime*5,0); //Moving the look object instead.
            if(Input.GetKeyDown(KeyCode.L)){
                //Check if there is enemy/ies to lock on too. Create Array (TODO).
                lockOn = !lockOn;
                
            }
            if(lockOn){ //If we are lockon, look at the second target.
                Cam.transform.localRotation = Quaternion.Lerp(Cam.transform.rotation, Quaternion.LookRotation(LockOnTarget2.transform.position - Cam.transform.position), Time.deltaTime*10); 
            }else{ //Else look at the player (LookAtTarget)
                Cam.transform.localRotation = Quaternion.Lerp(Cam.transform.rotation, Quaternion.LookRotation(LookatTarget.transform.position - Cam.transform.position), Time.deltaTime*10); 
            }   
            Cam.transform.position = Vector3.Lerp(Cam.transform.position,CameraRig.transform.position,Time.deltaTime*Speed);
        }
        

    }
    
}
