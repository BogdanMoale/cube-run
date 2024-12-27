using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] moving_Platforms;
    public GameObject breakablePlatform;
    public GameObject coinPrefab;
    public GameObject [] enemyPrefabs;


    public float platform_Spawn_Timer = 1.8f;
    private float current_platform_Spawn_Timer;

    private int platform_Spawn_Count;

    public float min_x=-2f , max_x=2f;

    
    // Start is called before the first frame update
    void Start()
    {
        //get screen edges
        min_x = CameraEdges.PlayerLeftTop.x + 0.65f;
        max_x = CameraEdges.PlayerRightTop.x -0.65f;

        //Debug.Log("Platform bound left: " + min_x.ToString());
        //Debug.Log("Platform bound right: " + max_x.ToString());

        current_platform_Spawn_Timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }


    //spawn platforms and coins
    void SpawnPlatforms()
    {
       
        current_platform_Spawn_Timer += Time.deltaTime;

        if(current_platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            current_platform_Spawn_Timer = 0f;
            platform_Spawn_Count++;

            Vector3 platformPosition = transform.position;
            Vector3 coinPosition = transform.position;
            Vector3 enemyPosition = transform.position;

            platformPosition.x = Random.Range(min_x,max_x);

            coinPosition.x = platformPosition.x;
            coinPosition.y = coinPosition.y + 0.3f;

            enemyPosition.x = platformPosition.x;
            enemyPosition.y = enemyPosition.y + 0.4f;
            
            GameObject newPlatform = null;
            GameObject newCoin = null;
            GameObject newEnemy = null;
           

            if(platform_Spawn_Count < 2)
            {
                newPlatform=Instantiate(platformPrefab,platformPosition,Quaternion.identity);
                newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);

                transformParrent(newPlatform);
                transformParrent(newCoin);
                
            }
            //randomize platform
            else if(platform_Spawn_Count == 2)
            {
                if(Random.Range(0,2)>0)
                {
                    //regular platform
                    newPlatform=Instantiate(platformPrefab,platformPosition,Quaternion.identity);
                    newEnemy = Instantiate(enemyPrefabs[Random.Range(0,moving_Platforms.Length)],enemyPosition,Quaternion.identity);
                    transformParrent(newPlatform);
                    transformParrent(newEnemy);
                    //randomize coin
                    // int randomizeCoin = Random.Range(0,3);
                    // if(randomizeCoin == 0)
                    // {
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    // }
                    // if(randomizeCoin ==1)
                    // {
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     coinPosition.x = coinPosition.x +0.3f;
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    // }
                    // if(randomizeCoin == 2)
                    // {
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     coinPosition.x = coinPosition.x +0.3f;
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     coinPosition.x = coinPosition.x -0.6f;
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    // }
                    
                }
                else
                {
                    //moving platform
                    newPlatform=Instantiate(moving_Platforms[Random.Range(0,moving_Platforms.Length)],platformPosition,Quaternion.identity);
                    transformParrent(newPlatform);
                }
            }
            //randomize platform
            else if(platform_Spawn_Count == 3)
            {
                if(Random.Range(0,2)>0)
                {
                    //regular platform
                    newPlatform=Instantiate(platformPrefab,platformPosition,Quaternion.identity);
                    transformParrent(newPlatform);
                    //randomize coin
                    int randomizeCoin = Random.Range(0,3);
                    if(randomizeCoin == 0)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                    if(randomizeCoin ==1)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                        coinPosition.x = coinPosition.x +0.4f;
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                    if(randomizeCoin == 2)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                        coinPosition.x = coinPosition.x +0.4f;;
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                        coinPosition.x = coinPosition.x -0.8f;
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                }
                else
                {
                    //spike platform
                    newPlatform=Instantiate(spikePlatformPrefab,coinPosition,Quaternion.identity);
                    transformParrent(newPlatform);
                }
            }
            //randomize platform
            else if(platform_Spawn_Count == 4)
            {
                if(Random.Range(0,2)>0)
                {
                    //regular platform
                    newPlatform=Instantiate(platformPrefab,platformPosition,Quaternion.identity);
                    transformParrent(newPlatform);
                    //randomize coin
                    int randomizeCoin = Random.Range(0,3);
                    if(randomizeCoin == 0)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                    if(randomizeCoin ==1)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                        coinPosition.x = coinPosition.x +0.4f;
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                    if(randomizeCoin == 2)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                        coinPosition.x = coinPosition.x +0.4f;
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                        coinPosition.x = coinPosition.x -0.8f;
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                }
                else
                {
                    //breakable platform
                    newPlatform=Instantiate(breakablePlatform,platformPosition,Quaternion.identity);
                    transformParrent(newPlatform);
                    //randomize coin
                    int randomizeCoin = Random.Range(0,3);
                    if(randomizeCoin == 0)
                    {
                        newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                        transformParrent(newCoin);
                    }
                    // if(randomizeCoin ==1)
                    // {
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     transformParrent(newCoin);
                    //     coinPosition.x = coinPosition.x +0.4f;
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     transformParrent(newCoin);
                    // }
                    // if(randomizeCoin == 2)
                    // {
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     transformParrent(newCoin);
                    //     coinPosition.x = coinPosition.x +0.4f;
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     transformParrent(newCoin);
                    //     coinPosition.x = coinPosition.x -0.8f;
                    //     newCoin = Instantiate(coinPrefab,coinPosition,Quaternion.identity);
                    //     transformParrent(newCoin);
                    // }
                }

                platform_Spawn_Count = 0;
            }

            // if(newPlatform!=null)
            // {
            //     newPlatform.transform.parent = transform;
            // }

            // if(newCoin!=null)
            // {
            //     newCoin.transform.parent = transform;
            // }

            // if(newEnemy!=null)
            // {
            //     newEnemy.transform.parent = transform;
            // }
        }
        
    }

    //this function will add all the generated platform, coins, enemys, etc as childrens for the Platform Spawner object
    private void transformParrent(GameObject g)
    {
        if(g!=null)
        {
            g.transform.parent = transform;
        }
    }
}
