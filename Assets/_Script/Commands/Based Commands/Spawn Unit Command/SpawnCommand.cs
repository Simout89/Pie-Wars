using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class SpawnCommand : ICommand
{
    public IEntity _entity { get; set; }

    [Inject] private ObjectsPoolData objPoolData;

    private int spawnRadius = 20;
    private Unit targetUnitPrefab; //unit  that should spawn

    
    private float coolDown;
    private float lastSpawnTime = -Mathf.Infinity;

    public SpawnCommand(IEntity ent, Unit _targetUntPrefab, float _coolDown)
    {
        this._entity = ent;
        this.targetUnitPrefab = _targetUntPrefab;
        this.coolDown = _coolDown;
    }

    public bool Execute()
    {
        if (targetUnitPrefab == null || objPoolData == null)
        {
            Debug.Log("Spawn command error.");
            return false;
        }

        if (Time.time - lastSpawnTime > coolDown)
        {

            Vector3 spawnPoint = _entity.transform.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            spawnPoint.y = 0f;
            Unit spawnedUnit = GameObject.Instantiate(targetUnitPrefab, spawnPoint, Quaternion.identity);
            spawnedUnit.gameObject.SetActive(true); // Активируем объект, чтобы он прошел через Awake()
            objPoolData.AddUnit(spawnedUnit);
            lastSpawnTime = Time.time;
        }
        return true;

    }
}
