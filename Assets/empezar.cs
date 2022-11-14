using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class empezar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ARSession m_Session;
    private bool deviceUnSupported = false;
    public GameObject deviceSupp;
    IEnumerator Start()
    {
        if ((ARSession.state == ARSessionState.None) ||
            (ARSession.state == ARSessionState.CheckingAvailability))
        {
            yield return ARSession.CheckAvailability();
        }

        if (ARSession.state == ARSessionState.Unsupported)
        {
            deviceUnSupported = true;
        }
        else
        {
            // Start the AR session
            m_Session.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startRA()
    {
        if (!deviceUnSupported)
        {
            SceneManager.LoadScene("RAScene");
        }
        else
        {
            deviceSupp.SetActive(true);
            deviceSupp.GetComponent<TextMeshProUGUI>().text = "Dispositivo "+ SystemInfo.deviceModel.ToString() + " no compatible";
        }
        
    }

}
