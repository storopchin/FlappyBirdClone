using UnityEngine;

public class TubeGeneration : ObjectPool
{
    [SerializeField] private GameObject _prefabTube;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionAxisY;
    [SerializeField] private float _minSpawnPositionAxisY;

    private float _elepsedTime = 0;


    private void Generated()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject tube))
            {
                _elepsedTime = 0;           

                tube.SetActive(true);
                tube.transform.position = new Vector3(transform.position.x, 
                    GetRandomPosition(_minSpawnPositionAxisY, _maxSpawnPositionAxisY), transform.position.z); ;

                DisableObjectAbroadScreen();
            }
        }
    }

    private float GetRandomPosition(float minValue, float maxValue)
    {
        return Random.Range(minValue, maxValue);
    }

    private void Start()
    {
        Initialize(_prefabTube);
    }
    private void Update()
    {
        Generated();
    }
}
