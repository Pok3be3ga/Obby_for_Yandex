using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private PlayerRevert _player;
    void Start()
    {
        _player = FindObjectOfType<PlayerRevert>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        _player.SetTransform(gameObject.transform.position);
    }
}
