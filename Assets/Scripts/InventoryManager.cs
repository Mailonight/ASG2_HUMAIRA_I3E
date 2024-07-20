using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "New Crystal", menuName = "Custom/CrystalItem")]
public class CrystalItem
{
    public string itemName; // Name of the crystal item
    public Sprite itemIcon; // Icon representing the crystal item
    public string description; // Description of the crystal item

}
public class InventoryManager : MonoBehaviour
{
    public List<CrystalItem> inventory = new List<CrystalItem>(); // List to store collected crystals

    // Singleton pattern to ensure only one instance of InventoryManager exists
    public static InventoryManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Method to add a crystal to the inventory
    public void AddCrystal(CrystalItem crystal)
    {
        inventory.Add(crystal);
        // Optionally, you can call UpdateInventoryUI() here if needed
    }

    // Example method to use a crystal (not required for the error but shown for reference)
    public void UseCrystal(CrystalItem crystal)
    {
        if (inventory.Contains(crystal))
        {
            // Perform actions for using the crystal
            inventory.Remove(crystal); // Remove crystal from inventory after use
            // Optionally, you can call UpdateInventoryUI() here if needed
        }
        else
        {
            Debug.LogError("Crystal not found in inventory.");
        }
    }
    

    
}
