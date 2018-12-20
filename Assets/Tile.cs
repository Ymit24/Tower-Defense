using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private GameObject visual;
    private int x;
    private int y;

    private SpriteRenderer sr
    {
        get
        {
            if (visual == null) return null;
            return visual.GetComponentInChildren<SpriteRenderer>();
        }
    }
    
    public Tile(int x, int y, Transform tileHolder, Sprite tileSprite)
    {
        this.x = x;
        this.y = y;
        
        createVisual(tileHolder, tileSprite);
    }

    private void createVisual(Transform tileHolder, Sprite tileSprite)
    {
        GameObject tile = new GameObject("Tile_" + x + "_" + y);
        tile.transform.position = new Vector2(x, y);
        tile.transform.SetParent(tileHolder.transform);

        GameObject tileGraphic = new GameObject("Tile_Graphic");
        tileGraphic.transform.SetParent(tile.transform);
        tileGraphic.transform.localPosition = Vector2.zero;
        tileGraphic.transform.localScale = Vector2.one * 0.8f;
        SpriteRenderer sr = tileGraphic.AddComponent<SpriteRenderer>();
        sr.sprite = tileSprite;

        visual = tile;
    }
    
    public void PlaceTower()
    {
        if (sr == null) return;
        sr.color = Color.red;
    }
    
    public void RemoveTower()
    {
        if (sr == null) return;
        sr.color = Color.white;
    }

    public bool HasTower()
    {
        return (sr != null && sr.color == Color.red);
    }
}
