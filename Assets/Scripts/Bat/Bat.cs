using UnityEngine;

[RequireComponent(typeof(RandomPoint))]
public class Bat : MonoBehaviour
{
    [SerializeField] private float _speed = 2.0f;

    private RandomPoint _randomPoint;
    private Vector3 _targetPoint;
    private float _minDistance = 0.1f;

    private void Start()
    {
        _randomPoint = GetComponent<RandomPoint>();
        _targetPoint = _randomPoint.GetRandomPoint();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _targetPoint) > _minDistance)
            transform.Translate(_speed * (_targetPoint - transform.position).normalized * Time.deltaTime, Space.World);
        else
            _targetPoint = _randomPoint.GetRandomPoint();
    }
}
