using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private PlayerRevert _player;
    void Start()
    {
        _player = FindObjectOfType<PlayerRevert>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _player.RevertPlayer(true);
    }
}
