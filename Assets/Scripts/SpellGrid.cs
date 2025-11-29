using UnityEngine;

public class SpellGrid : MonoBehaviour
{
    public int gridSize = 3;
    public GameObject nodePrefab;
    public float spacing = 1f;

    public SpellNode[,] nodes;
    public bool regenerateGrid;
    void Start()
    {
        GenerateGrid(gridSize);
    }
    private void Update()
    {
        if(regenerateGrid)//Regenerates the grid for debugging purposes
        {
            DeleteGrid();
            GenerateGrid(gridSize);
            regenerateGrid = false;
        }
    }

    public void GenerateGrid(int size)
    {
        nodes = new SpellNode[size, size];

        float offset = (size - 1) * spacing * 0.5f;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Vector3 pos = new Vector3(x * spacing - offset, y * spacing - offset, 0);
                GameObject obj = Instantiate(nodePrefab, pos, Quaternion.identity, transform);

                SpellNode node = obj.GetComponent<SpellNode>();
                node.x = x;
                node.y = y;

                nodes[x, y] = node;
            }
        }
    }
    public void DeleteGrid()
    {
        foreach (SpellNode node in nodes)
        {
            Destroy(node.gameObject);
        }
    }
}
