using _Script;
using UnityEngine;
using Zenject;

public class MainBuild : Build
{

    [SerializeField] private Unit basedUnitPrefab;
    [Inject] private DiContainer _container;
    [SerializeField] public int dbgTeamNum = 1;
    public override void InitBuild()
    {
        SpawnCommand spawnCommand = new(this, basedUnitPrefab, 3f);
        _container.Inject(spawnCommand);
        this._staticCommandList.Add(spawnCommand);
        this.Characteristics = new EntityCfg();

        

    }



    protected override void Update()
    {
        base.Update();

        if (dbgTeamNum != 1)
        {
            this.teamNum = dbgTeamNum;
        }
        
    }
}
