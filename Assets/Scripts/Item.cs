using UnityEngine;

[CreateAssetMenu(fileName = "Crystal", menuName = "Inventory/Crystal")]

public class Crystal : MonoBehaviour
{
    public CrystalItem crystalItem; // Reference to the CrystalItem Scriptable Object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager inventoryManager = other.GetComponent<InventoryManager>();
            if (inventoryManager != null)
            {
                inventoryManager.AddCrystal(crystalItem); // Add the crystal to player's inventory
                Destroy(gameObject); // Destroy the crystal object in the scene
            }
        }
    }
}