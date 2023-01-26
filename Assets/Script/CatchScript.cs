using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatchScript : MonoBehaviour
{
    //FISH CONTROL
    //public List<Script> listFishDif;

    public GameObject allCatch;
    public Inventory inven;

    [Header("Point")]
    public float point = 50;
    private bool eligible = false;

    [Header("Line")]
    public GameObject pointA;
    public GameObject pointB;
    public GameObject line;
    public Collider2D lineRed;
    public float speed;
    float linePos;
    float targetPos;
    public float smoothMotion = 3f;
    public float changeInterval = 3f;
    private float nextChange = 0.0f;

    [Header("Green")]
    public GameObject areaCatch;
    public Collider2D green;
    public float size;
    public float greenSpeed;
    float areaCatchMove;
    private Collider2D greenCollider;

    [Header("Parameter")]
    public Image parameter;
    float barFull = 100;
    public float plusMul;
    public float minMul;

    [Header("UI")]
    public Reel reel;
    public GameObject Panel;
    public TextMeshProUGUI fishName;
    public TextMeshProUGUI fishWeight;
    public Image fishImg;

    // Update is called once per frame
    void FixedUpdate()
    {
        areaCatch.transform.localScale = new Vector3(size,1f,1f);
        ChangeLine();
        GreenMove();
        PointUpdate();
        ParameterChange();
    }

    void ChangeLine()
    {
        if(Time.time > nextChange)
        {
            nextChange = Time.time + changeInterval;
            targetPos = Random.value;
        }
        linePos = Mathf.SmoothDamp(linePos, targetPos, ref speed, smoothMotion);
        line.transform.position = Vector2.Lerp(pointA.transform.position, pointB.transform.position, linePos);
    }
    
    void GreenMove()
    {  
        if (Input.GetKey(KeyCode.Mouse0) && areaCatchMove < 1)
        {
            areaCatchMove += greenSpeed * Time.deltaTime;
        }
        else if(areaCatchMove <0)
        {
            areaCatchMove = 0;
        }
        else 
        { 
            areaCatchMove -= greenSpeed * Time.deltaTime;
        }
        Vector2 clampGreen = areaCatch.transform.position;

        clampGreen.x = Mathf.Lerp(pointA.transform.position.x + (areaCatch.transform.localScale.x * 4f), pointB.transform.position.x - (areaCatch.transform.localScale.x * 4f), areaCatchMove);
        areaCatch.transform.position = clampGreen;
    }

    public void Inside(Collider2D other)
    {
        greenCollider = other;
        eligible = true;
    }

    public void Outside(Collider2D other)
    {
        greenCollider = other;
        eligible = false;
    }

    private void PointUpdate()
    {
        if(eligible == true)
        {
            if(point >= 100)
            {
                Panel.SetActive(true);
                var randomFish = Database.GetRandomFish();
                Time.timeScale = 0;
                randomFish.weight = Random.Range(1f, 10f);
                SetUI(randomFish);
                reel.DisableAllComp();
                inven.inventoryList.Add(randomFish);
            }
            else
            {
                point += plusMul/2f;
            }
        }
        else
        {
            if(point <= 0)
            {
                Debug.Log("Dead");
                AfterCatch.StartNew();
            }
            else
            {
                point -= minMul/2f;
            }
        }

        if(point < 20f)
        {
            parameter.color = new Color(255, 0, 0);
        }
        else if(point >20f && point < 35f)
        {
            parameter.color = new Color(255, 165, 0);
        }
        else if (point > 35f && point < 75f)
        {
            parameter.color = new Color(255, 255, 255);
        }
        else
        {
            parameter.color = Color.green;
        }
    }

    private void ParameterChange()
    {
        parameter.fillAmount = point / barFull;
    }

    void SetUI(Fish i)
    {
        fishName.text = i.name;
        fishWeight.text = i.weight + ".";
        fishImg.sprite = i.image;
    }

}
