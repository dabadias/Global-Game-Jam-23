using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;

public class PlayerPath : MonoBehaviour
{
    public Transform trail;
    public TMP_Text capacity;
    private GameObject endSocket;
    private StarterAssetsInputs _input;
    private List<Vector3> _positions;
    private List<Quaternion> _rotations;
    private List<Transform> _lines;
    private float speed = 10f;
    private bool _rewinding;
    private bool _canDraw;
    private int size;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _positions = new List<Vector3>();
        _rotations = new List<Quaternion>();
        _lines = new List<Transform>();
    }

    private void Update()
    {
        if (_positions.Count > 2 && _input.rewind)
        {
            _rewinding = true;
        }
    }

    private void FixedUpdate()
    {
        if (_rewinding || _positions.Count == size) Rewind();
        else if (_canDraw) Draw();
    }

    private void Draw()
    {
        var lastPosition = _positions[_positions.Count - 1];
        if (transform.position != lastPosition)
        {
            _positions.Add(transform.position);
            _rotations.Add(transform.rotation);

            var c = Instantiate(trail, lastPosition, Quaternion.identity);
            c.LookAt(transform.position);
            _lines.Add(c);
            capacity.text = $"{size - _positions.Count}/{size}";
        }
    }

    private void Rewind()
    {
        _rewinding = true;
        if (_positions.Count > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _positions[_positions.Count - 1], speed * Time.deltaTime);
            if (transform.position == _positions[_positions.Count - 1])
            {
                _positions.RemoveAt(_positions.Count - 1);

                transform.rotation = _rotations[_rotations.Count - 1];
                _rotations.RemoveAt(_rotations.Count - 1);

                Destroy(_lines[_lines.Count - 1].gameObject);
                _lines.RemoveAt(_lines.Count - 1);
            }
        }
        else
        {
            _rewinding = false;
        }
    }

    public void StartDrawing(int size)
    {
        this.size = size;
        capacity.text = $"{size - _positions.Count}/{size}";

        _positions.Add(transform.position);
        _rotations.Add(transform.rotation);

        _canDraw = true;
    }

    public void StopDrawing(GameObject socketThatCalled)
    {
        if (socketThatCalled == endSocket)
        {
            _canDraw = false;
            capacity.text = "";
        }
    }

    public void SetSocket(GameObject socket) => endSocket = socket;
}
