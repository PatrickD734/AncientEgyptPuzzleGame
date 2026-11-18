using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseHover : MonoBehaviour
{
    public LayerMask interactableLayer;
    public float maxDistance = 5f;

    private GameObject interactText;
    public GameObject hoverObject;

    void Start()
    {
        GameObject interactText = GameObject.Find("Interact_Text");
    }
    private void Update()
    {
        //Getting mouse Position
        Vector2 mousePos = Mouse.current.position.ReadValue();
        
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hoverObject != hitObject)
            {
                hoverObject = hitObject;
                interactText.SetActive(true);
            }
        } else if (hoverObject != null){
            if(interactText != null)
                interactText.SetActive(false);
        }
    }
}
