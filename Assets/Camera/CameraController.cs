using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{   
    [SerializeField] private float sensivity = 5f;
    
    private float mouseX;
    private float mouseY;
    
    private void Update(){
        CalculateMouseAxis();

        mouseY = Mathf.Clamp(mouseY, -60f, 60f);

        RotateParent();
        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }

    private void RotateParent(){
        Transform parent = transform.parent;

        parent.transform.localEulerAngles = new Vector3(0, mouseX, 0);
    }

    private void CalculateMouseAxis(){
        mouseX += Input.GetAxis("Mouse X") * sensivity;
        mouseY += Input.GetAxis("Mouse Y") * sensivity;
    }
}
