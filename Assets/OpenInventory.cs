using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public GameObject invenUi;

    public void ISOPEN()
    {
        if(invenUi.active == true)
        {
            invenUi.SetActive(false);
        }
        else
        {
            invenUi.SetActive(true);
        }
    }
}
