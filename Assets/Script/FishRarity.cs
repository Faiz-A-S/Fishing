using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishRarity", menuName = "Database/Rarity")]
public class FishRarity : ScriptableObject 
{
    public List<Fish> FishRarityList;
}
