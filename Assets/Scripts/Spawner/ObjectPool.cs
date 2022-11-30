using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;
    [SerializeField] private GameObject _container;

    private List<Star> _pool = new List<Star>();

    protected void Initialize(Star prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Star spawned = Instantiate(prefab, _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Star result)
    {
        result = _pool.FirstOrDefault(pullObject => pullObject.gameObject.activeSelf == false);

        return result != null;
    }
}