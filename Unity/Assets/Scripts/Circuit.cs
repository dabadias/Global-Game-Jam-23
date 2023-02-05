using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Circuit : MonoBehaviour
{
    public GameObject blind;
    public GameObject from;
    public GameObject to;
    public int size;
    public UnityEvent onTrigger;
    public MeshRenderer _lampFrom, _accentFrom, _lampTo, _accentTo;
    private Color _lampColor, _accentColor;
    private PlayerSwitcher _playerSw;

    private void Start()
    {
        _playerSw = GameObject.FindWithTag("PlayerController").GetComponent<PlayerSwitcher>();

        _lampColor = _lampFrom.material.color;
        _accentColor = _accentFrom.material.color;
        PaintCircuit();
    }

    public IEnumerator ActivateCo()
    {
        onTrigger.Invoke();
        yield return 0;
    }

    public void PaintCircuit()
    {
        if (_playerSw.currentPlayer == blind)
        {
            _lampFrom.material.color = new Color(255f, 255f, 255f);
            _accentFrom.material.color = new Color(0f, 0f, 0f);
            _lampTo.material.color = new Color(255f, 255f, 255f);
            _accentTo.material.color = new Color(255f, 255f, 255f);
        }
        else
        {
            _lampFrom.material.color = _lampColor;
            _accentFrom.material.color = _accentColor;
            _lampTo.material.color = _lampColor;
            _accentTo.material.color = _accentColor;
        }
    }
}
