using UnityEngine;

public class PlayerSwapper : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    private GameObject currentPlayer;

    private bool hasSpawnedPlayer = false; // Flag to ensure player is spawned only once

    void Start()
    {
        // Assuming currentPlayer[0] is already in the scene, we just mark it as spawned
        hasSpawnedPlayer = true;
    }

    void Update()
    {
        // Example: Switch to next player prefab on pressing Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapPlayer();
        }
    }

    void SpawnPlayer(int index)
    {
        // Instantiate the player prefab
        currentPlayer = Instantiate(playerPrefabs[index], transform.position, Quaternion.identity);
    }

    void SwapPlayer()
    {
        // Get the index of the next player prefab
        int currentIndex = System.Array.IndexOf(playerPrefabs, currentPlayer);
        int nextIndex = (currentIndex + 1) % playerPrefabs.Length;

        // If we're trying to switch to the first prefab and it's already spawned, return
        if (nextIndex == 0 && hasSpawnedPlayer)
            return;

        // Destroy the current player
        Destroy(currentPlayer);

        // Instantiate the next player prefab
        SpawnPlayer(nextIndex);

        // Set the flag to true after spawning the first player prefab
        if (nextIndex == 0)
            hasSpawnedPlayer = true;
    }
}