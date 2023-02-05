using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int treeConnections;
    private int _treeConnectionsCurrent = 0;

    public void IncreaseTreeConnections()
    {
        _treeConnectionsCurrent++;
        if (_treeConnectionsCurrent == treeConnections)
        {
            // TODO: win
            Debug.Log("COMPLETE");
        }
    }
}
