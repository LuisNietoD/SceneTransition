using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour //attach to eaech door
{
    public string sceneToLoad;
    public string previousScene;
    
    //Wyyne code: MMF player reference
    public MMF_Player mmfPlayer;

    private float delayTime = 1f;

    public virtual void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag.Equals("Player"))
        {
            Invoke("SceneChangeDelay", delayTime);
            
        }
      //pop up window asking player if he wants to go in--> if enter then invoke scene change

    }
    public void SceneChangeDelay()
    {
        //SceneCtrl.Instance.ChangeScene(sceneToLoad); //switch to new scene
        //Add a transition page in between the two scenes
        
        //Wyyne code: Load the scene with Feel feedback
        mmfPlayer.PlayFeedbacks();
        
        GameCtrl.Instance.EnterDoor(previousScene, sceneToLoad); //make sure player is transported to right location in new scene
    }


}
