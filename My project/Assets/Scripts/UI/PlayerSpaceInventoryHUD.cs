using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerSpaceInventoryHUD : MonoBehaviour
{
    [Header("Slot Atributes")]
    [SerializeField] private string inventoryInput;
    [SerializeField] private Transform playerShip;
    [SerializeField] private GameObject inventorySlotTemplate;
    [SerializeField] private RectTransform slotContainer;
    [SerializeField] private GameObject inventoryHUD;
    [Header("Weight Atributes")]
    [SerializeField] private TextMeshProUGUI maxWeightText;
    [SerializeField] private TextMeshProUGUI currentWeightText;
    private bool isActive = false;
    private GameObject item;
    private void Update()
    {
        maxWeightText.text = $"Max Capacity: {playerShip.GetComponent<PlayerInventory>().maxInventoryCapacity}";
        currentWeightText.text = $"Current Capacity: {PlayerInventory.currentInventoryCapacity}";
        if (Input.GetKeyDown(inventoryInput))
        {
            if(!isActive)
            {
                inventoryHUD.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                foreach(Item item in playerShip.GetComponent<PlayerInventory>().slots) AddItemUI(item);
                isActive = true;
            }
            else
            {
                inventoryHUD.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                foreach(RectTransform slot in slotContainer) Destroy(slot.gameObject);
                isActive = false;
            }
        }
    }
    public void AddItemUI(Item item)
    {
        int childCount = slotContainer.childCount;
        GameObject inventorySlot = Instantiate(inventorySlotTemplate, slotContainer);
        inventorySlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Item: {item.name}";
        inventorySlot.transform.GetChild(1).GetComponent<Image>().color = item.itemImage;
        inventorySlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = $"Weight: {item.weight}";
        inventorySlot.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Destination: {item.destinationIndex}";
        inventorySlot.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate {RemoveItemUI(childCount);});
    }
    public void RemoveItemUI(int position)
    {
        playerShip.GetComponent<PlayerInventory>().RemoveItem(position);
        Destroy(slotContainer.GetChild(position).gameObject);
    }
}
