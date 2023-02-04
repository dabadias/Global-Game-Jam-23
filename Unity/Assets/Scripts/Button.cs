using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public GameObject[] playersThatCanSee;
    private GameObject playerInteracting;
    private PlayerSwitcher _playerSw;
    private MeshRenderer _mesh;
    private bool _inRange;
    private bool _on;
    public UnityEvent onTrigger;

    private void Start()
    {
        _playerSw = GameObject.FindWithTag("PlayerController").GetComponent<PlayerSwitcher>();
        _mesh = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        ShowHide();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(_playerSw.currentPlayer.GetComponent<StarterAssetsInputs>().interact);
        if (!_on && _playerSw.currentPlayer.GetComponent<StarterAssetsInputs>().interact && other.gameObject == _playerSw.currentPlayer)
        {
            Activate();
        }
    }

    private void Activate()
    {
        _mesh.material.color = new Color(0f, 255f, 0f);
        _on = true;
        onTrigger.Invoke();
    }

    private void ShowHide()
    {
        _mesh.enabled = Array.Exists(playersThatCanSee, e => e == _playerSw.currentPlayer);
    }
}
