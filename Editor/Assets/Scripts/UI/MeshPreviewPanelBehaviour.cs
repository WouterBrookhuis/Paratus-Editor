using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MeshPreviewPanelBehaviour : UIBehaviour
{
    private Button m_closeButton;

    public override void Show()
    {
        base.Show();
        MeshPreviewer.instance.m_active = true;
    }

    public override void Hide()
    {
        base.Hide();
        MeshPreviewer.instance.m_active = false;
    }

    protected override void Start()
    {
        m_closeButton = Find("Close").GetComponent<Button>();

        m_closeButton.onClick.AddListener(OnClose);

        gameObject.SetActive(false);
    }

    private void OnClose()
    {
        Hide();
    }
}
