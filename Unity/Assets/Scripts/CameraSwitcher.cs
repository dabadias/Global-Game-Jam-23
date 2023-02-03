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
                v_cam.Follow = camera_targets[0];
                break;
            case "2":
                v_cam.Follow = camera_targets[1];
                break;
            default:
                break;
        }
    }
}
