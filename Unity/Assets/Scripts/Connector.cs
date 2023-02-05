using System;
using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class Connector : MonoBehaviour
{
    public GameObject[] playersThatCanSee;
    private GameObject playerInteracting;
    private PlayerSwitcher _playerSw;
    private StarterAssetsInputs _input;
    private bool _inRange;
    private bool _on;
    public UnityEvent onTrigger;
    public UnityEvent onTriggerAgain;

    private void Start()
    {
        _playerSw = GameObject.FindWithTag("PlayerController").GetComponent<PlayerSwitcher>();
        _input = _playerSw.currentPlayer.GetComponent<StarterAssetsInputs>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (_input.interact && other.gameObject == _playerSw.currentPlayer)
        {
            if (_on) StartCoroutine(ActivateCo(onTriggerAgain));
            else StartCoroutine(ActivateCo(onTrigger));
        }
    }

    private IEnumerator ActivateCo(UnityEvent trigger)
    {
        _on = !_on;
        trigger.Invoke();
        yield return 0;
    }

    public void OnPlayerSwitch()
    {
        UpdateInputs();
    }

    private void UpdateInputs() => _input = _playerSw.currentPlayer.GetComponent<StarterAssetsInputs>();
}
