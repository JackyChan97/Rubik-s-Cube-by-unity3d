using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texture : MonoBehaviour {
    public Material[] mat_1;
    int num = 0;
    int num_len = 0;
    // Use this for initialization
    void Start () {
        num_len = mat_1.Length;
    }
    
    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.T))
        {
            num++;
            num = num % num_len;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        string tag = y.ToString() + x.ToString() + z.ToString();
                        GameObject t1 = GameObject.FindGameObjectWithTag(tag);

                        Material[] newBufMat = new Material[t1.transform.GetComponent<Renderer>().materials.Length];
                        for (int i = 0; i < t1.transform.GetComponent<Renderer>().materials.Length; i++)
                        {
                            newBufMat[i] = mat_1[num];
                        }

                        t1.transform.GetComponent<Renderer>().materials = newBufMat;
                    }
                }
            }
        }
    }
}
