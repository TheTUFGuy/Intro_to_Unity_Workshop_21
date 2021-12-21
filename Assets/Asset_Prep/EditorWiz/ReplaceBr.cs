using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReplaceBr : ScriptableWizard
{
    // Start is called before the first frame update
    public bool copyValues = true;
    public GameObject useGameObject;
    public GameObject Replace;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceBr), "Replace");
    }

    void OnWizardCreate()
    {
        Transform[] Replaces;
        Replaces = Replace.GetComponentsInChildren<Transform>();

        foreach (Transform t in Replaces)
        {
            GameObject newObject;
            newObject = (GameObject)PrefabUtility.InstantiatePrefab(useGameObject);
            newObject.transform.position = t.position;
            newObject.transform.rotation = t.rotation;
            newObject.transform.parent = Replace.transform;
            Destroy(t.gameObject);

        }

    }
}
