using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {

        if (Input.GetMouseButton(0))
        {  //点击鼠标 移动鼠标 开始涂色
            Ray lRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit lHit;
            if (Physics.Raycast(lRay, out lHit, 100f))
            {
                MeshCollider meshCollider = lHit.transform.GetComponent<MeshCollider>();

                Renderer lRender = lHit.transform.GetComponent<Renderer>();
                if (lRender)
                {
                    Texture2D lTexture = lRender.sharedMaterial.mainTexture as Texture2D;
                    Vector2 pixelUV = lHit.textureCoord;
                    pixelUV.x *= lTexture.width;
                    pixelUV.y *= lTexture.height;   //得到射线点在2d纹理图片上的坐标

                    Draw(pixelUV, lTexture);
                }
                else
                {
                    SkinnedMeshRenderer render = lHit.transform.GetComponent<SkinnedMeshRenderer>();
                    Texture2D lTexture = render.sharedMaterial.mainTexture as Texture2D;
                    Vector2 pixelUV = lHit.textureCoord;
                    pixelUV.x *= lTexture.width;
                    pixelUV.y *= lTexture.height;

                    Draw(pixelUV, lTexture);
                }

            }
        }

    }

    // 修改纹理上对应点的颜色
    public void Draw(Vector2 pPoint, Texture2D pTexture)
    {


        Rect lRect = new Rect(0, 0, pTexture.width, pTexture.height);

        //pPoint -= new Vector2(brush.width / 2, brush.height / 2);
        int size = 100;
        pPoint -= new Vector2(size/2, size/2);
        
        Debug.Log(pPoint.ToString());

        int lX = Mathf.FloorToInt(pPoint.x);
        int lY = Mathf.FloorToInt(pPoint.y);

        for (int i = 0; i < size; i++)
        {   //Brush 是画笔的纹理 （Texture2D）
            for (int j = 0; j < size; j++)
            {
                Vector2 lPosition = new Vector2(lX + i, lY + j);
                if (lRect.Contains(lPosition)/* && brush.GetPixel(i, j).a > 0.8f*/)
                {
                    pTexture.SetPixel(lX + i, lY + j, Color.red);
                }
            }
        }

        pTexture.Apply();

    }
}
