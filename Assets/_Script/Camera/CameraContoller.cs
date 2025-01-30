using System;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float sensivity;
    public bool CameraMoveState {private get; set; }
    
    private void Update()
    {
        if(CameraMoveState)
            cameraTarget.transform.position += new Vector3(SimpleInput.GetAxis("HorizontalCamera"), 0 ,SimpleInput.GetAxis("VerticalCamera")) / sensivity;
    }

    private void LateUpdate()
    {
        Vector3 smoothPosition = Vector3.Lerp(a:camera.position, b:cameraTarget.position, t:0.125F);
        camera.position = smoothPosition;
    }
    
}
