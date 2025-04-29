using UnityEngine;

public class RotatingStone : MonoBehaviour
{
    public Transform rotatingPart;
    public string[] symbols = { "Snake", "Eagle", "Whale" };
    private int currentSymbolIndex = 0;

    public void RotateStone()
    {
        currentSymbolIndex = (currentSymbolIndex + 1) % symbols.Length;
        UpdateRotation();
    }

    void UpdateRotation()
    {
        float angle = currentSymbolIndex * 120f;
        rotatingPart.localRotation = Quaternion.Euler(0, angle, 0);
    }

    public string GetCurrentSymbol()
    {
        return symbols[currentSymbolIndex];
    }
}
