using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {
    public static GameCtrl Instance;

    [SerializeField] public Texture2D crosshair;
    [SerializeField] public Texture2D crosshairOnClick;
    [HideInInspector] public Vector2 cursorOffset= new Vector2(0.08026244f, 0.9550421f);

    private void Awake(){
        if (Instance == null){
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        
        
       //cursorOffset = new Vector2(0.08026244f, 0.9550421f);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.ForceSoftware);


    }

    private void Start(){
        SceneCtrl.Instance.ChangeScene(SceneNameDefine.Scene.MAIN_SCENE);
    }

    //manage scene transition

    private string _previousSceneName;
    public void EnterDoor(string previousScenename, string newSceneName)
    {
        _previousSceneName = previousScenename;
        StartCoroutine(WaitForSceneLoad(newSceneName));
    }

    IEnumerator WaitForSceneLoad(string scenename)
    {

        //yield return new WaitForSeconds(0.5f);
        Debug.Log($"{scenename}");
        Debug.Log($"{SceneManager.GetActiveScene().name}");
        while (SceneManager.GetActiveScene().name != scenename) //loop until it sees the scene name changes to the new scene name 
        {
            yield return null;
        }

        Debug.Log($"{SceneManager.GetActiveScene().name}");

        GameObject entrance = GameObject.Find($"from{_previousSceneName}"); //find the object in the scene with the name "fromSCENENAME" 
        Debug.Log($"entrance found {entrance.name}" );
        

        PlayerMovement.Player.MoveTo(entrance.transform.position);
        

    }
}
