using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractionController : MonoBehaviour
{
    public ToolController toolController;
    [SerializeField] private LayerMask interactiveMask;
    [SerializeField] private Transform rayOrigin;
    private Collider buferCollider;
    private InteractiveObject buferInteractiveObject;
    private ToolItem buferToolItem;

    public Action<string> changeMessageEvent;

    void Start()
    {
        
    }

    void Update()
    {
        Use();
    }

    void FixedUpdate()
    {
        CheckRay();
    }

    private void CheckRay()
    {
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out RaycastHit hit, 5f, interactiveMask))
        {
            if(hit.collider != buferCollider)
            {
                buferCollider = hit.collider;

                if(buferCollider.TryGetComponent<InteractiveObject>(out buferInteractiveObject))
                {
                    changeMessageEvent?.Invoke(buferInteractiveObject.GetMessage(toolController));
                }
                else if(buferCollider.TryGetComponent<ToolItem>(out buferToolItem))
                {
                    changeMessageEvent?.Invoke(buferToolItem.GetMessage());
                }
            }
        }
        else
        {
            changeMessageEvent?.Invoke(string.Empty);
            buferCollider = null;
            buferInteractiveObject = null;
            buferToolItem = null;
        }
    }

    private void Use()
    {
        if(Input.GetMouseButtonDown(0) && buferInteractiveObject != null)
        {
            buferInteractiveObject.Use(toolController);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if(buferToolItem != null)
            {
                toolController.ChangeTool(buferToolItem);
            }
            else
            {
                toolController.DropCurrentTool();
            }
            buferToolItem = null;
            buferCollider = null;
        }
    }
}
