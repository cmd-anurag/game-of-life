using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startPanel;
    public GameObject selectionPanel;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            SwitchPanel();
        }
    }

    void SwitchPanel() {
        startPanel.SetActive(false);
        selectionPanel.SetActive(true);
    }
    public void SwitchToHome() {
        startPanel.SetActive(true);
        selectionPanel.SetActive(false);
    }
}
