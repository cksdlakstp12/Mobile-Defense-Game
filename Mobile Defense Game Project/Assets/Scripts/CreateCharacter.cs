using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateCharacter : MonoBehaviour
{
    public GameObject characterPrefab1;
    public GameObject characterPrefab2;

    private GameObject characterPrefab;

    private GameObject character;
    private AudioSource audioSource;
    private GameManager gameManager;

    private CharacterStat characterStat;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject(-1) == true) return;
        if (EventSystem.current.IsPointerOverGameObject(0) == true) return;
        if (gameManager.nowSelect == 1)
        {
            characterPrefab = characterPrefab1;
            characterStat = characterPrefab.GetComponent<CharacterStat>();
        }
        else if(gameManager.nowSelect == 2)
        {
            characterPrefab = characterPrefab2;
            characterStat = characterPrefab.GetComponent<CharacterStat>();
        }
        if(character == null)
        {
            CharacterStat characterStat = characterPrefab.GetComponent<CharacterStat>();
            if (characterStat.canCreate(gameManager.seed))
            {
                character = (GameObject)Instantiate(characterPrefab, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(audioSource.clip);
                gameManager.seed -= character.GetComponent<CharacterStat>().cost;
                gameManager.updateText();
            }
            
        }

    }
}
