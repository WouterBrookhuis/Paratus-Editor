using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTool : BaseTool
{
    public Mesh m_demoMesh;
    public Material m_demoMaterial;

    public override void OnLateUpdate()
    {
        if(m_demoMesh != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 5000f))
            {
                Graphics.DrawMesh(m_demoMesh, Matrix4x4.TRS(hit.point, Quaternion.identity, Vector3.one), m_demoMaterial, gameObject.layer);
            }
        }
    }
}
