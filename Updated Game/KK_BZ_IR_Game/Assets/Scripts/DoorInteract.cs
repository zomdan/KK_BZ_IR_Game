using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public AnimationController animationTrigger;
    public GameObject player;
    public GameObject promptUI;
    public float interactionRadius = 3f;
    
    private bool isPlayerNearby = false; 

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false); // Hide prompt initially
    }

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= interactionRadius)
        {
            ShowPrompt();
            isPlayerNearby = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        else
        {
            HidePrompt();
            isPlayerNearby = false;
        }
    }

    void ShowPrompt()
    {
        if (promptUI != null)
            promptUI.SetActive(true);
    }

    void HidePrompt()
    {
        if (promptUI != null)
            promptUI.SetActive(false);
    }

    void Interact()
    {
     animationTrigger.TriggerAnim();
    }
}
