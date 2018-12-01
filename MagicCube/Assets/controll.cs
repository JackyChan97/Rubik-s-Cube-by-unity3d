using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class controll : MonoBehaviour {
    private GameObject getFixedObject;
    private Transform getFixedObjectTransform;
    private string[] neighborcubesTag = new string[9];
    private string typeKey;
    private bool canRotate = false;
    private int count = 0;
    private bool rotating = false;
    public GameObject fatherCubes;
    public float speed = 2;
    bool _mouseDown = false;
    public GameObject directionLight;
    public GameObject spotLight;
    public GameObject pointLight1;
    public GameObject pointLight2;
    public GameObject pointLight3;
    int lightCount = 0;
    Transform init ;
    void Start () {
        getFixedObject = GameObject.FindGameObjectWithTag("000");
        getFixedObjectTransform = getFixedObject.transform;
        init = fatherCubes.transform;
        spotLight.SetActive(false);
        pointLight1.SetActive(false);
        pointLight2.SetActive(false);
        pointLight3.SetActive(false);
        directionLight.SetActive(true);
    }



    public static Vector3 RotateRound(Vector3 position, Vector3 center, Vector3 axis, float angle)
    {
        Vector3 point = Quaternion.AngleAxis(angle, axis) * (position - center);
        Vector3 resultVec3 = center + point;
        return resultVec3;
    }


    void getNeighborCubes(Transform tsf, string key)
    {
        int count = 0;
        for(int y = 0; y < 3; y++)
        {
            for(int x = 0; x < 3; x++)
            {
                for(int z = 0; z < 3; z++)
                {
                    string tag = y.ToString() + x.ToString() + z.ToString();
                    GameObject tmp = GameObject.FindGameObjectWithTag(tag);
                    if (key == "A" || key == "D")
                    {
                        if (Mathf.Abs(tmp.transform.position.y - tsf.position.y)<0.3 )
                        {
                            neighborcubesTag[count] = tmp.tag;
                            count++;
                            
                        }
                    }
                    if (key == "W" || key == "S")
                    {
                        if (Mathf.Abs(tmp.transform.position.x - tsf.position.x)<0.3 )
                        {
                            neighborcubesTag[count] = tmp.tag;
                            count++;
                        }
                    }
                    if (key == "Q" || key == "E")
                    {
                        if (Mathf.Abs(tmp.transform.position.z - tsf.position.z) < 0.3)
                        {
                            neighborcubesTag[count] = tmp.tag;
                            count++;
                        }
                    }
                }
            }
        }
    }

    void rotate(string key,float angle)
    {
        Vector3 orignal = new Vector3(0, 0, 0);
        Vector3 y = new Vector3(0, 1, 0);
        Vector3 x = new Vector3(1, 0, 0);
        Vector3 z = new Vector3(0, 0, 1);
        Vector3 _x = new Vector3(-1, 0, 0);
        Vector3 _y = new Vector3(0, -1, 0);
        Vector3 _z = new Vector3(0, 0, -1);
            
        for (int i = 0; i < 9; i++)
        {
            if(key =="A")
            {
                GameObject tmp = GameObject.FindGameObjectWithTag(neighborcubesTag[i]);
                tmp.transform.RotateAround(orignal, y, angle);
            }
            if(key=="W")
            {
                GameObject tmp = GameObject.FindGameObjectWithTag(neighborcubesTag[i]);
                tmp.transform.RotateAround(orignal, x, angle);
            }
            if(key == "Q" )
            {
                GameObject tmp = GameObject.FindGameObjectWithTag(neighborcubesTag[i]);
                tmp.transform.RotateAround(orignal, z, angle);
            }
            if (key == "D")
            {
                GameObject tmp = GameObject.FindGameObjectWithTag(neighborcubesTag[i]);
                tmp.transform.RotateAround(orignal, _y, angle);
            }
            if (key == "S")
            {
                GameObject tmp = GameObject.FindGameObjectWithTag(neighborcubesTag[i]);
                tmp.transform.RotateAround(orignal, _x, angle);
            }
            if (key == "E")
            {
                GameObject tmp = GameObject.FindGameObjectWithTag(neighborcubesTag[i]);
                tmp.transform.RotateAround(orignal, _z, angle);
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            directionLight.GetComponent<Light>().intensity++;
            spotLight.GetComponent<Light>().intensity++;
            pointLight1.GetComponent<Light>().intensity++;
            pointLight2.GetComponent<Light>().intensity++;
            pointLight3.GetComponent<Light>().intensity++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            directionLight.GetComponent<Light>().intensity--;
            spotLight.GetComponent<Light>().intensity--;
            pointLight1.GetComponent<Light>().intensity--;
            pointLight2.GetComponent<Light>().intensity--;
            pointLight3.GetComponent<Light>().intensity--;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lightCount++;
            lightCount %= 3;
            if (lightCount == 0)
            {
                spotLight.SetActive(false);
                pointLight1.SetActive(false);
                pointLight2.SetActive(false);
                pointLight3.SetActive(false);
                directionLight.SetActive(true);
            }
            else if (lightCount == 1)
            {
                spotLight.SetActive(false);
                pointLight1.SetActive(true);
                pointLight2.SetActive(true);
                pointLight3.SetActive(true);
                directionLight.SetActive(false);
            }
            else
            {
                spotLight.SetActive(true);
                pointLight1.SetActive(false);
                pointLight2.SetActive(false);
                pointLight3.SetActive(false);
                directionLight.SetActive(false);
            }

        }
        if (Input.GetMouseButtonDown(1))
            _mouseDown = true;
        else if (Input.GetMouseButtonUp(1)) {
            Quaternion q = fatherCubes.transform.rotation;
            //q.x = -1 * q.x;
            //q.y = -1 * q.y;
            //q.z = -1 * q.z;
            //q.w = -1 * q.w;
            fatherCubes.transform.localEulerAngles = new Vector3(0, 0, 0);
            //fatherCubes.transform.SetPositionAndRotation(init.transform.position,q);
            _mouseDown = false;
        }
            

        
        if (_mouseDown)
        {
            float fMouseX = Input.GetAxis("Mouse X");
            float fMouseY = Input.GetAxis("Mouse Y");
            fatherCubes.transform.Rotate(Vector3.up, -fMouseX * speed, Space.World);
            fatherCubes.transform.Rotate(Vector3.right, fMouseY * speed, Space.World);
        }
       
        if (!rotating && Input.GetMouseButton(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                getFixedObject = hit.collider.gameObject;
                getFixedObjectTransform = hit.collider.gameObject.transform;
                //Debug.Log("hit:" + hit.collider.gameObject.transform.position);
            }
            count = 0;
            //for(int i = 0; i < 9; i++)
            //{
            //    Debug.Log(neighborcubes[i].transform.position);
            //}
        }
        {
            if (!rotating &&Input.GetKeyDown(KeyCode.A))
            {
                rotating = true;
                typeKey = "A";
                canRotate = true;
               // Debug.Log("f");
            }
            if (!rotating && Input.GetKeyDown(KeyCode.S))
                
            {
                rotating = true;
                typeKey = "S";
                canRotate = true;
                //Debug.Log("f");
            }
            if (!rotating && Input.GetKeyDown(KeyCode.D))
            {
                rotating = true;
                typeKey = "D";
                canRotate = true;
            }
            if (!rotating && Input.GetKeyDown(KeyCode.Q))
            {
                rotating = true;
                typeKey = "Q";
                canRotate = true;
            }
            if (!rotating && Input.GetKeyDown(KeyCode.W))
            {
                rotating = true;
                typeKey = "W";
                canRotate = true;
            }
            if (!rotating && Input.GetKeyDown(KeyCode.E))
            {
                rotating = true;
                typeKey = "E";
                canRotate = true;
            }
        }
        if (canRotate)
        {
            getNeighborCubes(getFixedObjectTransform, typeKey);
            rotate(typeKey, 3);
        }
        if (canRotate) count++;
        if (count >=30)
        {
            count = 0;
            canRotate = false;
            rotating = false;
        }

    }
}






