using MoreMountains.Feedbacks;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Reflection;
using UnityEditor.Rendering;
using UnityEngine;

public class Maskable : MonoBehaviour
{
    [SerializeField] MMF_Player maskFeedback;

    [SerializeField] GameObject[] objectsToShadow;
    [SerializeField] Material shadowMaterial;

    public GameObject currentMaskedObject;

    private IEnumerator MaskRoutine(Transform newParent)
    {
        maskFeedback.PlayFeedbacks();
        yield return new WaitForSeconds(1f);

        if (currentMaskedObject == null)
        {
            currentMaskedObject = new GameObject("MaskedObject");
            for (int i = 0; i < objectsToShadow.Length; i++)
            {
                GameObject childObject = new GameObject("Child");

                MeshFilter originalMeshFilter = objectsToShadow[i].GetComponent<MeshFilter>();
                MeshFilter copyMeshFilter = childObject.AddComponent<MeshFilter>();
                copyMeshFilter.mesh = originalMeshFilter.mesh;

                MeshRenderer originalMeshRenderer = objectsToShadow[i].GetComponent<MeshRenderer>();
                MeshRenderer copyMeshRenderer = childObject.AddComponent<MeshRenderer>();
                copyMeshRenderer.materials = originalMeshRenderer.materials;

                childObject.GetComponent<Renderer>().material = shadowMaterial;

                childObject.transform.localScale = objectsToShadow[i].transform.localScale;
                childObject.transform.localPosition = objectsToShadow[i].transform.localPosition;
                childObject.transform.localRotation = objectsToShadow[i].transform.localRotation;

                childObject.transform.SetParent(currentMaskedObject.transform, false);
            }
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
