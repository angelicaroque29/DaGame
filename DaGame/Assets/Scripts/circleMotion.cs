using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMotion : MonoBehaviour
{

	public GameObject rotatedObject;
    bool rotating = false;
    public float smoothTime = 5.0f; //rotate over 5 seconds
 
    void OnCollisionEnter(Collision col)
     {
        if (col.gameObject.name == "LeftWall" || col.gameObject.name == "RightWall" && !rotating) // we dont want to call this if the object is already rotating, so we check if it is
         {
            //Rotate rotatedObject by 90 degrees on the Y axis
            rotating = true;
            float rando = Random.Range(0, 100); // pick a random number between 1 and 100
            int multiplier = 1;
            if (rando > 50)
             {
                 multiplier = -1;

             }
             StartCoroutine(RotateOverTime(rotatedObject.transform.localEulerAngles.y, rotatedObject.transform.localEulerAngles.y + (180 * multiplier), smoothTime));
            
        }
     }
    IEnumerator RotateOverTime(float currentRotation, float desiredRotation, float overTime)
     {
         float i = 0.0f;
         while (i <= 1)
         {
             rotatedObject.transform.localEulerAngles = new Vector3(rotatedObject.transform.localEulerAngles.x, Mathf.Lerp(currentRotation, desiredRotation, i), rotatedObject.transform.localEulerAngles.z);
             i += Time.deltaTime / overTime;
             yield return null;
         
         }
         yield return new WaitForSeconds(overTime);
         rotating = false; // no longer rotating

     }
 }

