using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject door;
    public RotatingStone[] stones; // Array of stones

    void Update()
    {
        if (CheckPuzzleSolved())
        {
            OpenDoor();
        }
    }

    bool CheckPuzzleSolved()
    {
        foreach (RotatingStone stone in stones)
        {
            if (stone.GetCurrentSymbol() != "Eagle") // Change to your correct symbol
            {
                return false;
            }
        }
        return true;
    }

    void OpenDoor()
    {
        door.transform.position += new Vector3(0, 5, 0); // Move door upwards
        this.enabled = false; // Disable further checks
    }
}
