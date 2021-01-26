using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraConfiguration
{
    Quaternion targetOrentiation;
    Vector3 posTarget;

    public float pitch;
    public float yaw;
    public float roll;
    public float fieldOfView;
    public float distance;
    public Vector3 pivot;

    public Quaternion GetRotation()
    {
        targetOrentiation = Quaternion.Euler(pitch, yaw, roll);

        return targetOrentiation;
    }

    public Vector3 GetPosition()
    {

        Vector3 offset = Vector3.back * distance;
        posTarget = pivot + offset;

        return posTarget;
    }
    public void DrawGizmos(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(pivot, 0.25f);
        Vector3 position = GetPosition();
        Gizmos.DrawLine(pivot, position);
        Gizmos.matrix = Matrix4x4.TRS(position, GetRotation(), Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, fieldOfView, 0.5f, 0f, Camera.main.aspect);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
