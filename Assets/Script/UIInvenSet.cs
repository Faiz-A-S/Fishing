using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInvenSet : MonoBehaviour
{
    public Inventory inven;
    public List<Fish> inventory;
    public List<Image> inventorySlot;
    public GameObject ItemPrefab;

    public Image infoImg;
    public TextMeshProUGUI infoWeight;

    // Update is called once per frame
    void Update()
    {
        inventory = inven.inventoryList;
        if(inventory.Count == 0)
        {
            for (int i = 0; i < inventorySlot.Count; i++)
            {
                inventorySlot[i].GetComponentInChildren<Image>().sprite = null;
            }
        }
        else
        {
            SetUi();
        }
        
    }

    private void SetUi()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlot[i].GetComponentInChildren<Image>().sprite = inventory[i].image;
        }
    }

    public void SetInfo()
    {
        Debug.Log(inventorySlot);
    }
}
