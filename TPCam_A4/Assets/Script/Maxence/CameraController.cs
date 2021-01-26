using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public static CameraController instance;
    public CameraConfiguration cameraConfiguration;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =  cameraConfiguration.GetPosition();
        transform.rotation = cameraConfiguration.GetRotation();

        Camera.main.fieldOfView = cameraConfiguration.fieldOfView;

        cameraConfiguration.DrawGizmos(Color.yellow);
    }
}
