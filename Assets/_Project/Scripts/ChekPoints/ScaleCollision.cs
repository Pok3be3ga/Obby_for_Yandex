using UnityEngine;

public class ScaleCollision: MonoBehaviour
{
    [SerializeField] private Vector3 _n;
    private Vector3 _startScale;
    private void Start()
    {
        _startScale = transform.localScale;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(transform.localScale.x > 0.1f && transform.localScale.y > 0.1f && transform.localScale.z > 0.1f)
            gameObject.transform.localScale -= _n*Time.deltaTime;
    }
    public void SetStartScale()
    {
        transform.localScale = _startScale;
    }
}