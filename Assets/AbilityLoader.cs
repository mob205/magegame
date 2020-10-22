using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AbilityLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnSceneChange(Scene current, Scene next)
    {
        PlayerAbilities player = PlayerAbilities.instance;
        if (PlayerAbilities.instance)
        {
            foreach(Ability ability in AbilitySelector.selectedAbilities)
            {
                Instantiate(ability.gameObject, player.gameObject.transform);
            }
        }
    }
}
