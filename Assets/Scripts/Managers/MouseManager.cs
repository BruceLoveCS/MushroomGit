using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;

    public Texture2D point, doorway, attack, target, arrow;

    RaycastHit hitInfo;

    public event Action<Vector3> OnMouseClicked;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
    }

    void Update()
    {
        SetCursorTexture();
        MouseControl();
    }

    void SetCursorTexture()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray,out hitInfo))
        {
            //«–ªª Û±ÍÃ˘ÕºToggle Mouse Mapping
            switch(hitInfo.collider.gameObject.tag)
            {
                case "Ground":
                    Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
                    break;
            }
        }
    }

    void MouseControl()
    {
        if(Input.GetMouseButtonDown(0) && hitInfo.collider!=null)
        {
            if (hitInfo.collider.gameObject.CompareTag("Ground"))
                OnMouseClicked?.Invoke(hitInfo.point);
        }
    }    
}
