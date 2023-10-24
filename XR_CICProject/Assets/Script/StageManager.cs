using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public Camera cam;

    public Transform camPos;


    void Start()
    {
        cam.transform.position = camPos.position;
    }
}