using UnityEngine;

public class PressurePad : MonoBehaviour
{
    public GameObject door; // Assign a door or object to interact with
    private bool isPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Object")) // Adjust as needed
        {
            isPressed = true;
            Debug.Log("Pressure Pad Activated!");
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            isPressed = false;
            Debug.Log("Pressure Pad Deactivated!");
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (door != null)
        {
            door.transform.position += new Vector3(0, 3, 0); // Move the door up
        }
    }

    void CloseDoor()
    {
        if (door != null)
        {
            door.transform.position -= new Vector3(0, 3, 0); // Move the door down
        }
    }
}
