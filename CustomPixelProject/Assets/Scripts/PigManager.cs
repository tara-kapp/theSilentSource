using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PigManager : MonoBehaviour
{

    [Header("Pig Settings")]
    public GameObject pigPrefab;
    public Transform spawnPoint;
    public Transform conveyorEndPoint;
    public Transform offScreenPoint;
    public Transform parentTransform;
    public GameObject painOverlay;

    [Header("Man-Made Items")]
    public List<Sprite> manMadeItems;
    public GameObject itemSpawn;
    
    private Queue<GameObject> pigQueue = new Queue<GameObject>();
    private GameObject currentPig;



    // Start is called before the first frame update
    void Start()
    {
        //Randomize the list of items
        manMadeItems = manMadeItems.OrderBy(x => Random.value).ToList();

        //Initialize pigs
        foreach (Sprite item in manMadeItems)
        {
            Debug.Log("Shuffled Item: " + item.name);
            int index = manMadeItems.IndexOf(item);
            

            //Instantiate pig with at spawnpoint. pig clones go under pig parent
            GameObject pig = Instantiate(pigPrefab, spawnPoint.position, Quaternion.identity, parentTransform);

            //Assign item to pig prefab
            pigPrefab.GetComponent<PigBehavior>().AssignItem(item);
            
            pigQueue.Enqueue(pig);
        }         

        //Call function to bring out the pig from right side of screen
        MoveNextPig();        
    }

    private void SetDisplaySprite(Sprite item)
    {
        SpriteRenderer renderer = itemSpawn.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer = itemSpawn.AddComponent<SpriteRenderer>();
        }

        renderer.sprite = item;
    }


    public void MoveNextPig()
    {
        if(pigQueue.Count > 0)
        {
            currentPig = pigQueue.Dequeue();
            StartCoroutine(MovePigToPosition(currentPig, conveyorEndPoint.position));
        }
        else
        {
            Debug.Log("All pigs processed!");
        }
    }

    // Moves pig from center and out of screen
    public void RemoveCurrentPig()
    {
        if(currentPig != null)
        {            
            StartCoroutine(MovePigToPosition(currentPig, offScreenPoint.position, () =>
            { 
                //Destroys asset
            Destroy(currentPig);
                //Brings out new pig
            MoveNextPig();
            }));
        }
    }

    private IEnumerator MovePigToPosition(GameObject pig, Vector3 targetPosition, System.Action onComplete = null)
    {
        //Set speed pig moves on conveyor belt
        float speed = 8f;


        while(Vector3.Distance(pig.transform.position, targetPosition) > 0.1f)
        {
            pig.transform.position = Vector3.MoveTowards(pig.transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        onComplete?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}