using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RandomPoint))]
public class Spawner : ObjectPool
{
    [SerializeField] private Star _prefab;
    [SerializeField] private int _count = 5;
    [SerializeField] private float _delay = 2f;

    private RandomPoint _randomPoint;

    private void Start()
    {
        _randomPoint = GetComponent<RandomPoint>();
        Initialize(_prefab);
        StartCoroutine(SpawnStars());
    }

    private IEnumerator SpawnStars()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_delay);

        while (true)
        {
            for (int i = 0; i < _count; i++)
            {
                Vector3 position = _randomPoint.GetRandomPoint();

                if (TryGetObject(out Star star))
                    SetStar(star.GetComponent<Star>(), position);

                yield return waitTime;
            }
        }
    }

    private void SetStar(Star star, Vector3 spawnPosition)
    {
        star.gameObject.SetActive(true);
        star.transform.position = spawnPosition;
    }
}
