using UnityEngine;
using Zenject;

public class MainBuild : Build
{

    [SerializeField] private Unit basedUnitPrefab;
    [Inject] private DiContainer _container;
    public override void InitBuild()
    {
        SpawnCommand spawnCommand = new(this, basedUnitPrefab, 3f);
        _container.Inject(spawnCommand);
        this._staticCommandList.Add(spawnCommand);

    }
}
