using MoreMountains.Feedbacks;
using System.Reflection;
using UnityEditor.Rendering;
using UnityEngine;

public class Maskable : MonoBehaviour
{
    [SerializeField] MMF_Player maskFeedback;

    public GameObject currentMaskedObject;


    public void OnMask()
    {
        if(currentMaskedObject == null)
        {
            currentMaskedObject = new GameObject("MaskedObject");

            MeshFilter original = gameObject.GetComponent<MeshFilter>();
            MeshRenderer copy = currentMaskedObject.AddComponent<MeshRenderer>();

            MeshFilter mf = currentMaskedObject.GetComponent<MeshFilter>();
            MeshRenderer mr = currentMaskedObject.GetComponent<MeshRenderer>();

            currentMaskedObject.get



        }
    }

    private void Update()
    {
        if (currentMaskedObject == null) return;


    }

}
