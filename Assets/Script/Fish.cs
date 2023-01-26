using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Database/Fish")]
public class Fish : ScriptableObject
{
    public string ID;
    public int rarity;
    public string name;
    public float weight;
    public Sprite image;
}
