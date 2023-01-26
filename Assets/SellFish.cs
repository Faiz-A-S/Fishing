using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SellFish : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI goldText;
    public float total;
    public GoldObject golds;

    public float commonMult;
    public float unCommonMult;
    public float rareMult;
    public float veryRareMult;
    public float legendMult;

    public void Update()
    {
        goldText.text = golds.gold.ToString();
    }
    public void SellAllFish()
    {
        for (int i = 0; i < inventory.inventoryList.Count; i++)
        {
           if (inventory.inventoryList[i].rarity == 0)
           {
                total += inventory.inventoryList[i].weight * commonMult;
           }
           else if(inventory.inventoryList[i].rarity == 1)
           {
                total += inventory.inventoryList[i].weight * unCommonMult;
           }
           else if (inventory.inventoryList[i].rarity == 2)
           {
                total += inventory.inventoryList[i].weight * rareMult;
           }
            else if (inventory.inventoryList[i].rarity == 3)
            {
                total += inventory.inventoryList[i].weight * veryRareMult;
            }
            else if (inventory.inventoryList[i].rarity == 4)
            {
                total += inventory.inventoryList[i].weight * legendMult;
            }
        }
        golds.gold += total;
        inventory.inventoryList.Clear();
    }


}
