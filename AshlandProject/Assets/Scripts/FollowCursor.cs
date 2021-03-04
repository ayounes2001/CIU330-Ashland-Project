using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    public float distanceFromCamera;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = Input.mousePosition;
        tempPos.z = distanceFromCamera;
        this.transform.position = Camera.main.ScreenToWorldPoint(tempPos);
       //Vector3.Lerp(this.transform.position, Camera.main.ScreenToWorldPoint(tempPos),Time.deltaTime*3);
    }
}
