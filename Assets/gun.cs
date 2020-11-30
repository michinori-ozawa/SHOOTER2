using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
	public Transform rist;

    LineRenderer lineRenderer;
    Vector3 hitPos;
    Vector3 tmpPos;

    float lazerDistance = 10f;
    float lazerStartPointDistance = 0.15f;
    float lineWidth = 0.1f;
	
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
    }

    // Update is called once per frame
    void Update()
    {
      
	  
		if(Input.GetMouseButtonDown(0))
		{
			lineRenderer.startWidth=0.1f;
				  OnRay();
				  
			//ヒットした結果を入れる変数
			RaycastHit hit;
			
			//Rayが何かにぶつかるとif文が実行される。あたり判定
			if (Physics.Raycast(rist.position,transform.forward, out hit , 100))
			
			{
     
				if (hit.collider.gameObject.tag == "enemy")
				{
				
				　　　　//当ったたオブジェクトのりぎととボディーを取得
					Rigidbody rigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
					//リギットボディーが持ってるメソッドを呼び出している
					rigidbody.AddForce
					(transform.forward * 50f,
					ForceMode.Impulse
					);
					
				}
	 
			//ヒットした結果から名前を取得
			Debug.Log(hit.collider.name);

			}
			
		}else{
			lineRenderer.startWidth=0f;
		}
	  
    }

 void OnRay()
    {      
        Vector3 direction = transform.forward * lazerDistance;
        Vector3 rayStartPosition = transform.forward*lazerStartPointDistance;
        Vector3 pos = transform.position+new Vector3(0,1f,0);
        RaycastHit hit;
        Ray ray = new Ray(pos+rayStartPosition, transform.forward);

        lineRenderer.SetPosition(0,pos + rayStartPosition);

        if (Physics.Raycast(ray, out hit, lazerDistance))
        {
            hitPos = hit.point;
            lineRenderer.SetPosition(1, hitPos);
        }
        else
        {      
            lineRenderer.SetPosition(1, pos + direction);
        }

        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 0.1f);

    }

}



