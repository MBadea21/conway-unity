using UnityEngine;

public class ConwayManager : MonoBehaviour
{
    public static ConwayManager instance { get; private set; }

    public static int gridSize = 50;
    public float scaleFactor = 0.1f;

    public bool[,] grid = new bool[gridSize, gridSize];

    private Texture2D texture;


    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        populateGrid();

        texture = new Texture2D(gridSize, gridSize, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point; // No anti-aliasing

        GetComponent<Renderer>().material.mainTexture = texture;
    }

    private void populateGrid()
    {

        for (int column = 0; column < gridSize; column++ )
        {
            for (int row=0; row < gridSize; row++)
            {
                float val = Random.Range(0, 1);
                grid[column,row] = (val == 1);

            }
        }
    }

    void UpdateTexture()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Color color = grid[i, j] ? Color.white : Color.black;
                texture.SetPixel(i, j, color);

            }
        }

        texture.Apply();
    }

    private void Update()
    {
        // transform.localScale = new Vector3(gridSize * scaleFactor, gridSize * scaleFactor, 1);
        UpdateTexture();
    }
}
