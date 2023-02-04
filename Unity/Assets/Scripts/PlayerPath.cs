using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerPath : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private List<Vector3> _positions;
    private List<Quaternion> _rotations;
    private List<LineRenderer> _lines;
    private float _period = 0.033f;
    private float _nextUpdate = 0.0f;
    private float speed = 10f;
    private bool _rewinding;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _positions = new List<Vector3>();
        _rotations = new List<Quaternion>();
        _lines = new List<LineRenderer>();

        _positions.Add(transform.position);
        _rotations.Add(transform.rotation);
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
        if (Time.time > _nextUpdate)
        {
            _nextUpdate += _period;
            if (!_rewinding) Draw();
        }
        if (_rewinding) Rewind();
    }

    private void Draw()
    {
        var lastPosition = _positions[_positions.Count - 1];
        if (transform.position != lastPosition)
        {
            _positions.Add(transform.position);
            _rotations.Add(transform.rotation);

            var line = new GameObject("Line").AddComponent<LineRenderer>();
            line.SetPosition(0, lastPosition);
            line.SetPosition(1, transform.position);
            _lines.Add(line);
        }
    }

    private void Rewind()
    {
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
}
