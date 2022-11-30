using UnityEngine;

public class StarsCollector : MonoBehaviour
{
    public int Value { get; private set; }

    public void Take()
    {
        Value++;
    }
}
