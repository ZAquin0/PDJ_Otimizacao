using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType {Red, Blue, Yellow}
public class PuzzleCheckColor : MonoBehaviour
{
    [SerializeField] private ButtonType buttonColor;
    [HideInInspector] public delegate void OnBoxPlaced(ButtonType color);
    [HideInInspector] public static OnBoxPlaced onBoxPlaced;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        PuzzleBoxColor pbc = other.GetComponent<PuzzleBoxColor>();
        if(pbc != null && pbc.boxColor == buttonColor)
        {
            Debug.Log("found box");
            onBoxPlaced?.Invoke(buttonColor);
        }
    }
}
