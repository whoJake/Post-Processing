using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CustomPostProcessing : MonoBehaviour
{
    Camera _Camera;
    public PostProcessingStack effectStack;

    List<RenderTexture> temporaryTextures;

    void Start() {
        _Camera = GetComponent<Camera>();
        temporaryTextures = new List<RenderTexture>();
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        //No Post Processing effects to render
        if (effectStack.Size <= 0) return;

        RenderTexture current = source;

        for(int index = 0; index < effectStack.Size; index++) {
            RenderTexture transfer = CreateTemporaryTexture(source.width, source.height);
            PostProcessingEffect effect = effectStack.GetIndex(index);

            //Is not final effect
            if(index < effectStack.Size - 1) {
                effect.Render(current, transfer);
                current = transfer;
            }
            //Is final effect
            else {
                effect.Render(current, destination);
                ReleaseTemporaryTextures();
            }
        }
    }

    void ReleaseTemporaryTextures() {
        foreach(RenderTexture r in temporaryTextures) {
            RenderTexture.ReleaseTemporary(r);
        }
    }

    RenderTexture CreateTemporaryTexture(int width, int height) {
        RenderTexture temp = RenderTexture.GetTemporary(width, height);
        temporaryTextures.Add(temp);
        return temp;
    }
}
