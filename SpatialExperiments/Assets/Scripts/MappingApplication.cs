﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;

public class MappingApplication : MonoBehaviour {

    private enum ApplicationState
    {
        None,
        Scanning,
        ScanningEnded,
        Placement
    }

    const float ScanningDuration = 20f;
    const float MaxHitInfoDistance = 20f;
    const int CursorLayer = 10;
    ApplicationState _applicationState = ApplicationState.None;

    //public Camera camera;
    public GameObject cursor;

    // Use this for initialization
    void Start ()
    {
        _applicationState = ApplicationState.Scanning;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(_applicationState == ApplicationState.Scanning)
        {
            if ((Time.time - SpatialMappingManager.Instance.StartTime) < ScanningDuration)
            {
                Debug.Log("Keep scanning the room");
                return;
            }
            else
            {
                Debug.Log("Scanning complete. End scanning");
                _applicationState = ApplicationState.ScanningEnded;
            }
        }

        if(_applicationState == ApplicationState.ScanningEnded)
        {
            Debug.Log("Scanning complete. Start placement");
            cursor.SetActive(true);
            _applicationState = ApplicationState.Placement;
        }

        if(_applicationState == ApplicationState.Placement)
        {
            Ray ray = new Ray(CameraCache.Main.transform.position, CameraCache.Main.transform.forward);
            int layerMask = ~(1 << CursorLayer);
            RaycastHit hitInfo;
            if (Physics.Raycast(
                ray,
                out hitInfo,
                MaxHitInfoDistance,
                layerMask
                ))
            {
                Debug.Log("Placement. Something was hit");
                cursor.transform.position = hitInfo.point;
                cursor.transform.up = hitInfo.normal;
            }
            else
            {
                Debug.Log("Placement. Nothing was hit");
            }

        }
    }
}
