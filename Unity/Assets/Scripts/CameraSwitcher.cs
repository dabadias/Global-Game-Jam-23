using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    private CinemachineVirtualCamera _vcam;
    public Transform[] camera_targets;


    private void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        ChangeFollow();
    }

    private void ChangeFollow()
    {
        try
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _vcam.Follow = camera_targets[0];
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _vcam.Follow = camera_targets[1];
            }
        }
        catch (System.IndexOutOfRangeException ex)
        {
            Debug.LogError(ex);
        }
    }
}
