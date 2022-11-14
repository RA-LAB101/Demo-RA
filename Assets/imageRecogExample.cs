using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class imageRecogExample : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedManager;
    // Start is called before the first frame update
    void Awake(){
        _arTrackedManager = FindObjectOfType<ARTrackedImageManager>();
    }
    public void onEnable(){
        _arTrackedManager.trackedImagesChanged += OnImageChange;
    }
    public void onDisable(){
        _arTrackedManager.trackedImagesChanged -= OnImageChange;
    }
    public void OnImageChange(ARTrackedImagesChangedEventArgs args){
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
