using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public List<Fish> inventoryList;

    public void AddFish(Fish i)
    {
        inventoryList.Add(i);
        //dd
    }
}
