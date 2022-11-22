using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    //detection point
    public Transform detectionPoint;
    //detection radius
    private const float detectionRadius=0.3f;
    //layer mask
    public LayerMask detectionLayer;
    //chaced triger object
    public GameObject detectedObject;

    void Update(){
        if (detectObject()){
            if (interactInput()){
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }
    bool interactInput(){
        return Input.GetKeyDown(KeyCode.E);
    }

    bool detectObject(){
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (obj == null){
            detectedObject = null;
            return false;
        }
        else{
            detectedObject = obj.gameObject;
            return true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    }
}
