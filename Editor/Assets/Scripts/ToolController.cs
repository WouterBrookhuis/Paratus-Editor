using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolController : Singleton<ToolController>
{
    private List<BaseTool> m_tools = new List<BaseTool>();
    private BaseTool m_activeTool;
    private BaseTool m_defaultTool;

    public BaseTool ActiveTool
    {
        get
        {
            return m_activeTool;
        }
        set
        {
            if(m_activeTool != null)
            {
                Debug.Log("Switching from tool " + m_activeTool.name);
                m_activeTool.enabled = false;
            }
            m_activeTool = value;
            m_activeTool.enabled = true;
            Debug.Log("Switching to tool " + m_activeTool.name);
            if(!m_tools.Contains(m_activeTool))
            {
                m_tools.Add(m_activeTool);
            }
        }
    }

    void Awake()
    {
        var tools = GetComponentsInChildren<BaseTool>();
        foreach(var tool in tools)
        {
            tool.enabled = false;
            m_tools.Add(tool);
        }
        ActiveTool = m_tools[0];
        m_defaultTool = m_tools[0];
    }

    public void ChangeEditorMode(ToolManager.EditorMode mode)
    {
        if(ActiveTool != null)
        {
            if(!ActiveTool.IsModeValid(mode))
            {
                ActiveTool = m_defaultTool;
            }
        }
    }

    void LateUpdate()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if(m_activeTool != null)
            {
                m_activeTool.OnLateUpdate();
            }
        }
    }
}
