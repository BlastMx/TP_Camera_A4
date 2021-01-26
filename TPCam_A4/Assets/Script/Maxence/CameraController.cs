using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    List<AView> activeViews = new List<AView>();

    float speed = 0.5f;

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

    // Update is called once per frame
    void Update()
    {
        transform.position =  cameraConfiguration.GetPosition();
        transform.rotation = cameraConfiguration.GetRotation();

        Camera.main.fieldOfView = cameraConfiguration.fieldOfView;

        cameraConfiguration.DrawGizmos(Color.yellow);

        GetConfigurationMoyenne();
    }

    public void AddView(AView view)
    {
        activeViews.Add(view);
    }

    public void RemoveView(AView view)
    {
        activeViews.Remove(view);
    }

    public CameraConfiguration GetConfigurationMoyenne()
    {
        CameraConfiguration configMoyenne = new CameraConfiguration();

        float poidsTotal = 0;

        foreach(AView view in activeViews)
        {
            poidsTotal += view.weight;
            configMoyenne.pitch += view.GetConfiguration().pitch * view.weight;
            configMoyenne.yaw += view.GetConfiguration().yaw * view.weight;
            configMoyenne.roll += view.GetConfiguration().roll * view.weight;
            configMoyenne.pivot += view.GetConfiguration().pivot * view.weight;
            configMoyenne.fieldOfView += view.GetConfiguration().fieldOfView * view.weight;
        }
        
        configMoyenne.pitch /= poidsTotal;
        configMoyenne.yaw /= poidsTotal;
        configMoyenne.roll /= poidsTotal;
        configMoyenne.pivot /= poidsTotal;
        configMoyenne.fieldOfView /= poidsTotal;

        return configMoyenne;
    }
}       
