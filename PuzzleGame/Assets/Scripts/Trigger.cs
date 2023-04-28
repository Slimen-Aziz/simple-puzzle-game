using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool IsEmpty { get; private set; }

    private void OnTriggerEnter(Collider col)
    {
        IsEmpty = false;
    }

    private void OnTriggerExit(Collider col)
    {
        IsEmpty = true;
    }
    
}