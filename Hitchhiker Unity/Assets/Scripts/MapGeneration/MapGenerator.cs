using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour {
	public static MapGenerator instance = null;
    enum TileType {EastPopVillage, EastRuralFarm, EastRuralForest};

	[Header("Generation")]
	public int masterSeed = 0;
    public AnimationCurve perchCurve;

    [Header("Balancing")]
    public int mapLength;
    [Range(0.0f, 1.0f)]
    public float farmPercentage = 0.3f;
    public int puddlePerTile = 2;
    public float birdFrequency = 0.5f;

    private bool placementDone = false;

    //[Range(0,1)]
    //public float buildingPercent;

    [Space(10)]

    [Header("Tiles")]
    public GameObject[] tilePopVillage;
    public GameObject[] tileRuralFarm;
    public GameObject[] tileRuralForest;

    [Header("Objects")]
    public GameObject puddle;
    public GameObject powerline;
    public GameObject bird;

    [Header("Outside References")]
    public Slider nextTownSlider;

    private TileType[] tileMap;

    List<Coord> allTileCoords;
	Queue<Coord> shuffledTileCoords; //this is a Queue so it can be Shuffled when it is created

    List<GameObject> tileList = new List<GameObject>();
    private string tileParentName = "TileParent";
    private Transform tileParent;

    Coord villageCenter;

    private Transform cameraTransform;

    private int n = 0; //n = nextTileNum
    private float placeNextTileThresold = -275f;
    private float removeLastTileThresold = -250f;

    private float nextTownXPos;
    private float nextTownRelativeStartXPos;

    void Awake (){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start ()
	{
        cameraTransform = Camera.main.gameObject.transform;
        PlaceStartTiles();
        nextTownRelativeStartXPos = PlayerController_Master.playerBody.transform.position.x;
    }

	public void RandomizeSeed()
    {
		masterSeed += Random.Range (-10000, 10000);
	}

    void GenerateMap()
    {
        n = 0;
        Random.InitState(masterSeed);

        allTileCoords = new List<Coord>();
        for (int x = 0; x < mapLength; x++)
        {
            allTileCoords.Add(new Coord(x)); //fills the list of coords with each potential coord in the map
        }

        shuffledTileCoords = new Queue<Coord>(Utility.ShuffleArray(allTileCoords.ToArray(), masterSeed)); //shuffles all the Coords randomly

        //Fill tileMap with the base tile (forest)
        tileMap = new TileType[(int)mapLength];
        for (int x = 0; x < mapLength; x++)
        {
            tileMap[x] = TileType.EastRuralForest;
        }

        //Figure out how many farms we want. And randomly place them in tilemap
        int farmCount = (int)(mapLength * farmPercentage);
        for (int x = 0; x < farmCount; x++)
        {
            Coord randomCoord = GetRandomCoord();
            tileMap[randomCoord.x] = TileType.EastRuralFarm;
        }

        //Set first and last and middle tile as the populated village tiles
        tileMap[2] = TileType.EastPopVillage;
        tileMap[mapLength - 3] = TileType.EastPopVillage;
        int halfWay = (int)(mapLength / 2);
        tileMap[halfWay] = TileType.EastPopVillage;
        nextTownXPos = halfWay * -50f;

        //PUDDLES TEMP IMPLEMENTATION---------------------------------------------- should use list later and not spawn all at once
        //Setup Puddle Parent
        string holderName = "PuddleParent";
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
        Transform puddleParent = new GameObject(holderName).transform; //create parent so the whole village can be deleted later
        puddleParent.parent = transform;

        //Place Puddles
        int puddleCount = puddlePerTile * mapLength;
        float minPlacement = 0f;
        float maxPlacement = CoordToPosition(mapLength).x;
        for (int x = 0; x < puddleCount; x++)
        {
            Vector3 puddlePosition = new Vector3(Random.Range(minPlacement, maxPlacement), 0.07f, 0.31f);
            GameObject newPuddle = Instantiate(puddle, puddlePosition, Quaternion.identity) as GameObject;
            newPuddle.transform.parent = puddleParent;
        }
    }

    public void PlaceStartTiles()
    {
        //Setup Tile Parent
        if (transform.Find(tileParentName))
        {
            DestroyImmediate(transform.Find(tileParentName).gameObject);
        }
        tileParent = new GameObject(tileParentName).transform; //create parent so the whole village can be deleted later
        tileParent.parent = transform;

        if (tileList != null)
        {
            tileList.Clear();
        }

        GenerateMap();

        for (int i = 0; i < 11; i++)
        {
            PlaceNextTile();
        }
        
    }

    public void PlaceAllTiles()
    {
        //Setup Tile Parent
        if (transform.Find(tileParentName))
        {
            DestroyImmediate(transform.Find(tileParentName).gameObject);
        }
        tileParent = new GameObject(tileParentName).transform; //create parent so the whole village can be deleted later
        tileParent.parent = transform;

        GenerateMap();

        for (int i = 0; i < mapLength; i++)
        {
            PlaceNextTile();
        }
    }
    void PlaceNextTile()
    {
        if (n < mapLength)
        {
            Vector3 tilePosition = CoordToPosition(n);
            GameObject newTile = Instantiate(GetPrefabOfTileType(n), tilePosition, Quaternion.identity) as GameObject;
            newTile.transform.parent = tileParent;
            tileList.Add(newTile);

            //powerlines
            for (int i = 0; i < 4; i++)
            {
                GameObject newLine = Instantiate(powerline, new Vector3((tilePosition.x + 12.5f) - (i * 12.5f), 0, 4), Quaternion.identity) as GameObject;
                newLine.transform.parent = newTile.transform;

                if (Random.Range(0f, 1f) < birdFrequency)
                {
                    int birdCount = Random.Range(1, 4);

                    for (int b = 0; b < birdCount; b++)
                    {
                        float xRandom = Random.Range(0f, 12.5f);
                        GameObject newBird = Instantiate(bird, new Vector3(newLine.transform.position.x + xRandom, perchCurve.Evaluate(xRandom), 3.342f), Quaternion.identity) as GameObject;
                        newBird.transform.parent = tileParent;
                    }
                }
            }

            n++;
        }
        else
        {
            placementDone = true;
        }
    }

    private void Update()
    {
        
        if (cameraTransform.position.x < removeLastTileThresold)
        {
            Destroy(tileList[0]);
            tileList.Remove(tileList[0]);
            removeLastTileThresold -= 50f;
        }

        if (!placementDone)
        {
            if (cameraTransform.position.x < placeNextTileThresold)
            {
                PlaceNextTile();
                placeNextTileThresold -= 50f;
            }
        }
        float playerX = PlayerController_Master.playerBody.transform.position.x;

        if (playerX < nextTownXPos)
        {
            //You passed the town
            nextTownXPos = (mapLength - 3) * -50f;
            nextTownRelativeStartXPos = playerX;
            EventDisplayManager.instance.DisplayMessage("Yes! I'm halfway there.");
        }
        else
        {
            nextTownSlider.value = (playerX - nextTownRelativeStartXPos) / (nextTownXPos - nextTownRelativeStartXPos);
            //print("player: " + playerX + " nextTown: " + nextTownXPos + " nextTownStartXPos: " + nextTownRelativeStartXPos);
        }

    }

    GameObject GetPrefabOfTileType (int x)
    {
        switch (tileMap[x])
        {
            case TileType.EastPopVillage:
                return tilePopVillage[Random.Range(0, tilePopVillage.Length)];
            case TileType.EastRuralFarm:
                return tileRuralFarm[Random.Range(0, tileRuralFarm.Length)];
            case TileType.EastRuralForest:
                return tileRuralForest[Random.Range(0, tileRuralForest.Length)];
            default:
                return tileRuralForest[0];
        }
    }

	Vector3 CoordToPosition(int x) // Converts the Coord Class into a world position
	{
		return new Vector3 (x*-50, 0, 0);
	}


    public Coord GetRandomCoord() //Gets next item from queue and pushes it to the last item
	{
		Coord randomCoord = shuffledTileCoords.Dequeue ();
		shuffledTileCoords.Enqueue (randomCoord);
		return randomCoord;
	}

	public struct Coord // a struct is like a class except... well ummm... 
	{
		public int x;

		public Coord (int _x) 
		{
			x = _x;
		}
		//defines how we compare two coords
		public static bool operator == (Coord c1, Coord c2)
		{
			return c1.x == c2.x;
		}
		public static bool operator != (Coord c1, Coord c2)
		{
			return !(c1 == c2);
		}
	}
}
