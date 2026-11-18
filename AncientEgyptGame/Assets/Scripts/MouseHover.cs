using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseHover : MonoBehaviour
{
    public LayerMask interactableLayer;
    public float maxDistance = 5f;

    public GameObject interactText;
    public GameObject hoverObject;
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
                Debug.Log("Started hovering: " + hoverObject.name);
                if (interactText != null)
                    interactText.SetActive(true);
                
            }
        }else if (hoverObject != null){
            Debug.Log("Stopped hovering: " + hoverObject.name);
            if (interactText != null)
                interactText.SetActive(false);
            hoverObject = null;
            
        }
    }
}
