using UnityEngine;

public class SpellNode : MonoBehaviour
{
    public Material notSelectedMaterial;
    public Material selectedMaterial;
    Renderer Renderer;

    public int x;
    public int y;
    private void Start()
    {
        Renderer = GetComponent<Renderer>();
        notSelectedMaterial = Renderer.material;
    }
    public void Highlight()
    {
        Renderer.material = selectedMaterial;
    }
    public void RemoveHighlight()
    {
        Renderer.material=notSelectedMaterial;
    }
}
