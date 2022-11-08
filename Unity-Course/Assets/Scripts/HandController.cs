using UnityEngine;

public class HandController : MonoBehaviour
{
    [Header("Variables")]
    public float rayDistance = 100f;
    public LayerMask whatIsInteractible;
    public Transform rayOrigin;
    public bool canInteract;
    private RaycastHit _hit;
    public static HandController Instance { get; private set; }

    private void Awake()
    {
        
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    
    public void Interact()
    {
        if (!canInteract) return;
        Debug.Log("On interragit avec " + _hit.collider.name);
    }
    
    private void Update()
    {
        
        if (Physics.Raycast(rayOrigin.position, rayOrigin.forward, out _hit, rayDistance, whatIsInteractible))
        {
            if(canInteract) return;
            canInteract = true;
        }
        else
        {
            if(!canInteract) return;
            canInteract = false;
        }
    }
}
