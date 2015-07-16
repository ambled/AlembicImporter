using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;
using UnityEngine;

[ExecuteInEditMode]
public class AlembicMesh : MonoBehaviour
{
    [Serializable]
    public class Split
    {
        public Vector3[] positionCache;
        public Vector3[] normalCache;
        public Vector2[] uvCache;
        public Mesh mesh;
        public GameObject host;
    }

    [Serializable]
    public class Submesh
    {
        public int[] indexCache;
        public int facesetIndex;
        public int splitIndex;
    }

    public bool m_reverseFaces = false;
    public bool m_forceSmoothNormals = false;
    public bool hasFacesets = false;

    public List<Submesh> m_submeshes = new List<Submesh>();
    public List<Split> m_splits = new List<Split>();
    
    public RenderTexture m_indices;
    public RenderTexture m_vertices;
    public RenderTexture m_normals;
    public RenderTexture m_uvs;

    static RenderTexture CreateDataTexture(int numData, RenderTextureFormat format)
    {
        const int width = 1024;
        var r = new RenderTexture(width, numData / width, 0, format);
        r.enableRandomWrite = true;
        r.Create();
        return r;
    }

    void Update()
    {
    }
}
