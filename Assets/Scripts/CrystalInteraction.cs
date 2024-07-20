using UnityEngine;

public class CrystalInteraction : MonoBehaviour
{
    public float interactionRange = 5f; // Range for raycast to detect crystals
    public LayerMask crystalLayer; // Layer mask for crystals (set in Inspector)

    private void Update()
    {
        // Check for player input (e.g., mouse click)
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from camera to detect objects within interaction range
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionRange, crystalLayer))
            {
                // Check if the object hit is a crystal
                CrystalItem crystalItem = hit.collider.GetComponent<CrystalItem>();

                if (crystalItem != null)
                {
                    // Perform interaction logic (e.g., add crystal to inventory)
                    InteractWithCrystal(crystalItem);

                    // Optionally, play a sound effect or visual effect indicating interaction
                    Destroy(hit.collider.gameObject); // Destroy the crystal object after interaction
                }
            }
        }
    }

    // Method to interact with the crystal (e.g., add to inventory)
    void InteractWithCrystal(CrystalItem crystal)
    {
        InventoryManager.instance.AddCrystal(crystal); // Add crystal to inventory
        Debug.Log("Picked up crystal: " + crystal.itemName); // Log the crystal's itemName or perform other actions
    }
}
