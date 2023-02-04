using UnityEngine;

public class Translation : MonoBehaviour
{
    public Vector3 translation;
    public float speed;
    private bool start;
    private Vector3 destination;

    private void Start()
    {
        destination = transform.localPosition + translation;
    }

    private void Update()
    {
        if (start)
        {
            if (transform.localPosition == destination)
            {
                start = false;
            }
            else
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination, speed * Time.deltaTime);
            }
        }
    }

    public void StartTranslation() => start = true;
}
