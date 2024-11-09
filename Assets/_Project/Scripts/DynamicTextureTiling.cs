using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DynamicTextureTiling : MonoBehaviour
{
    [SerializeField] private Vector2 baseTextureScale = new Vector2(1f, 1f); // Базовый масштаб текстуры
    [HideInInspector][SerializeField] private Renderer _renderer;

    private void OnValidate()
    {
        if (_renderer == null)
        {
            _renderer = GetComponent<Renderer>();
        }

        UpdateTextureTiling();
    }

    private void UpdateTextureTiling()
    {
        if (_renderer == null) return;

        // Получаем размеры объекта
        Vector3 objectScale = transform.lossyScale;

        // Пропорционально изменяем `textureScale` в зависимости от размеров объекта
        Vector2 textureScale = new Vector2(objectScale.x * baseTextureScale.x / 10, objectScale.z * baseTextureScale.y / 10);

        // Устанавливаем масштаб текстуры
        _renderer.material.mainTextureScale = textureScale;
    }
}
