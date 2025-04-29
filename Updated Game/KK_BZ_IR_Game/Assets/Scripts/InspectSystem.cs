using UnityEngine;

public class InspectSystem : MonoBehaviour
{
    public Transform objectToInspect;
    public float rotationSpeed = 75f;
    public float resetSpeed = 4f; // Speed at which to reset the rotation

    private Vector3 previousMousePosition;
    private Quaternion originalRotation;
    private bool isResetting = false;

    void Start()
    {
        if (objectToInspect != null)
            originalRotation = objectToInspect.rotation; // lines with chatgpt
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isResetting = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = Input.mousePosition;
            isResetting = false; // Line added with chatgpt
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 deltaMousePosition = Input.mousePosition - previousMousePosition;
            float rotationX = deltaMousePosition.y * rotationSpeed * Time.deltaTime;
            float rotationY = deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            objectToInspect.rotation = rotation * objectToInspect.rotation;

            previousMousePosition = Input.mousePosition;
        }

        // following lines added with chatgpt
        else if (isResetting)
        {
            objectToInspect.rotation = Quaternion.Lerp(objectToInspect.rotation, originalRotation, Time.deltaTime * resetSpeed);

            // Stop resetting if we're close enough
            if (Quaternion.Angle(objectToInspect.rotation, originalRotation) < 0.1f)
            {
                objectToInspect.rotation = originalRotation;
                isResetting = false;
            }
        }
    }
}

