using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishDetail : MonoBehaviour
{
    public string fishName;
    public float fishWeight;

    public float MinW;
    public float MaxW;
    // Start is called before the first frame update
    void Start()
    {
        fishWeight = Random.Range(MinW, MaxW);
    }
}
