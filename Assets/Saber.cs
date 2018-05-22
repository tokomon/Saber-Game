using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour {
    
    public Texture3D texture;
    public Material matPisoE;

    public static Material matPiso;
    public static Material matPared;
    float j = 0;
    float i = 0;
    GameObject plane;

    // Use this for initialization
    void Start()
    {
        createGrid();//call the createGrid function on start
    }

    // Update is called once per frame
    void Update()
    {
        if (i<6 && j<5)
        {
            plane.transform.position = new Vector3(j, 0, i); //position the newly created quad accordingly
            plane.transform.eulerAngles = new Vector3(90f, 0, 0); //rotate the quads 90 degrees in X to face up
            i += 0.25f;
        }
        else
        {
            plane.GetComponent<Renderer>().material = matPisoE;
            i = 0;
            j += 0.25f; 
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }
    
  
    void createGrid()
    {
        /*
        for (float i = 0; i < NumberOfColumns; i += 1.05f)
        {//loop 1 to loop through columns
            for (float j = 0; j < NumberOfRows; j += 1.05f)
            {//loop 2 to loop through rows*/
         plane = GameObject.CreatePrimitive(PrimitiveType.Cube); //create a quad primitive as provided by unity
        plane.AddComponent<Hide>();
        /*  for (int i = 0; i < 5; i++)
          {
              plane.transform.position = new Vector3(i, 0, j); //position the newly created quad accordingly
              plane.transform.eulerAngles = new Vector3(90f, 0, 0); //rotate the quads 90 degrees in X to face up
          }
          */   

    }
    

}






