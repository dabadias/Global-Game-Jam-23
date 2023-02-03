using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform[] camera_targets;
    private CinemachineVirtualCamera v_cam;


    private void Start()
    {
        v_cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        ChangeFollow();
    }

    private void ChangeFollow()
    {
        switch (Input.inputString)
        {
            case "1":
                if (camera_targets.Length > 0) v_cam.Follow = camera_targets[0];
                break;
            case "2":
                if (camera_targets.Length > 1) v_cam.Follow = camera_targets[1];
                break;
            default:
                break;
        }
    }
}
