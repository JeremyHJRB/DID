using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{
    [Header ("Detection Parameters")]
    //detection point
    public Transform detectionPoint;
    //detection radius
    private const float detectionRadius=0.3f;
    //layer mask
    public LayerMask detectionLayer;
    //chaced triger object
    public GameObject detectedObject;
    [Header ("Use Fields")]
    //Picked up window object
    public GameObject UsedWindow;
    public Image UsedImage;
    public Text UsedText;
    public bool isUsed;
    [Header ("Pick Up Fields")]
    //Picked up window object
    public GameObject PickUpWindow;
    public Image PickUpImage;
    public Text PickUpText;
    public bool isPickedUp;
    [Header ("Other")]
    //list of picked up items
    public List<GameObject> pickedItems = new List<GameObject>();

    void Update(){
        if (detectObject()){
            if(FindObjectOfType<KarakterController>().canInteract()){
                if (interactInput()){
                detectedObject.GetComponent<Item>().Interact();
                }
            }
        } else {
            if (interactInput()){
                if (isPickedUp){
                    PickUpWindow.SetActive(false);
                    isPickedUp = false;
                }
            }
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
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

    public void PickUpItem(GameObject item){
        pickedItems.Add(item);
        PickUpImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        PickUpText.text = item.GetComponent<Item>().usedText;
        PickUpWindow.SetActive(true);
        isPickedUp = true;
    }

    public void UsedItem(Item item){
        if(isUsed){
            UsedWindow.SetActive(false);
            isUsed = false;
        }
        else{
            UsedImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            UsedText.text = item.usedText;
            UsedWindow.SetActive(true);
            isUsed = true;
        }
        
    }

}
