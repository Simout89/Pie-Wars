using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Script.SelectedEntitys
{
    public class SelectedEntitysModel : MonoBehaviour
    {
        /// <summary>
        /// вся логика
        /// </summary>

        [Inject] private HistorySelectedData _historySelectedData;

        [SerializeField]
        public List<IEntity> SelectedEntitys
        {
            //для получения массива выделенных entity
            get
            {
                return this._selectedEntitys;
            }
            set { }
        }

        [SerializeField] private List<IEntity> _selectedEntitys = new(); //выбраные сейчас entity





        public void AddSelectedUnit(IEntity ent)
        {
            if (this._selectedEntitys.Contains(ent))
            {

            }
            else
            {
                _selectedEntitys.Add(ent);
                ent.OnOutline();
                _historySelectedData.NewRecordInHistory(_selectedEntitys);
            }
        }

        public void AddNewSelectedUnit(IEntity entity)
        {
            ClearSelectedUnits();
            _selectedEntitys.Add(entity);

            foreach (IEntity ent in _selectedEntitys)
            {
                ent.OnOutline();
            }

            _historySelectedData.NewRecordInHistory(_selectedEntitys);
        }

        public void SetNewSelectedUnitList(List<IEntity> unitList)
        {
            //при выделение новых entity
            this.ClearSelectedUnits();
            this._selectedEntitys = new(unitList);
            _historySelectedData.NewRecordInHistory(_selectedEntitys);
        }

        public void SetOldSelectedUnitList(List<IEntity> entityList)
        {
            //при выборе entity, которые были выделены ранее
            this.ClearSelectedUnits();
            if (entityList == null || entityList.Count == 0)
            {
                Debug.Log("null");
            }
            else
            {
                Debug.Log("Not null");
                this._selectedEntitys = new(entityList);
                foreach (IEntity ent in _selectedEntitys)
                {
                    ent.OnOutline();
                }
            }
        }



        public void ClearSelectedUnits()
        {

            foreach (IEntity entity in _selectedEntitys)
            {
                entity.OffOutline();
            }

            _selectedEntitys.Clear();

        }

        public void Update()
        {
            SelectedEntitys = _selectedEntitys;
        }

    }
}