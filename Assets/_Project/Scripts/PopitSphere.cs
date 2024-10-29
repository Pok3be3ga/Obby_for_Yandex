using System.Collections;
using UnityEngine;

public class PopitSphere : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private PlayerRevert _player;
    public bool _active;
    private void Start()
    {
        _player = FindObjectOfType<PlayerRevert>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Off();
        if( _active)
        {
            StartCoroutine(On());
        }
    }
    private void Off()
    {
        _meshRenderer.enabled = false;
    }
    private IEnumerator On()
    {
        yield return new WaitForSeconds(0.1f);
        _meshRenderer.enabled = true;
        _player.UpPlayer();
    }
}
