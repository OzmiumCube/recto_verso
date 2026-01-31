using MoreMountains.Feedbacks;
using System.Collections;
using System.Reflection;
using UnityEditor.Rendering;
using UnityEngine;

public class Maskable : MonoBehaviour
{
    [SerializeField] MMF_Player maskFeedback;

    [SerializeField] Material shadowMaterial;

    public GameObject currentMaskedObject;

    private IEnumerator MaskRoutine(Transform newParent)
    {
        yield return StartCoroutine(maskFeedback.PlayFeedbacksCoroutine(transform.position, 1f, false));

        if (currentMaskedObject == null)
        {
            currentMaskedObject = new GameObject("MaskedObject");

            MeshFilter originalMeshFilter = gameObject.GetComponent<MeshFilter>();
            MeshFilter copyMeshFilter = currentMaskedObject.AddComponent<MeshFilter>();
            copyMeshFilter.mesh = originalMeshFilter.mesh;

            MeshRenderer originalMeshRenderer = gameObject.GetComponent<MeshRenderer>();
            MeshRenderer copyMeshRenderer = currentMaskedObject.AddComponent<MeshRenderer>();
            copyMeshRenderer.materials = originalMeshRenderer.materials;

            currentMaskedObject.GetComponent<Renderer>().material = shadowMaterial;

            currentMaskedObject.transform.parent = gameObject.transform.parent;

        }
        currentMaskedObject.transform.SetParent(gameObject.transform.parent, false);
        gameObject.transform.SetParent(newParent, false);
    }

    public void OnMask(Transform newParent)
    {
        StartCoroutine(MaskRoutine(newParent));
    }

    private void Update()
    {
        if (currentMaskedObject == null) return;

        currentMaskedObject.transform.localPosition = gameObject.transform.localPosition;
        currentMaskedObject.transform.localRotation = gameObject.transform.localRotation;
        currentMaskedObject.transform.localScale = gameObject.transform.localScale;
    }

}
