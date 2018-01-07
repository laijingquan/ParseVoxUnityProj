using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GenerateVoxel : MonoBehaviour {

    MainData MD;
    private void Awake()
    {
        var text = Resources.Load<TextAsset>("castle").text;
        MD = LitJson.JsonMapper.ToObject<MainData>(text);
        //var data = Resources.Load()
    }
    // Use this for initialization
    void Start ()
    {
        
        var voxDatas = MD.voxDatas;
        var rgbas = MD.rgbas;
        var root = new GameObject();
        for(int i =0; i < voxDatas.Count;i++)
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(voxDatas[i].x, voxDatas[i].y, voxDatas[i].z);
            obj.transform.SetParent(root.transform);
            var colorIndex = voxDatas[i].colorIndex-1;

            obj.GetComponent<Renderer>().material.color = new Color(rgbas[colorIndex].r/255f,rgbas[colorIndex].g/255f,rgbas[colorIndex].b/255f,rgbas[colorIndex].a/255f);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class MainData
{
    public List<VoxData> voxDatas;
    public List<RGBA> rgbas;
}

public class VoxData
{
    public int x;
    public int y;
    public int z;
    public int colorIndex;
}

public class RGBA
{
    public int r;
    public int g;
    public int b;
    public int a;
}

