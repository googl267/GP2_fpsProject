using UnityEngine;
using System.Collections;

public class DrawSphere : MonoBehaviour
{
    public Color col = new Color(0.5f, 0.5f, 0.5f);
    
    public float alpha = 0.4f;
    public float size = 1;
    private void OnDrawGizmos() {
        // Draw a yellow sphere at the transform's position
        col.a = alpha;
        Gizmos.color = col;
        Gizmos.DrawSphere(transform.position, size);
    }
}