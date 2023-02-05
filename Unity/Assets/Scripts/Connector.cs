using System;
using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class Connector : MonoBehaviour
{
    private PlayerSwitcher _playerSw;
    private StarterAssetsInputs _input;
    private bool _on;
    public UnityEvent onTrigger;

    private void Start()
    {
        _playerSw = GameObject.FindWithTag("PlayerController").GetComponent<PlayerSwitcher>();
        _input = _playerSw.currentPlayer.GetComponent<StarterAssetsInputs>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_on && _input.interact && other.gameObject == _playerSw.currentPlayer)
        {
            StartCoroutine(ActivateCo());
        }
    }

    private IEnumerator ActivateCo()
    {
        _on = true;
        onTrigger.Invoke();
        yield return 0;
    }
}
