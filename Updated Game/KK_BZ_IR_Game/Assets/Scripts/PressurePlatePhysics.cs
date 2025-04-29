using UnityEngine;

public class PressurePlatePhysics : MonoBehaviour
{
    public float downAmount = 0.5f;  // How much the pressure plate goes down
    public float moveSpeed = 1f;     // Speed at which the plate moves down
    public float resetTime = 2f;     // Time after the object leaves the plate to reset

    private Vector3 originalPosition;
    private bool isObjectOnPlate = false;
    private float resetTimer;

    private void Start()
    {
        // Store the original position of the plate
        originalPosition = transform.position;
    }

    private void Update()
    {
        // If the plate is being pressed down
        if (isObjectOnPlate)
        {
            // Move the plate down smoothly
            transform.position = Vector3.Lerp(transform.position, originalPosition - new Vector3(0, downAmount, 0), moveSpeed * Time.deltaTime);
            resetTimer = 0f;  // Reset the timer since something is on the plate
        }
        else
        {
            // If no object is on the plate, start the reset timer
            resetTimer += Time.deltaTime;
            if (resetTimer >= resetTime)
            {
                // Reset the plate to its original position after the delay
                transform.position = Vector3.Lerp(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    // Detect when an object enters the plate's collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object is something that should trigger the plate (like a player or box)
        if (other.CompareTag("Player") || other.CompareTag("PushableObject"))
        {
            isObjectOnPlate = true;
        }
    }

    // Detect when the object leaves the plate's collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the object is the one that was triggering the plate
        if (other.CompareTag("Player") || other.CompareTag("PushableObject"))
        {
            isObjectOnPlate = false;
        }
    }
}
