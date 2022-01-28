using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer))]
public class GradientUI : Graphic
{   
    [SerializeField] private GradientType type;
    private enum GradientType
    {
        LeftToRight,
        RightToLeft,
        Upward,
        Topdown
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        var pivot = rectTransform.pivot;
        var rect = rectTransform.rect;

        var corner1 = new Vector3(-pivot.x * rect.width, -pivot.y * rect.height);
        var corner2 = new Vector3((1 - pivot.x) * rect.width, (1 - pivot.y) * rect.height);
        
        vh.Clear();
        var vert = UIVertex.simpleVert;
        
        AddVertex(ref  vert, ref vh, corner1.x,corner1.y,type == GradientType.RightToLeft || type == GradientType.Topdown);
        AddVertex(ref  vert, ref vh, corner1.x,corner2.y,type == GradientType.RightToLeft || type == GradientType.Upward);
        AddVertex(ref  vert, ref vh, corner2.x,corner2.y,type == GradientType.LeftToRight || type == GradientType.Upward);
        AddVertex(ref  vert, ref vh, corner2.x,corner1.y,type == GradientType.LeftToRight || type == GradientType.Topdown);
        
        vh.AddTriangle(0,1,2);
        vh.AddTriangle(2,3,0);
    }

    private void AddVertex(ref UIVertex vert, ref VertexHelper vh, float x, float y, bool alpha)
    {
        vert.position = new Vector3(x, y, 0f);
        vert.color = color;
        if (alpha)
        {
            vert.color.a = 0;
        }
        vh.AddVert(vert);
    }
}