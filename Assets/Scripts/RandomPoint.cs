using UnityEngine;

public class RandomPoint : MonoBehaviour
{
    [SerializeField] private float _xRange = 8.5f;
    [SerializeField] private float _yRange = 4.0f;

    public Vector3 GetRandomPoint()
    {
        float xRandomPosition = Random.Range(-_xRange, _xRange);
        float yRandomPosition = Random.Range(-_yRange, _yRange);
        
        return new Vector3(xRandomPosition, yRandomPosition, 0);
    }
}
