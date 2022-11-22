using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    //detection point
    public Transform detectionPoint;
    //detection radius
    private const float detectionRadius=0.2f;
    //layer mask
    public LayerMask detectionLayer;


    void Update(){
        if (detectObject()){
            if (interactInput()){
                Debug.Log("Interact");
            }
        }
    }
    bool interactInput(){
        return Input.GetKeyDown(KeyCode.E);
    }

    bool detectObject(){
        return Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    }
}
