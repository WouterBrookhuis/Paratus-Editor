using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTool : MonoBehaviour
{
    public ToolManager.EditorMode m_modes;
    void Start()
    {
        
    }


    public virtual void OnLateUpdate()
    {

    }

    public bool IsModeValid(ToolManager.EditorMode mode)
    {
        return (mode & m_modes) > 0;
    }
}
