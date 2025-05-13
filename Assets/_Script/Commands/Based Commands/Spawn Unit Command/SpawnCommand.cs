using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class SpawnCommand : ICommand
{
    public IEntity _entity { get; set; }

    [Inject] private ObjectsPoolData objPoolData;

    private int spawnRadius = 30;
    private Unit targetUnitPrefab; //unit  that should spawn

    
    private float coolDown;
    private float lastSpawnTime = -Mathf.Infinity;

    public SpawnCommand(IEntity ent, Unit _targetUntPrefab, float _coolDown)
    {
        this._entity = ent;
        this.targetUnitPrefab = _targetUntPrefab;
        this.coolDown = _coolDown;
        this.lastSpawnTime = Time.time;
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
            Vector3 spawnPoint;
            int attempts = 10;
            bool foundValidPoint = false;

            for (int i = 0; i < attempts; i++)
            {
                // ��������� ����� 
                spawnPoint = _entity.transform.position + (Vector3)(Random.insideUnitCircle * spawnRadius);

                
                spawnPoint.y = Terrain.activeTerrain.SampleHeight(spawnPoint); 

                // �������� ���������� 
                Collider unitCollider = targetUnitPrefab.GetComponent<Collider>();
                Vector3 unitSize = unitCollider != null ? unitCollider.bounds.size : new Vector3(20f, 20f, 20f);
                Debug.Log(unitSize);

                
                Vector3 expandedSize = unitSize + new Vector3(15f, 3f, 15f); // ��������� ����� 

                
                int layerMask = ~LayerMask.GetMask("Terrain"); //

                // ��������� ����������� � ��������� �� ���� �����, ����� ��������
                Collider[] overlappingColliders = Physics.OverlapBox(spawnPoint, expandedSize / 2f, Quaternion.identity, layerMask);

                if (overlappingColliders.Length == 0) // ���� ��� �����������, ������� �����
                {
                    
                    Unit spawnedUnit = GameObject.Instantiate(targetUnitPrefab, spawnPoint, Quaternion.identity);
                    spawnedUnit.gameObject.SetActive(true);

                    
                    objPoolData.AddUnit(spawnedUnit);

                   
                    lastSpawnTime = Time.time;

                    foundValidPoint = true;
                    break;
                }
            }

            if (!foundValidPoint)
            {
                Debug.Log("No valid spawn location found.");
                return false;
            }
        }

        return true;
    }
}
