using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayManager : MonoBehaviour
{
    [SerializeField, Header("レイの長さ")] private float rayDistance = 30f;
    [SerializeField, Header("照準")] private Image aim;

    [SerializeField, Header("--targetオブジェクト--")]
    private GameObject targetObj;
    private Renderer renderer;
    private TargetUIManager uiManager;

    void Start()
    {
        renderer = targetObj.GetComponent<Renderer>();
        renderer.material.color = Color.blue;
        uiManager = targetObj.GetComponent<TargetUIManager>();
    }

    void Update()
    {
        //マウスを画面中心に固定
        Cursor.lockState = CursorLockMode.Locked;
        //マウス座標の取得
        Vector3 pos = Input.mousePosition;
        pos.z = 90f;
        Vector3 rayDirection = Camera.main.ScreenToWorldPoint(pos);

        Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(Vector3.zero);

        //レイ構文
        RaycastHit hit;
        if(Physics.Raycast(rayOrigin, rayDirection, out hit, rayDistance))
        {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Target"))
            {
                renderer.material.color = Color.red;
                uiManager.IsWatching = true;
            }

            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                renderer.material.color = Color.blue;
                uiManager.IsWatching = false;
            }
        }

        Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.green, 5, false);        
    }
}
