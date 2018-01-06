using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GenerateVoxel : MonoBehaviour {

    List<VoxData> vds;
    private void Awake()
    {
        var bytes = Resources.Load<TextAsset>("chr_rain").bytes;
        string json = Encoding.UTF8.GetString(bytes);
        var md = JsonUtil.JsonHelper.ToObject<List<VoxData>>(json);
        //var data = Resources.Load()
    }
    // Use this for initialization
    void Start ()
    {
	    //for(int i =0; i < vds.Count;i++)
     //   {
     //       PrimitiveType.
     //   }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
[System.Serializable]
public class MainData
{
    public VoxData[] vds;
}
[System.Serializable]
public class VoxData
{
    public int x;
    public int y;
    public int z;
    public int colorIndex;
}

