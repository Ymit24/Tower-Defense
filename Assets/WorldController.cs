using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public int Width, Height;
    public Sprite TileSprite;
    private SpriteRenderer[,] tileGraphics;
    void Start()
    {
        GameObject tileHolder = new GameObject("TileHolder");
        tileGraphics = new SpriteRenderer[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                GameObject tile = new GameObject("Tile_" + x + "_" + y);
                tile.transform.position = new Vector2(x, y);
                tile.transform.SetParent(tileHolder.transform);

                GameObject tileGraphic = new GameObject("Tile_Graphic");
                tileGraphic.transform.SetParent(tile.transform);
                tileGraphic.transform.localPosition = Vector2.zero;
                tileGraphic.transform.localScale = Vector2.one * 0.8f;
                SpriteRenderer sr = tileGraphic.AddComponent<SpriteRenderer>();
                sr.sprite = TileSprite;
                tileGraphics[x, y] = sr;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int tileX = (int) (worldMousePosition.x + 0.5f);
            int tileY = (int) (worldMousePosition.y + 0.5f);
            Debug.Log(tileX + " " + tileY);
            if (tileX >= 0 && tileX <= Width - 1 && tileY >= 0 && tileY <= Height - 1)
            {
                tileGraphics[tileX, tileY].color = tileGraphics[tileX, tileY].color == Color.white ? Color.red : Color.white;
            }
        }
    }
}
