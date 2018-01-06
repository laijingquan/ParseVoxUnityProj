using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GenerateVoxel : MonoBehaviour {

    MainData MD;
    private void Awake()
    {
        var text = Resources.Load<TextAsset>("menger").text;
        MD = LitJson.JsonMapper.ToObject<MainData>(text);
        //var data = Resources.Load()
    }
    // Use this for initialization
    void Start ()
    {
        var voxDatas = MD.voxDatas;
        for(int i =0; i < voxDatas.Count;i++)
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(voxDatas[i].x, voxDatas[i].y, voxDatas[i].z);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class MainData
{
    public List<VoxData> voxDatas;
}

public class VoxData
{
    public int x;
    public int y;
    public int z;
    public int colorIndex;
}

