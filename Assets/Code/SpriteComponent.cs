using UnityEngine;
using System.Collections;

public class SpriteComponent : MonoBehaviour
{
    public float Size;

    public void UpdateSize()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        float width = meshRenderer.material.mainTexture.width * Size;
        float height = meshRenderer.material.mainTexture.height * Size;
        transform.localScale = new Vector3( width, height, 1 );
    }
}
