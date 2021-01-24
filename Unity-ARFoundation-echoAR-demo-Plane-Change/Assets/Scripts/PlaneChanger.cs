/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneChanger : MonoBehaviour
{
    private ARPlaneManager aRPlaneManager;
    private int index = 0;
    private List<Material> materials;
    private GameObject m_echoAR;

    // Start is called before the first frame update
    void Start()
    {
        m_echoAR = GameObject.Find("echoAR");
        GameObject session = GameObject.Find("AR Session Origin");
        aRPlaneManager = session.GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangePlane()
    {
        // Get Mesh Renderers of echoAR's children GameObjects
        MeshRenderer[] meshRenderers = m_echoAR.GetComponentsInChildren<MeshRenderer>();

        // Get materials from mesh renderers
        materials = new List<Material>();
        foreach (MeshRenderer mr in meshRenderers)
        {
            materials.Add(mr.material);
        }

        if (++index >= materials.Count) index = 0;

        // Change material on current plane
        aRPlaneManager.planePrefab.GetComponent<MeshRenderer>().sharedMaterial = materials[index];

        // Change material on planes generated earlier
        meshRenderers = transform.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mr in meshRenderers)
        {
            mr.material = materials[index];
        }

    }
}
