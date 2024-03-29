using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingMaterial : MonoBehaviour
{
    public LineTextureMode textureMode = LineTextureMode.Stretch;
    public float tileAmount = 1.0f;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.textureMode = textureMode;
        lr.material.SetTextureScale("_MainTex", new Vector2(tileAmount, 1.0f));
    }

    void OnGUI()
    {
        textureMode = GUI.Toggle(new Rect(25, 25, 200, 30), textureMode == LineTextureMode.Tile, "Tiled") ? LineTextureMode.Tile : LineTextureMode.Stretch;

        if (textureMode == LineTextureMode.Tile)
        {
            GUI.Label(new Rect(25, 60, 200, 30), "Tile Amount");
            tileAmount = GUI.HorizontalSlider(new Rect(125, 65, 200, 30), tileAmount, 0.1f, 4.0f);
        }
    }
}
