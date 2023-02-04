using System;
using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject[] playersThatCanSee;
    private GameObject playerInteracting;
    private PlayerSwitcher _playerSw;
    private StarterAssetsInputs _input;
    private MeshRenderer _mesh;
    private bool _inRange;
    private bool _on;
    public UnityEvent onTrigger;

    private void Start()
    {
        _playerSw = GameObject.FindWithTag("PlayerController").GetComponent<PlayerSwitcher>();
        _input = _playerSw.currentPlayer.GetComponent<StarterAssetsInputs>();
        _mesh = GetComponent<MeshRenderer>();
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
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        _mesh.material.color = new Color(0f, 255f, 0f);
        _on = true;
        onTrigger.Invoke();
    }

    public void OnPlayerSwitch()
    {
        ShowHide();
        UpdateInputs();
    }

    private void UpdateInputs() => _input = _playerSw.currentPlayer.GetComponent<StarterAssetsInputs>();

    private void ShowHide() => _mesh.enabled = Array.Exists(playersThatCanSee, e => e == _playerSw.currentPlayer);
}
