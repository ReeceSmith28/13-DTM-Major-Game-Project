using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject[] dropppedItemPrefabs; // Array of item prefabs that can be dropped from this loot bag.

    // Start is called before the first frame update
    private void Start()
    {
        // This Start function is empty, with no specific initialization code.
    }

    // Get a random item from the droppedItemPrefabs array.
    public GameObject GetDroppedItem()
    {
        if (dropppedItemPrefabs.Length > 0)
        {
            int randomIndex = Random.Range(0, dropppedItemPrefabs.Length);
            GameObject selectedPrafab = dropppedItemPrefabs[randomIndex];
            return selectedPrafab;
        }
        else
        {
            Debug.Log("No Loot Dropped"); // Log a message if there are no items in the array.
            return null;
        }
    }

    // Instantiate a loot item at a specified position.
    public void InstantiateLoot(GameObject prefabToInstantiate, Vector2 spawnPosition)
    {
        Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
    }
}