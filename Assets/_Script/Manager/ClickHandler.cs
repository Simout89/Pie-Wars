using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private CameraContoller _cameraContoller;
    [SerializeField] private UnitControl _unitControl;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = default;
            if (Physics.Raycast(ray, out hit))
            {
                _unitControl.ClickRMB(hit.point, hit.collider.gameObject);
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = default;
            if(CheckNotEntity(hit , ray)) return;

            CheckOnUnit(hit, ray);
        }


        if (Input.GetMouseButtonUp(0))
        {
            _cameraContoller.CameraMoveState = true;
        }
    }


    private bool CheckNotEntity(RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "Plane")
        {
            return true;
        }

        _cameraContoller.CameraMoveState = false;
        return false;
    }
    
    private void CheckOnUnit(RaycastHit hit, Ray ray)
    {
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.TryGetComponent(out UnitModel unitModel))
        {
            _unitControl.ClickOnUnit(unitModel);
        }
    }
}
