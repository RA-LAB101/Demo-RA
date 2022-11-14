using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;
using UnityEngine.XR.ARFoundation;
using UnityEngine;


public class checkSupport : MonoBehaviour
{
    [SerializeField] ARSession m_Session;

    IEnumerator Start() {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            Debug.Log("No sirve weon");
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
        }
    }
}
