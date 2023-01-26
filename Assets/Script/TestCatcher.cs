using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TestCatcher : MonoBehaviour
{
    public TextMeshProUGUI fishName;
    public TextMeshProUGUI fishWeight;
    public Image fishImg;
    [Space]
    public int rarity;
    public string searchFish;

    public void GetRandomFishC()
    {
        SetUI(Database.GetRandomFish());
    }

    public void GetFishById()
    {
        SetUI(Database.GetFishById(rarity, searchFish));
    }

    void SetUI(Fish i)
    {
        fishName.text = i.name;
        fishWeight.text = i.weight + ".";
        fishImg.sprite = i.image;
    }
        
 }
