using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName ="Database/FishData")]
public class FishDatabase : ScriptableObject
{
    public List<FishRarity> FishList;
}
