using UnityEngine;
using UnityEngine.UI; // For UI text handling
using TMPro; // If using TextMeshPro

public class Interactable : MonoBehaviour
{
    public GameObject player;
    public GameObject promptUI; // Assign a UI Text or TMP object
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
        Debug.Log("Interacted with " + gameObject.name);
        // Add interaction logic here (e.g., open door, pick up item, etc.)
    }
}
