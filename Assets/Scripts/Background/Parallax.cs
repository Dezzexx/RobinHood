using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector2 _parallaxEffectMultiplier;

    private Vector3 _previousPosition;
    private float _textureUnitSize;

    private void Start()
    {
        _followTarget = Camera.main.transform;
        _previousPosition = _followTarget.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        _textureUnitSize = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        ParallaxEffect();
        RepeatableParallax(_textureUnitSize, 0, 1);
    }

    private void ParallaxEffect()
    {
        var delta = _followTarget.position - _previousPosition;

        transform.position += new Vector3(delta.x * _parallaxEffectMultiplier.x, delta.y * _parallaxEffectMultiplier.y);
        _previousPosition = _followTarget.position;
    }
    //int coordinate 1,2: x - 0, y - 1
    private void RepeatableParallax(float textureUnitSize, int coordinate1, int coordinate2)
    {
        if (Mathf.Abs(_followTarget.position[coordinate1] - transform.position[coordinate1]) >= textureUnitSize)
        {
            float offsetPosition = (_followTarget.position[coordinate1] - transform.position[coordinate1]) % textureUnitSize;
            transform.position = new Vector3(_followTarget.position[coordinate1] + offsetPosition, transform.position[coordinate2]);
        }
    }
}
