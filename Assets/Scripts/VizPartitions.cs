using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Diagnostics;
using System.IO;
using UnityEngine.SocialPlatforms;
using System.Text.RegularExpressions;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Windows;

[ExecuteAlways]
[ExecuteInEditMode]
public class GenerateWalks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseObject;
    public GameObject walkParent;
    public Material baseMaterial;
    public GameObject parent;
    private float scale = 1;
    private Vector3 position = Vector3.zero;
    private Color stepColour = new Color(126 * 1.0f / 255, 126 * 1.0f / 255, 0 * 1.0f / 255, 1.0f);
    private int numSteps = 10;

    private Vector3[] stepset;

    // Variables needed to show the number of steps in each walk
    public GameObject titleParent;
    private GameObject numStepsTextParent;
    public GameObject numStepsTextCanvas;
    public TextMeshProUGUI numStepsText;

    // The variables needed for doing random generation:
    private System.Random random = new System.Random();

    // Keep track of current partition. Dimension of vector should be set to whatever the size of the largest vector is.
    private List<List<int>> currentPartition = new List<List<int>>();
    private int vectorDimension = 0;
    private int maxIntSize = 0;
    private int maxNumParts = 0;

    // Keep track of current set of objects
    private List<GameObject> currentPartitionObjects = new List<GameObject>();

    // Variables for importing partitions
    public TMP_InputField partitionSizeInputField;

    // Variable for displaying text for current displayed partition
    public TMP_Text currentPartitionText;

    // For displaying walk
    private Vector3[] currentWalk;
    private GameObject[] currentWalkObject = new GameObject[] { };

    // For Young Tableau
    private List<List<int>> youngTableau;

    void Start()
    {
        //scale = 50f / numSteps;
        baseObject.transform.localScale = new Vector3(scale, scale, scale);
        // Create stepset
        UnityEngine.Debug.Log("Scale: " + scale);

        // Adjust material alpha
        Renderer renderer = baseObject.GetComponent<Renderer>();
        renderer.sharedMaterial.SetColor("_Color", new Color(255 * 1.0f / 255, 126 * 1.0f / 255, 0 * 1.0f / 255, 1.0f));

        stepColour = new Color(255 * 1.0f / 255, 126 * 1.0f / 255, 0 * 1.0f / 255, 1.0f);

        // Create stepset
        /*
        stepset = new Vector3[3];
        stepset[0] = scale * new Vector3(1, 0, 0);
        stepset[1] = scale * new Vector3(0, 1, 0);
        stepset[2] = scale * new Vector3(0, 0, 1);
        */
        stepset = new Vector3[4];
        stepset[0] = scale * new Vector3(1, 0, 0);
        stepset[1] = scale * new Vector3(-1, 1, 0);
        stepset[2] = scale * new Vector3(0, -1, 1);
        stepset[3] = scale * new Vector3(0, 0, -1);

        UnityEngine.Debug.Log("THIS IS A TEST!");
    }

    public void generateAndDisplayWalk()
    {
        resetWalk();
        currentWalk = genStepSeriesOctantNaive(stepset, numSteps);
        displayWalk(currentWalk);

        getYoungTableau();
        displayYoungTableau();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDisable()
    {
        GetComponent<MeshFilter>().sharedMesh = null;
    }

    void OnApplicationQuit()
    {
        GetComponent<MeshFilter>().sharedMesh = null;
    }

    void getYoungTableau()
    {
        youngTableau = new List<List<int>> { new List<int>(), new List<int>(), new List<int>(), new List<int>() };
        // Start with currentWalk
        for (int i = 0; i < currentWalk.Length; i++)
        {
            int intToAdd = i + 1;
            if (currentWalk[i].x > 0)
            {
                youngTableau[0].Add(intToAdd);
            }
            else if (currentWalk[i].y > 0)
            {
                youngTableau[1].Add(intToAdd);
            }
            else if (currentWalk[i].z > 0)
            {
                youngTableau[2].Add(intToAdd);
            }
            else
            {
                youngTableau[3].Add(intToAdd);
            }
        }
        // Print it out to make sure I did it right.
        for (int i = 0; i < youngTableau.Count; i++)
        {
            UnityEngine.Debug.Log(String.Join(" ", youngTableau[i]));
        }
    }

    void displayYoungTableau()
    {
        // First, generate the string.
        // I need to know how big the numbers get. Assume that I won't have more than 4 digits.
        int paddedLength = 2;
        if (currentWalk.Length > 9)
        {
            paddedLength += 1;
        }
        if (currentWalk.Length > 99)
        {
            paddedLength += 1;
        }
        if (currentWalk.Length > 999)
        {
            paddedLength += 1;
        }
        if (currentWalk.Length > 9999)
        {
            paddedLength += 1;
        }
        // Now start creating the string.
        string youngTableauString = "";
        for (int i = 0; i < youngTableau.Count; i++)
        {
            // Add string for this row, one number at a time.
            for (int j = 0; j < youngTableau[i].Count; j++)
            {
                youngTableauString += youngTableau[i][j].ToString().PadRight(paddedLength);
            }

            // Add newline at the end
            youngTableauString += "\n";
        }
        UnityEngine.Debug.Log("youngTableauString: " + youngTableauString);

        currentPartitionText.text = youngTableauString;
    }

    public void generateColour()
    {
        for (int j = 0; j < currentWalkObject.Length; j++)
        {
            Color currentColor = Color.HSVToRGB(0.9f * j / currentWalkObject.Length, 1.0f, 1.0f);
            currentWalkObject[j].GetComponent<Renderer>().material.color = currentColor;
        }
    }

    Vector3[] genStepSeriesOctantNaive(Vector3[] stepSetInput, int numStepsInput)
    {
        Boolean walkFound = false;
        Vector3[] currentWalk = genStepSeriesNaive(stepSetInput, numStepsInput);
        while (!walkFound)
        {
            if (checkRestriction(currentWalk))
            {
                walkFound = true;
                // currentWalks.Add(currentWalk);
                return currentWalk;
            }
            currentWalk = genStepSeriesNaive(stepSetInput, numStepsInput);
        }
        return currentWalk;
    }

    static Boolean checkRestriction(Vector3[] stepSeriesInput)
    {
        var position = Vector3.zero;
        for (var i = 0; i < stepSeriesInput.Length; i++)
        {
            position = position + stepSeriesInput[i];
            //if (position.x < position.y || position.y < position.z)
            if (position.x < 0 || position.y < 0 || position.z < 0)
            {
                return false;
            }
        }
        return true;
    }

    static Vector3[] genStepSeriesNaive(Vector3[] stepSetInput, int numStepsInput)
    {
        Vector3[] toReturn = new Vector3[numStepsInput];
        for (var i = 0; i < numStepsInput; i++)
        {
            int randStep = UnityEngine.Random.Range(0, stepSetInput.Length);
            toReturn[i] = stepSetInput[randStep];
        }
        return toReturn;
    }

    public void setNumSteps(String numStepsInput)
    {
        //numSteps = Math.Max(0, int.Parse(numStepsInput));
        int newVal = 0;
        bool isValidInput = int.TryParse(numStepsInput, out newVal);
        newVal = Math.Max(0, newVal);
        
        if (isValidInput)
        {
            numSteps = newVal;
            UnityEngine.Debug.Log("numSteps: " + numSteps);
        }
    }

    public void resetWalk()
    {
        // Reset the list of walks
        //currentWalk = new Vector3[];
        //currentWalkObject = new GameObject[];
        for (int i = 0; i < currentWalkObject.Length; i++)
        {
            UnityEngine.Debug.Log("Destroying object #" + i);
            DestroyImmediate(currentWalkObject[i]);
        }

        // Get rid of previous walk step counts
        //Destroy(numStepsTextParent);
        //numStepsTextParent = new GameObject("numStepsTextParent");
        //numStepsTextParent.transform.parent = titleParent.transform;

        // Create a new empty game object at (0,0,0) to be the parent of the new walk cloud.
        //Destroy(walkParent);
        //walkParent = new GameObject("walkParent");
        //walkParent.transform.parent = parent.transform;
    }

    void displayWalk(Vector3[] stepSeriesInput)
    {
        // Create a prefab of the necessary color?
        // Must also be the right scale!
        Material material = Instantiate(baseMaterial);
        //material.color = colorInput;
        GameObject displayObject = Instantiate(baseObject);
        Renderer renderer = displayObject.GetComponent<Renderer>();
        //renderer.material = material;
        Color nextColor = Color.HSVToRGB(0.0f, 1.0f, 1.0f);
        position = Vector3.zero;
        float alphaValue = 1.0f;

        // Keep track of the cubes on an array:
        GameObject[] newWalkCubes = new GameObject[stepSeriesInput.Length];
        for (var i = 0; i < stepSeriesInput.Length; i++)
        {
            // Want colour to range from Red to Violet.

            //renderer.sharedMaterial.SetColor("_Color", new Color(255 * 1.0f / 255, 126 * 1.0f / 255, 0 * 1.0f / 255, alphaValue));
            //renderer.material.SetColor("_Color", new Color(nextColor.r, nextColor.g, nextColor.b, alphaValue));

            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            //GameObject newCube = Instantiate(displayObject, position, Quaternion.identity, walkParent.transform);
            newWalkCubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newWalkCubes[i].transform.position = position;
            newWalkCubes[i].transform.parent = walkParent.transform;
            newWalkCubes[i].transform.rotation = Quaternion.identity;

            newWalkCubes[i].GetComponent<Renderer>().sharedMaterial.SetColor("_Color", new Color(nextColor.r, nextColor.g, nextColor.b, alphaValue));
            //newWalkCubes[i] = newCube;

            position = position + stepSeriesInput[i];
            //nextColor = Color.HSVToRGB(0.9f * i / stepSeriesInput.Length, 1.0f, 1.0f);

            //UnityEngine.Debug.Log("Red value: " + nextColor.r);
            //UnityEngine.Debug.Log("Blue value: " + nextColor.b);
            //UnityEngine.Debug.Log("Green value: " + nextColor.g);

        }
        //currentWalkObjects.Add(newWalkCubes);
        currentWalkObject = newWalkCubes;

        UnityEngine.Debug.Log("Last position in walk: " + position);
        //GameObject newTitleCanvas = Instantiate(numStepsTextCanvas, position, Quaternion.identity, numStepsTextParent.transform);
        //newTitleCanvas.transform.localScale = new Vector3(scale / 30.0f, scale / 30.0f, scale / 30.0f);
        //TextMeshProUGUI newTitleText = newTitleCanvas.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        //UnityEngine.Debug.Log(newTitleText.name);
        //((TextMeshProUGUI)newTitleText).SetText("Length: " + stepSeriesInput.Length);

        //TextMeshProUGUI newTitleText = Instantiate(numStepsText, position, Quaternion.identity, newTitleCanvas.transform);
        //newTitleText.SetText("New Message");
        DestroyImmediate(displayObject);
    }

}