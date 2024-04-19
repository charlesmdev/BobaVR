using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;
    private XRPokeInteractor _xrPokeInteractor;
    // Start is called before the first frame update
    void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PokeAttachPoint == null) { Debug.LogWarning("Poke Attach Point is null"); return; }
        if (_xrPokeInteractor == null) { Debug.LogWarning("XR Poke Interactor is null"); return; }

        _xrPokeInteractor.attachTransform = PokeAttachPoint;
    }
}
