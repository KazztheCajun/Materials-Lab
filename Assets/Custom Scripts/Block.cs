using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block {


    public GameObject BlockObject;
    public Vector3 coord;
    public BlockSpawner parentSpawner;

    public Block (Vector3 _coord, BlockSpawner _world, GameObject prefab) {

        coord = _coord;
        parentSpawner = _world;
        // isActive = true;

        // if (generateOnLoad)
        Init(prefab);

    }

    public void Init (GameObject prefab) {

        // spawn physical object at right location
        BlockObject = GameObject.Instantiate(prefab, coord, Quaternion.identity, parentSpawner.transform);





        // chunkObject = new GameObject();

        // meshFilter = chunkObject.AddComponent<MeshFilter>();
        // meshRenderer = chunkObject.AddComponent<MeshRenderer>();

        // meshRenderer.material = world.material;
        // chunkObject.transform.SetParent(world.transform);
        // chunkObject.transform.position = new Vector3(coord.x * VoxelData.ChunkWidth, 0f, coord.z * VoxelData.ChunkWidth);
        // chunkObject.name = "Chunk " + coord.x + ", " + coord.z;


        // PopulateVoxelMap();
        // UpdateChunk();

    }

// 	void PopulateVoxelMap () {
		
// 		for (int y = 0; y < VoxelData.ChunkHeight; y++) {
// 			for (int x = 0; x < VoxelData.ChunkWidth; x++) {
// 				for (int z = 0; z < VoxelData.ChunkWidth; z++) {

//                     voxelMap[x, y, z] = world.GetVoxel(new Vector3(x, y, z) + position);
    
// 				}
// 			}
// 		}

//         isVoxelMapPopulated = true;

// 	}

// 	void UpdateChunk () {

//         ClearMeshData();

// 		for (int y = 0; y < VoxelData.ChunkHeight; y++) {
// 			for (int x = 0; x < VoxelData.ChunkWidth; x++) {
// 				for (int z = 0; z < VoxelData.ChunkWidth; z++) {

//                     if (world.blocktypes[voxelMap[x,y,z]].isSolid)
// 					    UpdateMeshData (new Vector3(x, y, z)); // sending mesh data the chunk coordinate as a new vector3. so basically each in 128x16x16

// 				}
// 			}
// 		}

//         CreateMesh();

// 	}

//     void ClearMeshData () {

//         vertexIndex = 0;
//         vertices.Clear();
//         triangles.Clear();
//         uvs.Clear();

//     }

//     public bool isActive {

//         get { return _isActive; }
//         set {

//             _isActive = value;
//             if (chunkObject != null)
//                 chunkObject.SetActive(value);

//         }

//     }

//     public Vector3 position {

//         get { return chunkObject.transform.position; }

//     }

//     // taking in chnk coordinates of a face
//     bool IsVoxelInChunk (int x, int y, int z) {

//         if (x < 0 || x > VoxelData.ChunkWidth - 1 || y < 0 || y > VoxelData.ChunkHeight - 1 || z < 0 || z > VoxelData.ChunkWidth - 1)
//             return false;
//         else
//             return true;

//     }

//     public void EditVoxel (Vector3 pos, byte newID) {

//         int xCheck = Mathf.FloorToInt(pos.x);
//         int yCheck = Mathf.FloorToInt(pos.y);
//         int zCheck = Mathf.FloorToInt(pos.z);

//         xCheck -= Mathf.FloorToInt(chunkObject.transform.position.x);
//         zCheck -= Mathf.FloorToInt(chunkObject.transform.position.z);

//         voxelMap[xCheck, yCheck, zCheck] = newID;

//         UpdateSurroundingVoxels(xCheck, yCheck, zCheck);

//         UpdateChunk();

//     }

//     void UpdateSurroundingVoxels (int x, int y, int z) {

//         Vector3 thisVoxel = new Vector3(x, y, z);

//         for (int p = 0; p < 6; p++) {

//             Vector3 currentVoxel = thisVoxel + VoxelData.faceChecks[p];

//             if (!IsVoxelInChunk((int)currentVoxel.x, (int)currentVoxel.y, (int)currentVoxel.z)) {

//                 world.GetChunkFromVector3(currentVoxel + position).UpdateChunk();

//             }

//         }

//     }

// 	bool CheckVoxel (Vector3 pos) {

// 		int x = Mathf.FloorToInt (pos.x);
// 		int y = Mathf.FloorToInt (pos.y);
// 		int z = Mathf.FloorToInt (pos.z);

//         // converts that chunk position to int

//         // checks if this voxel is outside the bounds of the chunk
//             // if it is, return some other method that checks out of bounds stuff INCLUDING USING GLOBAL COORDINATES! 
//         if (!IsVoxelInChunk(x, y, z))
//             return world.CheckForVoxel(pos + position);

//         // return if chunk at this place is marked as a solid type of block ie not air
// 		return world.blocktypes[voxelMap [x, y, z]].isSolid;

// 	}

//     public byte GetVoxelFromGlobalVector3 (Vector3 pos) {

//         int xCheck = Mathf.FloorToInt(pos.x);
//         int yCheck = Mathf.FloorToInt(pos.y);
//         int zCheck = Mathf.FloorToInt(pos.z);

//         xCheck -= Mathf.FloorToInt(chunkObject.transform.position.x);
//         zCheck -= Mathf.FloorToInt(chunkObject.transform.position.z);

//         return voxelMap[xCheck, yCheck, zCheck];

//     }

//     // taking in a new Vector3 of a specific block with its chunk specific coordinate, ie somewhere in a 16x16x128 chunk. thats what pos is
// 	void UpdateMeshData (Vector3 pos) {

//         // p is only 0-5
// 		for (int p = 0; p < 6; p++) { 

//             // sending checkvoxel chunk coordinates plus each increment and decrement of the block, so basically the coordinates of each block face
//             // check voxel basically asks is this out of bounds or a not-solid block
// 			if (!CheckVoxel(pos + VoxelData.faceChecks[p])) {

//                 // in the chunk index of blocks, get the blockID
//                 byte blockID = voxelMap[(int)pos.x, (int)pos.y, (int)pos.z];

//                 // add 
// 				vertices.Add (pos + VoxelData.voxelVerts [VoxelData.voxelTris [p, 0]]);
// 				vertices.Add (pos + VoxelData.voxelVerts [VoxelData.voxelTris [p, 1]]);
// 				vertices.Add (pos + VoxelData.voxelVerts [VoxelData.voxelTris [p, 2]]);
// 				vertices.Add (pos + VoxelData.voxelVerts [VoxelData.voxelTris [p, 3]]);

//                 AddTexture(world.blocktypes[blockID].GetTextureID(p));

// 				triangles.Add (vertexIndex);
// 				triangles.Add (vertexIndex + 1);
// 				triangles.Add (vertexIndex + 2);
// 				triangles.Add (vertexIndex + 2);
// 				triangles.Add (vertexIndex + 1);
// 				triangles.Add (vertexIndex + 3);
// 				vertexIndex += 4;

// 			}
// 		}

// 	}

// 	void CreateMesh () {

// 		Mesh mesh = new Mesh ();
// 		mesh.vertices = vertices.ToArray ();
// 		mesh.triangles = triangles.ToArray ();
// 		mesh.uv = uvs.ToArray ();

// 		mesh.RecalculateNormals ();

// 		meshFilter.mesh = mesh;

// 	}

//     void AddTexture (int textureID) {

//         float y = textureID / VoxelData.TextureAtlasSizeInBlocks;
//         float x = textureID - (y * VoxelData.TextureAtlasSizeInBlocks);

//         x *= VoxelData.NormalizedBlockTextureSize;
//         y *= VoxelData.NormalizedBlockTextureSize;

//         y = 1f - y - VoxelData.NormalizedBlockTextureSize;

//         uvs.Add(new Vector2(x, y));
//         uvs.Add(new Vector2(x, y + VoxelData.NormalizedBlockTextureSize));
//         uvs.Add(new Vector2(x + VoxelData.NormalizedBlockTextureSize, y));
//         uvs.Add(new Vector2(x + VoxelData.NormalizedBlockTextureSize, y + VoxelData.NormalizedBlockTextureSize));


//     }

// }

// public class ChunkCoord {

//     public int x;
//     public int z;

//     public ChunkCoord () {

//         x = 0;
//         z = 0;

//     }

//     public ChunkCoord (int _x, int _z) {

//         x = _x;
//         z = _z;

//     }

//     public ChunkCoord (Vector3 pos) {

//         int xCheck = Mathf.FloorToInt(pos.x);
//         int zCheck = Mathf.FloorToInt(pos.z);

//         x = xCheck / VoxelData.ChunkWidth;
//         z = zCheck / VoxelData.ChunkWidth;

//     }

//     public bool Equals (ChunkCoord other) {

//         if (other == null)
//             return false;
//         else if (other.x == x && other.z == z)
//             return true;
//         else
//             return false;

//     }

}
