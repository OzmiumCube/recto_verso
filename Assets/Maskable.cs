using MoreMountains.Feedbacks;
using System.Reflection;
using UnityEditor.Rendering;
using UnityEngine;

public class Maskable : MonoBehaviour
{
    [SerializeField] MMF_Player maskFeedback;

    public GameObject currentMaskedObject;

    public void OnMask(Transform newParent)
    {
        if(currentMaskedObject == null)
        {
            currentMaskedObject = new GameObject("MaskedObject");

            MeshFilter originalMeshFilter = gameObject.GetComponent<MeshFilter>();
            MeshFilter copyMeshFilter = currentMaskedObject.AddComponent<MeshFilter>();
            copyMeshFilter.mesh = originalMeshFilter.mesh;

            MeshRenderer originalMeshRenderer = gameObject.GetComponent<MeshRenderer>();
            MeshRenderer copyMeshRenderer = currentMaskedObject.AddComponent<MeshRenderer>();
            copyMeshRenderer.materials = originalMeshRenderer.materials;

            currentMaskedObject.transform.parent = gameObject.transform.parent;

        }
        currentMaskedObject.transform.SetParent(gameObject.transform.parent, false);
        gameObject.transform.SetParent(newParent, false);
    }

    private void Update()
    {
        if (currentMaskedObject == null) return;

        currentMaskedObject.transform.localPosition = gameObject.transform.localPosition;
        currentMaskedObject.transform.localRotation = gameObject.transform.localRotation;
    }

}
