using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    
    public GameObject blockPrefab;
    public float  BlockX, BlockY, BlockZ;
    public float DimX, DimY, DimZ;

    private void Start() {
        SpawnBlocks();
    }

    void SpawnBlocks(){
        int totalBlocksSpawned = 0;
        for (float x = 0 ; x < BlockX; x += DimX ) {
            for (float y = 0; y < BlockY; y += DimY) {
                for (float z = 0; z < BlockZ; z += DimZ) {

                    // Blocks[x, y] = new Block(new ChunkCoord(x, y, z), this, true);
                    Block tempBloc = new Block(new Vector3(x, y, z), this, blockPrefab);
                    tempBloc.BlockObject.transform.localScale = new Vector3(DimX, DimY, DimZ);
                    totalBlocksSpawned++;
                    // Instantiate(blockPrefab, parentSpawner, new Vector3(BlockX, BlockY, BlockZ));
                    // activeChunks.Add(new ChunkCoord(x, z));

                }

            }

        }

        print(" Total Blocks Spawned: " + totalBlocksSpawned);


    }

    // [ContextMenu("Fit BoxCollider to children")]
    // void FitBoxColliderToChildren()
    // {
    //     var bounds = new Bounds(Vector3.zero, Vector3.zero);

    //     bounds = EncapsulateBounds(transform, bounds);

    //     var collider = GetComponent<BoxCollider>();
    //     collider.center = bounds.center - transform.position;
    //     collider.size = bounds.size;
    // }
    // private Bounds EncapsulateBounds(Transform transform, Bounds bounds)
    // {
    //     var renderer = transform.GetComponent<Renderer>();
    //     if (renderer != null)
    //     {
    //         bounds.Encapsulate(renderer.bounds);
    //     }

    //     foreach (Transform child in transform)
    //     {
    //         bounds = EncapsulateBounds(child, bounds);
    //     }

    //     return bounds;
    // }




}
