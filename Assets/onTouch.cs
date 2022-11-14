using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onTouch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bonsai;
    public Camera ARcamera;
    public TextMeshProUGUI pfsText;
    public TextMeshProUGUI bonsaisText;
    public TextMeshProUGUI deviceModel;
    private int totalBonsai;
    void Start()
    {
        totalBonsai = 0;
        Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("Click release "+ ARcamera.ScreenPointToRay(touch.position).origin);
                var newPosition = ARcamera.ScreenPointToRay(touch.position).origin;
                Debug.Log(ARcamera.transform.position.ToString());
                Instantiate(bonsai, newPosition, bonsai.transform.rotation);
                totalBonsai++;
            }
        }
    }
    private void OnGUI()
    {

        int fps = (int)(1.0f / Time.smoothDeltaTime);
        pfsText.text = "FPS: " + fps.ToString();
        bonsaisText.text = "Bonsais: " + totalBonsai.ToString();
        deviceModel.text = "Modelo: " + SystemInfo.deviceModel.ToString();
    }
}
