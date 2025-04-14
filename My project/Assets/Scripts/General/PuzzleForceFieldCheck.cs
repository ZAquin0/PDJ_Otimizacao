using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleForceFieldCheck : MonoBehaviour
{
    [SerializeField] private Transform forceField;
    [HideInInspector] public bool[] buttons = new bool[3];
    public void OnEnable()
    {
        PuzzleCheckColor.onBoxPlaced += CheckButton;
        CheckSolved();
    }
    private void CheckSolved()
    {
        if(PlanetScene.planetPuzzleSolved[PlanetScene.planetIndex])
        {
            forceField.gameObject.SetActive(false);
            PuzzleCheckColor.onBoxPlaced -= CheckButton;
        }
        else forceField.gameObject.SetActive(true);
    }
    public void CheckButton(ButtonType color)
    {
        Debug.Log("buttonChecked");
        buttons[(int)color] = true;
        if(buttons[0] && buttons[1] && buttons[2]) PlanetScene.planetPuzzleSolved[PlanetScene.planetIndex] = true;
        CheckSolved();
    }
    public void OnDisable()
    {
        PuzzleCheckColor.onBoxPlaced -= CheckButton;
    }
}
