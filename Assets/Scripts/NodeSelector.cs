using UnityEngine;
using UnityEngine.InputSystem;

public class NodeSelector : MonoBehaviour
{
    public SpellGrid grid;
    private bool isDrawing = false;

    private InputAction clickAction;

    void Awake()
    {
        // Create a new InputAction bound to left mouse button
        clickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");

        // Subscribe to events
        clickAction.started += OnClickStarted;
        clickAction.canceled += OnClickCanceled;
    }

    void OnEnable()
    {
        clickAction.Enable();
    }

    void OnDisable()
    {
        clickAction.Disable();
    }

    private void OnClickStarted(InputAction.CallbackContext ctx)
    {
        isDrawing = true;
        grid.selectedNodes.Clear();
    }

    private void OnClickCanceled(InputAction.CallbackContext ctx)
    {
        isDrawing = false;

        // grid.ProcessSelection();
       
        foreach (var node in grid.selectedNodes)
        {
            node.RemoveHighlight();
        }

        // Clear the list afterwards
        grid.selectedNodes.Clear();

       
       
    }

    void Update()
    {
        if (isDrawing)
        {
            DetectNodeHover();
        }
    }

    void DetectNodeHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            SpellNode node = hit.collider.GetComponent<SpellNode>();
            if (node != null && !grid.selectedNodes.Contains(node))
            {
                grid.selectedNodes.Add(node);
                node.Highlight();
            }
        }
    }
}
