using UnityEngine;

public class MoveUIImageWithMouse : MonoBehaviour
{
    // Reference to the UI image RectTransform
    public RectTransform imageRectTransform;

    // Optional limits for the movement (clamps the movement within a specific area)
    public float minX = -200f;
    public float maxX = 200f;

    // Speed of the movement (lower value = slower movement)
    public float lerpSpeed = 5f;

    // Boolean to control whether the image follows the mouse normally or inverted
    public bool invertMovement = false;

    void Update()
    {
        // Get the mouse position in screen space (pixels)
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen space to local space in the UI
        Vector3 localPosition = imageRectTransform.InverseTransformPoint(mousePosition);

        // Invert the direction if needed
        if (invertMovement)
        {
            localPosition = new Vector3(-localPosition.x, -localPosition.y, localPosition.z);
        }

        // Optionally, clamp the position within bounds (min and max)
        float clampedX = Mathf.Clamp(localPosition.x, minX, maxX);

        // Calculate the target position
        Vector3 targetPosition = new Vector3(clampedX, imageRectTransform.localPosition.z);

        // Smoothly move the image towards the target position (lerping)
        imageRectTransform.localPosition = Vector3.Lerp(imageRectTransform.localPosition, targetPosition, lerpSpeed * Time.deltaTime);
    }
}
