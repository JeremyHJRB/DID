using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractType{NONE, PICKUP, USE, TALK};
    public InteractType type;

    private void Reset(){
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact(){
        switch (type)
        {
            case InteractType.PICKUP:
                Debug.Log("Picked up");
                break;
            case InteractType.USE:
                Debug.Log("Used");
                break;
            case InteractType.TALK:
                Debug.Log("Talked");
                break;
            default:
                Debug.Log("No interaction");
                break;
        }
    }

}
