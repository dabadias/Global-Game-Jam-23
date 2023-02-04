using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject[] players;
    private CinemachineVirtualCamera _vcam;
    private List<Transform> _cameraTargets;
    private List<PlayerInput> _playerInputs;
    private InputDevice[] _in;
    private int _currentPlayer;


    private void Start()
    {
        _vcam = GetComponent<CinemachineVirtualCamera>();
        _cameraTargets = new List<Transform>();
        _playerInputs = new List<PlayerInput>();

        if (players.Length == 0) throw new System.Exception(this.GetType().Name + " is missing players.");

        foreach (var player in players)
        {
            _cameraTargets.Add(player.GetComponent<StarterAssets.FirstPersonController>().CinemachineCameraTarget.transform);
            _playerInputs.Add(player.GetComponent<PlayerInput>());
        }

        _in = new InputDevice[_playerInputs[0].devices.Count];
        for (int i = 0; i < _playerInputs[0].devices.Count; i++)
        {
            _in[i] = _playerInputs[0].devices[i];
        }
    }

    private void Update()
    {
        ChangeFollow();
    }

    private void ChangeFollow()
    {
        try
        {
            int _newPlayer = -1;

            if (Input.GetKeyDown(KeyCode.Alpha1)) _newPlayer = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2)) _newPlayer = 1;

            if (_newPlayer != -1 && _newPlayer != _currentPlayer)
            {
                _vcam.Follow = _cameraTargets[_newPlayer];
                _playerInputs[_currentPlayer].enabled = false;
                _playerInputs[_newPlayer].enabled = true;
                _playerInputs[_newPlayer].SwitchCurrentControlScheme("KeyboardMouse", _in); // This shouldn't be needed...
                _currentPlayer = _newPlayer;
            }
        }
        catch (System.IndexOutOfRangeException ex)
        {
            Debug.LogError(ex);
        }
    }
}
