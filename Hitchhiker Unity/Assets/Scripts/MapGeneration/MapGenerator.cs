using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {
	public static MapGenerator instance = null;
    enum TileType {EastPopVillage, EastRuralFarm, EastRuralForest};

	[Header("Generation")]
	public int masterSeed = 0;
	public int mapLength;
    [Range(0.0f, 1.0f)]
    public float farmPercentage = 0.3f;

    //[Range(0,1)]
    //public float buildingPercent;

    [Space(10)]

    [Header("Prefabs")]
    public GameObject[] tilePopVillage;
    public GameObject[] tileRuralFarm;
    public GameObject[] tileRuralForest;

    private TileType[] tileMap;

    List<Coord> allTileCoords;
	Queue<Coord> shuffledTileCoords; //this is a Queue so it can be Shuffled when it is created

	Coord villageCenter;

	void Awake (){
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	void Start ()
	{
		GenerateMap ();
	}

	public void RandomizeGenerate()
    {
		masterSeed += Random.Range (-10000, 10000);
		GenerateMap ();
	}

	public void GenerateMap() 
	{
        Random.InitState(masterSeed);

        allTileCoords = new List<Coord> ();
		for (int x = 0; x < mapLength; x++) 
		{
			allTileCoords.Add (new Coord (x)); //fills the list of coords with each potential coord in the map
		}
	
		shuffledTileCoords = new Queue<Coord> (Utility.ShuffleArray (allTileCoords.ToArray (), masterSeed)); //shuffles all the Coords randomly
        
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

        //
        string holderName = "Generated Map";
		if (transform.Find (holderName)) {
            DestroyImmediate(transform.Find(holderName).gameObject);
		}
		Transform villageHolder = new GameObject (holderName).transform; //create parent so the whole village can be deleted later
		villageHolder.parent = transform;

        //Set first and last tile as the populated village tiles
        tileMap[0] = TileType.EastPopVillage;
        tileMap[mapLength - 1] = TileType.EastPopVillage;

		for (int x = 0; x < mapLength; x++) 
		{
			Vector3 tilePosition = CoordToPosition (x);
			GameObject newTile = Instantiate (GetPrefabOfTileType(x), tilePosition, Quaternion.identity) as GameObject;
			newTile.transform.parent = villageHolder;
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
