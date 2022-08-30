using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] public int gridWidth;
    [SerializeField] public int gridHeight;

    [SerializeField] public Tile tilePrefab;

    [SerializeField] private Transform cam;

    private Dictionary<Vector2, Tile> tiles;

    void Awake()
    {
        instance = this;
        

        
    }

    void Start()
    {
        GenerateGrid();
        cam.transform.position = new Vector3((float)gridWidth / 2 - 0.5f, (float)gridHeight / 2 - 0.5f, -10);
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);

                spawnedTile.name = $"Tile{x}{y}";

                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

       
    }

    public Tile GetTileAtPos(Vector2 pos)
    {
        if(tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }

    
}
