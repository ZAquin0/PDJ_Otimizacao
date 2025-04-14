using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickupFunction : MonoBehaviour
{
    [SerializeField] private string pickupInput;
    [SerializeField] private string dropInput;
    [SerializeField] private float dropForce;
    [SerializeField] private string throwInput;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform holdPosition;
    private GameObject heldItem;
    private Rigidbody itemRigidbody;
    private void Update()
    {
        if(Input.GetButtonDown(dropInput) && heldItem != null) DropItem();
        if(Input.GetButtonDown(throwInput) && heldItem != null) ThrowItem();
    }
    private void OnTriggerStay(Collider other)
    {
        if(heldItem == null && other.CompareTag("Pickupable") && Input.GetKey(pickupInput)) 
            PickUpItem(other.gameObject);
    }
    private void PickUpItem(GameObject item)
    {
        heldItem = item;
        itemRigidbody = heldItem.GetComponent<Rigidbody>();
        itemRigidbody.isKinematic = true;
        itemRigidbody.useGravity = false;
        heldItem.transform.SetParent(holdPosition);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;
    }

    private void DropItem()
    {
        itemRigidbody.isKinematic = false;
        itemRigidbody.useGravity = true;
        heldItem.transform.SetParent(null);
        itemRigidbody.AddForce(holdPosition.forward * dropForce, ForceMode.Impulse);
        heldItem = null;
    }

    private void ThrowItem()
    {
        itemRigidbody.isKinematic = false;
        itemRigidbody.useGravity = true;
        heldItem.transform.SetParent(null);
        itemRigidbody.AddForce(holdPosition.forward * throwForce, ForceMode.Impulse);
        heldItem = null;
    }
}
