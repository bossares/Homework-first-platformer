using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStars : MonoBehaviour
{
    public int Value { get; private set; }

    public void Take()
    {
        Value++;
    }
}
