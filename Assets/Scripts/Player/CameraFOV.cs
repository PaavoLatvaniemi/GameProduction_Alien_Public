using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    [SerializeField] float initialFOV;
    [SerializeField] float zoomFOV;
    [SerializeField] float smooth;

    private float currentFOV;
    private Camera _camera;
    private bool zoom;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.fieldOfView = initialFOV;
        zoomFOV = initialFOV;
    }

    void Update()
    {
        currentFOV = _camera.fieldOfView;

        if (currentFOV != zoomFOV)
        {
            if (zoom)
            {
                if (currentFOV > zoomFOV)
                    _camera.fieldOfView += (-smooth * Time.deltaTime);
                else
                {
                    if (currentFOV <= zoomFOV)
                        _camera.fieldOfView = zoomFOV;
                }
            }
            else
            {
                if (currentFOV < zoomFOV)
                    _camera.fieldOfView -= (-smooth * Time.deltaTime);
                else
                {
                    if (currentFOV >= zoomFOV)
                        _camera.fieldOfView = zoomFOV;
                }
            }
        }
    }

    public void Zoom(float fov)
    {
        zoomFOV = fov;
        zoom = true;
    }

    public void InitZoom()
    {
        zoomFOV = initialFOV;
        zoom = false;
    }
}
