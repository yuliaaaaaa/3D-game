using UnityEngine;
using System.Collections;
public class PickUpBehavior : MonoBehaviour
{
    private Outline scriptOutline;
    private GameObject highlightedObject;
    private GameObject player;
    private Character pickUpMethod;
    private Inventory inventory;

    public void Start()
    {
        scriptOutline = gameObject.GetComponent<Outline>();
        scriptOutline.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        pickUpMethod = player.GetComponent<Character>();
        inventory = player.GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scriptOutline.enabled = true;
            highlightedObject = gameObject;
            StartCoroutine(CheckPickUp());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            scriptOutline.enabled = false;
            if (highlightedObject == gameObject)
            {
                highlightedObject = null;
            }
            StopCoroutine(CheckPickUp());
        }
    }

    public void GetItem()
    {
        scriptOutline.enabled = false;
        StartCoroutine(PickUpObjectAfterDelay(1f));
        pickUpMethod.standing.PickUpState();
        
    }
    private IEnumerator CheckPickUp()
    {
        while (true)
        {
            if (pickUpMethod.standing.pickUpAction.triggered && inventory.empty)
            {
                GetItem();
                yield break;
            }
            yield return null;
        }
    }

    
    private IEnumerator PickUpObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //Destroy(highlightedObject);
        inventory.EnterItem(gameObject);
    }
}

