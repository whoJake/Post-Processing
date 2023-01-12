using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Effect/Test")]
public class TestPPEffect : PostProcessingEffect
{
    public override void Render(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, material);
    }
}
