using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class PostProcessingEffect : ScriptableObject
{
    protected Material material;

    public virtual Material GetMaterial() {
        return material;
    }

    public abstract void Render(RenderTexture source, RenderTexture destination);
}
