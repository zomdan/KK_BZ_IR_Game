using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject player;
    public GameObject promptUI;
    public float interactionRadius = 3f;
    
    private bool isPlayerNearby = false;
    private RotatingStone rotatingStone; // Reference to the RotatingStone script

    void Start()
    {
        if (promptUI != null)
            promptUI.SetActive(false); // Hide prompt initially

        rotatingStone = GetComponent<RotatingStone>(); // Get the RotatingStone component
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
        if (rotatingStone != null)
        {
            rotatingStone.RotateStone(); // Rotate the stone when interacting
        }
    }
}
