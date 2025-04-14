using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUIObject : MonoBehaviour
{
    [SerializeField] private Transform playerCharacter;
    [SerializeField] private Transform playerShip;
    [SerializeField] private RectTransform hud;
    [SerializeField] private string inputKey;
    [SerializeField] private string targetTag;
    private bool isActive = false;
    private bool hasEntered = false;
    private void Update()
    {
        if(Input.GetKeyDown(inputKey) && hasEntered)
        {
            if(!isActive)
            {
                hud.gameObject.SetActive(true);
                playerCharacter.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                isActive = true;
                Cursor.visible = true;
            }
            else
            {
                hud.gameObject.SetActive(false);
                playerCharacter.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                isActive = false;
                Cursor.visible = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(targetTag)) hasEntered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(targetTag)) hasEntered = false;
    }
}
