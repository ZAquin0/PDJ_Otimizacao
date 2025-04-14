using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBoard : MonoBehaviour
{
    [SerializeField] private Transform playerShip;
    [SerializeField] private int rerollCost;
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI rerollText;
    private void Start()
    {
        currencyText.text = $"${PlanetScene.currentMoney}";
        rerollText.text = $"${rerollCost}";
        RerollMissions();
    }
    public void SelectMission(GameObject button)
    {
        Item item = button.GetComponent<ButtonMissionItem>().item;
        if(playerShip.GetComponent<PlayerInventory>().AddItem(item)) button.gameObject.SetActive(false);
    }
    public void RerollMissions()
    {
        GameObject mission = this.gameObject;
        for(int index = 0; index < 4; index++)
        {
            Item item;
            do
            {
                item = ItemLibrary.instance.GetRandomItem();
            } while(item.destinationIndex == PlanetScene.planetIndex);
            Transform currentMission = mission.transform.GetChild(1).GetChild(0).GetChild(index);
            currentMission.gameObject.SetActive(true);
            currentMission.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Weight: {item.weight}";
            currentMission.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"Planet Index: {item.destinationIndex}";
            currentMission.GetChild(2).GetComponent<Image>().sprite = item.missionDificulty;
            currentMission.GetChild(3).GetComponent<TextMeshProUGUI>().text = $"Item: {item.name}";
            currentMission.GetChild(4).GetComponent<TextMeshProUGUI>().text = $"Payment: ${item.value}";
            currentMission.GetComponent<ButtonMissionItem>().item = item;
        }
    }
    public void BuyReroll()
    {
        if(PlanetScene.currentMoney >= rerollCost)
        {
            PlanetScene.currentMoney -= rerollCost;
            currencyText.text = $"${PlanetScene.currentMoney}";
            RerollMissions();
        }
    }
}
