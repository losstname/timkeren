using UnityEngine;
using System.Collections;

public class CharacterList : MonoBehaviour
{

    public GameObject[] HeroesPrefab;   //game object for instatiating
    public GameObject[] EnemiesPrefab;

    public Sprite[] HeroesSprite;       //full body image for preview
    public Sprite[] EnemiesSprite;

    public Sprite[] HeroesThumbnail;    //face thumbnail for listing
    public Sprite[] EnemiesThumbnail;
}