using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PostProcessingEffect : ScriptableObject
{
    [SerializeField] protected Material material;

    public virtual Material GetMaterial() {
        return material;
    }

    public abstract void Render(RenderTexture source, RenderTexture destination);
}
