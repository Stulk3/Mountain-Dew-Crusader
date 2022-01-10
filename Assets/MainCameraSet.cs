using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraSet : MonoBehaviour
{
    private Canvas Canvas;
    private GameObject CameraGameObject;
    private Camera Camera;
    private void Awake()
    {
        CameraGameObject = GameObject.Find("Main Camera");
        Camera = CameraGameObject.GetComponent<Camera>();
        Canvas = this.GetComponent<Canvas>();
        Canvas.worldCamera = Camera;
    }
}
