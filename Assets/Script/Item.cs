using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractType{NONE, PICKUP, USE, TALK};
    public InteractType type;

    [Header("Used")]
    public string usedText;
    [Header("Custom Events")]
    public UnityEvent customEvent;

    private void Reset(){
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact(){
        switch (type)
        {
            case InteractType.PICKUP:
                //add object to the PickedUpItems list
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                //disable
                gameObject.SetActive(false);
                break;
            case InteractType.USE:
                //call used item in the interaction system
                FindObjectOfType<InteractionSystem>().UsedItem(this);
                Debug.Log("Used");
                break;
            case InteractType.TALK:
                Debug.Log("Talked");
                break;
            default:
                Debug.Log("No interaction");
                break;
        }

        //call custom event(s)
        customEvent.Invoke();

    }

}
