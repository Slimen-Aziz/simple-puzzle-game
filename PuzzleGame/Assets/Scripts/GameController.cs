using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Cube[] cubes;
    [SerializeField] private Trigger TR1, TR2;

    [SerializeField] private Text winText;

    private int _score;
    private readonly Cube[,] _cubeGrid = new Cube[5, 5];

    private void InitializeGrid()
    {
        var s = 0;
        for (var i = 0; i < 5; i++)
            for (var j = 0; j < 5; j++)
                _cubeGrid[i, j] = cubes[s++];
    }

    private void RandomizeTriggers()
    {
        do
        {
            TR1.transform.position = new Vector3(Random.Range(0, 4), TR1.transform.position.y, Random.Range(0, 4));
            TR2.transform.position = new Vector3(Random.Range(0, 4), TR2.transform.position.y, Random.Range(0, 4));
        } while (TR1.transform.position == TR2.transform.position);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        InitializeGrid();
        RandomizeTriggers();
    }

    // pull row --> type= -1
    // push row <-- type= 1
    // move column up type= 1
    // move column down type= -1
    public void Move(int RC, int type, bool isRow)
    {
        var countdown = type < 0 ? 4 : 0;
        var compare = type < 0 ? 0 : 4;

        // Move whole row
        if (isRow)
        {
            if (type < 0)
                for (var i = countdown; i > compare; i += type)
                    MoveHorizontal(RC, i, type);
            else
                for (var i = countdown; i < compare; i += type)
                    MoveHorizontal(RC, i, type);
            
            return;
        }
        
        // Move column
        if (type < 0)
            for (var i = countdown; i > compare; i += type)
                MoveVertical(RC, i, type);
        else
            for (var i = countdown; i < compare; i += type)
                MoveVertical(RC, i, type);
    }

    private void MoveHorizontal(int row, int i, int type)
    {
        if (_cubeGrid[row, i] != null) return;
        if (_cubeGrid[row, i + type] == null) return;
        if (_cubeGrid[row, i + type].IsBlocked) return;
        
        _cubeGrid[row, i + type].newPos = new Vector3(
            _cubeGrid[row, i + type].transform.position.x,
            _cubeGrid[row, i + type].transform.position.y,
            Mathf.RoundToInt(_cubeGrid[row, i + type].transform.position.z + type));
        
        _cubeGrid[row, i] = _cubeGrid[row, i + type];
        _cubeGrid[row, i + type] = null;
    }

    private void MoveVertical(int col, int i, int type)
    {
        if (_cubeGrid[i, col] != null) return;
        if (_cubeGrid[i + type, col] == null) return;
        if (_cubeGrid[i + type, col].IsBlocked) return;
        
        _cubeGrid[i + type, col].newPos = new Vector3(
            Mathf.RoundToInt(_cubeGrid[i + type, col].transform.position.x + type),
            _cubeGrid[i + type, col].transform.position.y,
            _cubeGrid[i + type, col].transform.position.z);
        
        _cubeGrid[i, col] = _cubeGrid[i + type, col];
        _cubeGrid[i + type, col] = null;
    }

    private void Update()
    {
        if (!CheckEmpty(TR1) || !CheckEmpty(TR2)) return;
        winText.text = $"Score: {++_score}";
        RandomizeTriggers();
    }

    private bool CheckEmpty(Trigger trig)
    {
        var triggerPosition = trig.transform.position;
        var posR = Mathf.RoundToInt(4 - triggerPosition.x);
        var posC = Mathf.RoundToInt(4 - triggerPosition.z);

        if (trig.IsEmpty && _cubeGrid[posR, posC] == null) return true;

        return false;
    }
    
}