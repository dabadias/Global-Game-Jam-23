using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Circuit : MonoBehaviour
{
    public GameObject from;
    public GameObject to;
    public int size;
    public UnityEvent onTrigger;

    public IEnumerator ActivateCo()
    {
        onTrigger.Invoke();
        yield return 0;
    }
}
