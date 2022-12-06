using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHolder : MonoBehaviour
{
    public Transform cameraPos;
    public float CAMy;
    public float CAMZ;
    private static Quaternion Change(float x, float y, float z)
    {
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(x, y, z, 1);
        return newQuaternion;
    }
    void Update()
    {
        CAMy = cameraPos.transform.rotation.y;
        CAMZ = cameraPos.transform.rotation.z;
        transform.position = cameraPos.position;
        transform.rotation = Change(0, CAMy, 0);
    }
}
