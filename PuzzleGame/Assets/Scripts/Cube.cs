using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Material StopMat;
    [SerializeField] private Material DefMat;
    
    public Vector3 newPos;
    
    public bool IsBlocked { get; private set; }

    private void Awake()
    {
        newPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPos, 3 * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (!IsBlocked)
        {
            GetComponent<Renderer>().material = StopMat;
            IsBlocked = true;
            return;
        }
        
        GetComponent<Renderer>().material = DefMat;
        IsBlocked = false;
    }
    
}