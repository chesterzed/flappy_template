using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject container;
    [SerializeField] protected int capacity;

    private Camera _camera;

    protected List<GameObject> Pool = new List<GameObject>();
    
    protected void Initialize(GameObject prefab)
    {
        _camera = Camera.main;
        
        for (int i = 0; i < capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, container.transform);
            spawnedObject.SetActive(false);
            
            Pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = Pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        // Debug.Log(_camera.ViewportToWorldPoint(new Vector3(0, 0.5f)));
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(0, 0.5f));

        foreach (var item in Pool)
        {
            if (item.activeSelf == true && item.transform.position.x < disablePoint.x)
            {
                item.SetActive(false);
            }
        }
    }

    public void ResetAll()
    {
        foreach (var item in Pool)
        {
            item.SetActive(false);
        }
    }
}
