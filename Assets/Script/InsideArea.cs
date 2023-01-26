using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideArea : MonoBehaviour
{
    public CatchScript green;

    public void OnTriggerEnter2D(Collider2D other)
    {
        green.Inside(other);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        green.Outside(other);
    }
}
