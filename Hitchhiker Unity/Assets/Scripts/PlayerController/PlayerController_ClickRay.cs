using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_ClickRay : MonoBehaviour {

    public static RaycastHit hit;
    public static Ray ray;
    public static bool isMouseHover;

    private void Update() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isMouseHover = Physics.Raycast(ray, out hit);
    }
}
