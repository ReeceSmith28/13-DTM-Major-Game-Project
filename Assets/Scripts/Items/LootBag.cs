 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject[] dropppedItemPrefabs;
    [SerializeField]


    private void Start()
    {

    }
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
            Debug.Log("No Loot Dropped");
            return null;
        }
        
    }

    public void InstantiateLoot(GameObject prefabToInstantiate, Vector2 spawnPosition)
    {
        Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
    }
}
