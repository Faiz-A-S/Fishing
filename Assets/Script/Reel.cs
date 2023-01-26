using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    //FISH DIFFICULT CONTROL
    public FishDiff[] diff;
    public GameObject YUI;
    public GameObject UIPanelFishInfo;

    bool lempar = false;
    bool tarik = false;

    public CatchScript reels;

    public float interval = 1f;
    private float rate;

    public float allTimeFishing = 100f;

    public static int gacha;

    // Start is called before the first frame update
    private void Awake()
    {
        DisableAllComp();
        UIPanelFishInfo.SetActive(false);
    }
    void Start()
    {
        GetComponent<CatchScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            lempar = true;

        }

        if (lempar == true)
        {
            LemparKail();
        }
    }

    void LemparKail()
    {
        if (Time.time > rate && allTimeFishing >= 0f)
        {
            rate = Time.time + interval;
            allTimeFishing -= Random.Range(1f, 15f);
        }

        if (allTimeFishing <= 0f && tarik == false)
        {
            gacha = Random.Range(0, diff.Length);
            catchFish(gacha);
            EnableAllComp();
        }
    }

    void catchFish(int gacha)
    {
        if (tarik == false)
        {
            reels.size = diff[gacha].size;
            reels.speed = diff[gacha].speed;
            reels.smoothMotion = diff[gacha].smoothMotion;
            reels.changeInterval = diff[gacha].changeInterval;
            reels.greenSpeed = diff[gacha].greenSpeed;
            reels.plusMul = diff[gacha].plusMul;
            reels.minMul = diff[gacha].minMul;

            GetComponent<CatchScript>().enabled = true;
        }
        tarik = true;
    }

    [System.Serializable]
    public struct FishDiff
    {
        public string difficult;
        public float size;
        public float speed;
        public float smoothMotion;
        public float changeInterval;

        public float greenSpeed;
        public float plusMul;
        public float minMul;
    }

    public void DisableAllComp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        YUI.SetActive(false);
        //UIPanelFishInfo.SetActive(false);
    }

    void EnableAllComp()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        YUI.SetActive(true);
        //UIPanelFishInfo.SetActive(true);
    }

}
