using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float pickupRange = 5f; // Range for raycast to detect crystals
    public LayerMask pickupLayer; // Layer mask for objects that can be picked up (set in Inspector)

    private void Update()
    {
        // Check for mouse click (or other input method)
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from camera to detect objects within pickup range
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                // Check if the object hit is a crystal
                CrystalItem crystalItem = hit.collider.GetComponent<CrystalItem>();

                if (crystalItem != null)
                {
                    // Add crystal item to inventory
                    InventoryManager.instance.AddCrystal(crystalItem);
                    // Optionally, play a sound effect or visual effect indicating pickup
                    Destroy(hit.collider.gameObject); // Destroy the crystal object after pickup
                }
            }
        }
    }
}
