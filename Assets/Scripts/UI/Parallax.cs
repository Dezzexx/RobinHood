using Mono.Cecil.Cil;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] Vector2 parallaxEffectMultiplier;

    Vector3 previousPosition;
    private float textureUnitSizeX;
    
    void Start()
    {
        followTarget = Camera.main.transform;
        previousPosition = followTarget.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;

        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        var delta = followTarget.position - previousPosition;

        transform.position += new Vector3(delta.x * parallaxEffectMultiplier.x, delta.y * parallaxEffectMultiplier.y);
        previousPosition = followTarget.position;

        RepeatableParallax(textureUnitSizeX, 0, 1);
    }

    //int coordinate 1,2: x - 0, y - 1
    void RepeatableParallax(float textureUnitSize, int coordinate1, int coordinate2)
    {
        if (Mathf.Abs(followTarget.position[coordinate1] - transform.position[coordinate1]) >= textureUnitSize)
        {
            float offsetPosition = (followTarget.position[coordinate1] - transform.position[coordinate1]) % textureUnitSize;
            transform.position = new Vector3(followTarget.position[coordinate1] + offsetPosition, transform.position[coordinate2]);
        }
    }
}
