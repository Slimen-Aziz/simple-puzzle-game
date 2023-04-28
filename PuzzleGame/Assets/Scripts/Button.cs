using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private GameController controller;
    [SerializeField] private bool isRow;
    [SerializeField] private int RC;
    [SerializeField] private int type;

    private void OnMouseDown()
    {
        controller.Move(RC, type, isRow);
    }
    
}