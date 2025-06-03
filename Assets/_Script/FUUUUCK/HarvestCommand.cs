using UnityEngine;

public class HarvestCommand : ICommand
{
    private ResourceNode _targetNode;
    private float _harvestInterval = 2f;
    private float _lastHarvestTime;

    public IEntity _entity { get; set; }

    public HarvestCommand(IEntity entity, ResourceNode targetNode)
    {
        _entity = entity;
        _targetNode = targetNode;
        _lastHarvestTime = Time.time;
    }

    public bool Execute()
    {
        if(_targetNode == null || _targetNode.IsEmpty)
        {
            return true; // Команда завершена
        }

        // Подойти к узлу ресурса
        float distanceToNode = Vector3.Distance(_entity.transform.position, _targetNode.transform.position);
        
        if(distanceToNode > 2f)
        {
            // Двигаемся к узлу
            Vector3 direction = (_targetNode.transform.position - _entity.transform.position).normalized;
            float speed = (float)_entity._characteristics.SP;
            _entity.transform.position += direction * speed * Time.deltaTime;
            _entity.transform.LookAt(_targetNode.transform.position);
            return false;
        }

        // Добываем ресурс
        if(Time.time >= _lastHarvestTime + _harvestInterval && _targetNode.CanHarvest)
        {
            int harvestedAmount = _targetNode.Harvest();
            if(harvestedAmount > 0)
            {
                ResourceManager.Instance.AddResource(_targetNode.ResourceType, harvestedAmount);
            }
            _lastHarvestTime = Time.time;
        }

        return false; // Продолжаем добычу
    }
}