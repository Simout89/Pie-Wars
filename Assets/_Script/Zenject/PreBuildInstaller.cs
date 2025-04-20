using UnityEngine;
using Zenject;

public class PreBuildInstaller : MonoInstaller
{

    [SerializeField] private SelectedEntitysController _selectedEntitysController;
    [SerializeField] private SelectedEntitysModel _selectedEntitysModel;
    
    [SerializeField] private HistorySelectedData _historySelectedData;
    [SerializeField] private HistorySelectedController _historySelectedController;
    
    
    [SerializeField] private GroupSistemController _groupSistemController;
    [SerializeField] private EntitysController _entitysController;

    [SerializeField] private ObjectsPoolData _objectsPoolData;
    [SerializeField] private UIService _uIService;
    [SerializeField] private ObjectInRect _objectInRect;
    [SerializeField] private MapClickHendler _mapClickHendler;
    [SerializeField] private HexGrid _HexGrid;

    public override void InstallBindings()
    {
        Container.Bind<SelectedEntitysController>().FromInstance(_selectedEntitysController).AsSingle();
        Container.Bind<SelectedEntitysModel>().FromInstance(_selectedEntitysModel).AsSingle();

        Container.Bind<HistorySelectedData>().FromInstance(_historySelectedData).AsSingle();
        Container.Bind<HistorySelectedController>().FromInstance(_historySelectedController).AsSingle();

        Container.Bind<GroupSistemController>().FromInstance(_groupSistemController).AsSingle();

        Container.Bind<EntitysController>().FromInstance(_entitysController).AsSingle();

        Container.Bind<ObjectsPoolData>().FromInstance(_objectsPoolData).AsSingle();
        Container.Bind<UIService>().FromInstance(_uIService).AsSingle();
        Container.Bind<ObjectInRect>().FromInstance(_objectInRect).AsSingle();
        Container.Bind<MapClickHendler>().FromInstance(_mapClickHendler).AsSingle();
        Container.Bind<HexGrid>().FromInstance(_HexGrid).AsSingle();
       



    }
}