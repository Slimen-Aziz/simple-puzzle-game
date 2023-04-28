using UnityEditor;
using UnityEngine;

public static class MenuScript
{
    [MenuItem("Tools/Assign Tile Material")]
    public static void AssignTileMat()
    {
        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        var mat = Resources.Load<Material>("Tile");

        foreach (var tile in tiles)
            tile.GetComponent<Renderer>().material = mat;
    }

    [MenuItem("Tools/Assign Cube Material")]
    public static void AssignCubeMat()
    {
        var cubes = GameObject.FindGameObjectsWithTag("mvCube");
        var mat = Resources.Load<Material>("mvCube");

        foreach (var cube in cubes)
            cube.GetComponent<Renderer>().material = mat;
    }

    [MenuItem("Tools/Assign Cube Script")]
    public static void AssignCubeSc()
    {
        var cubes = GameObject.FindGameObjectsWithTag("mvCube");

        foreach (var cube in cubes)
            cube.AddComponent<Cube>();
    }
    
}