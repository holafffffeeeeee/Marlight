using UnityEngine;
using UnityEngine.Tilemaps;

public class BackGroundLayerOrder : MonoBehaviour
{
    private TilemapRenderer Tilemaprenderer;

    void Start()
    {
        Tilemaprenderer = GetComponent<TilemapRenderer>();
    }

    void Update()
    {
        // Automatically adjust the sorting order based on the Y position
        Tilemaprenderer.sortingOrder = -(int)(transform.position.y * 100);
    }
}
