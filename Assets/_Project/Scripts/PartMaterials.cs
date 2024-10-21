using UnityEngine;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
public class PartMaterials : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Material _dontEditMaterial;
    [SerializeField] private List<MeshRenderer> _renderers = new List<MeshRenderer>();
    void OnEnable()
    {
#if UNITY_EDITOR
        _renderers.Clear();
        foreach (Transform child in transform)
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                _renderers.Add(child.GetComponent<MeshRenderer>());
            }
        }
        for (int i = 0; i < _renderers.Count; i++)
        {
            if (_renderers[i].sharedMaterial == _dontEditMaterial)
            {
                _renderers[i].sharedMaterial = _dontEditMaterial;
            }
            else
            {
                _renderers[i].sharedMaterial = _material;
            }
        }
#endif
    }
}
