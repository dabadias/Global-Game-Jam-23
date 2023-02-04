using StarterAssets;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject playerThatCanSee;
    private StarterAssetsInputs _input;
    private PlayerSwitcher _playerSw;
    private MeshRenderer _mesh;
    private bool _inRange;
    private bool _on;

    private void Start()
    {
        _input = GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>();
        _playerSw = GameObject.FindWithTag("PlayerController").GetComponent<PlayerSwitcher>();
        _mesh = gameObject.GetComponent<MeshRenderer>();
        _inRange = false;
        _on = false;
    }

    private void Update()
    {
        Paint();
        ShowHide();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _inRange = false;
        }
    }

    private void Paint()
    {
        if (!_on && _inRange && _input.interact)
        {
            _mesh.material.color = new Color(0f, 255f, 0f);
            _on = true;
        }
    }

    private void ShowHide()
    {
        _mesh.enabled = _playerSw.currentPlayer == playerThatCanSee;
    }
}
