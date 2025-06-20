using UnityEngine;

public class SpawnerModule : ActionBase
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject[] _prefabPull;

    [SerializeField] private float _skipSpawnChange = 0.5f;

    protected override void ExecuteInternal()
    {
        SpawnRandomFromPull();
    }

    private void SpawnRandomFromPull()
    {

        if (_spawnPoint == null || _prefabPull.Length == 0)
        {
            Debug.LogError("Spawn point empty or you are forgot add prefab pull ");
            return;
        }

        if(Random.value < _skipSpawnChange) return;


        var sellectedObj = _prefabPull[Random.Range(0, _prefabPull.Length)];

        Instantiate(sellectedObj, _spawnPoint.position, Quaternion.identity, _spawnPoint);
    }
}
