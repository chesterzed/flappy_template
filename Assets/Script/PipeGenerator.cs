using UnityEngine;
using Random = UnityEngine.Random;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private Pipe _pipe;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float minSpawnPosY;
    [SerializeField] private float maxSpawnPosY;

    private float _elapsedTime = 0;
    
    private void Start()
    {
        Initialize(_pipe.gameObject);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if (_elapsedTime > spawnDelay && TryGetObject(out GameObject pipe))
        {
            _elapsedTime = 0;
            float spawnPosY = Random.Range(minSpawnPosY, maxSpawnPosY);
            Vector3 spawnPoint = new Vector3(transform.position.x, spawnPosY, transform.position.z);
            pipe.SetActive(true);
            pipe.transform.position = spawnPoint;
            
            DisableObjectAbroadScreen();
        }
    }
}
