using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_Speed = 0.3f;
    private MeshRenderer mesh_renderer;
    private string MainTex = "_MainTex";

    void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scroll();
    }

    void scroll()
    {
        Vector2 offset = mesh_renderer.sharedMaterial.GetTextureOffset(MainTex);
        offset.y += Time.deltaTime *scroll_Speed;
        mesh_renderer.sharedMaterial.SetTextureOffset(MainTex,offset);
    }
}
