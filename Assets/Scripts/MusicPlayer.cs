using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;

        if (numOfMusicPlayers > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }
}
