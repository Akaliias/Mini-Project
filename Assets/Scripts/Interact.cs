using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactRange = 2f; // Range within which the player can interact with items
    public UIManager uiManager; // Reference to the UIManager

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpItem();
        }
    }

    void TryPickUpItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            Item item = hit.transform.GetComponent<Item>();
            if (item != null)
            {
                uiManager.AddMoney(item.moneyValue);
                Debug.Log("Picked up item worth: " + item.moneyValue + " money.");
                Destroy(item.gameObject); // Remove the item from the scene
            }
        }
    }
}