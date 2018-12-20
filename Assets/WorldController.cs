using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public int Width, Height;
    public Sprite TileSprite;
    private Tile[,] tiles;
    
    void Start()
    {
        GameObject tileHolder = new GameObject("TileHolder");
        tiles = new Tile[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                tiles[x, y] = new Tile(x, y, tileHolder.transform, TileSprite);
            }
        }

        MouseController.OnClick += OnClick;
    }

    private void OnClick(bool down, int button, Vector2 mousePosition)
    {
        if (down == false) return;
        
        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        int tileX = (int) (worldMousePosition.x + 0.5f);
        int tileY = (int) (worldMousePosition.y + 0.5f);

        if (!(tileX >= 0 && tileX <= Width - 1 && tileY >= 0 && tileY <= Height - 1))
        {
            return;
        }

        if (button == 0)
        {
            Tile tile = tiles[tileX, tileY];
            if (tile.HasTower() == false)
            {
                tile.PlaceTower();
            }
        }

        if (button == 1)
        {
            Tile tile = tiles[tileX, tileY];
            if (tile.HasTower() == true)
            {
                tile.RemoveTower();
            }
        }
    }
}
