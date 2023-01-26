using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public FishDatabase fishs;
    private static Database data;
    //public Reel Reel;

    void Awake()
    {
        if(data == null)
        {
            data = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Fish GetFishById(int rarity, string ID)
    {
        return data.fishs.FishList[rarity].FishRarityList.FirstOrDefault(x => x.ID == ID);
    }

    public static Fish GetRandomFish()
    {
        //int tempRandomFirst = Random.Range(0, data.fishs.FishList.Count());
        int tempRandomFirst = Reel.gacha;
        return data.fishs.FishList[tempRandomFirst].FishRarityList[Random.Range(0, data.fishs.FishList[tempRandomFirst].FishRarityList.Count())];
    }
}
