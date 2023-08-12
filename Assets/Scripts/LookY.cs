using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float sensitivity = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _mouseY = Input.GetAxis("Mouse Y");
        Vector3 newRotation = transform.localEulerAngles;

        newRotation.x -= _mouseY * sensitivity;
        transform.localEulerAngles = newRotation;
    }
}
