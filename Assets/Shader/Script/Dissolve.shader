Shader "Unlit/Dissolve"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Colour", Color) = (1, 1, 1, 1)
        _Time("Time",Float) = (0,0,0,0)
        _AnimationSpeed("Animation Speed", Range(0, 3)) = 0
        _OffsetSize("Offset Size", Range(0, 10)) = 0
    }
    SubShader
    {
       Cull Off
       Blend One OneMinusSrcAlpha

        Pass{

            CGPROGRAM

            #pragma vertex vertexFunc
            #pragma fragment fragmentFunc
            #include "UnityCG.cginc"


            sampler2D _MainTex;

             fixed4 _Color;
             float4 _MainTex_TexelSize;
              float _AnimationSpeed;
              float _OffsetSize;

            struct v2f {
                float4 pos : SV_POSITION;
                half2 uv : TEXCOORD0;
                };

              

                struct appdata{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				};

                 struct vertexOutput{
                    float4 pos : SV_POSITION;
               };

                struct vertexInput{
                float4 vertex : POSITION;
           };


            v2f vertexFunc(appdata_base v){
                    v2f o;

                    float4 worldPos = mul(unity_ObjectToWorld, v.vertex);

                    float displacement = (_Time.y * worldPos.y);
                    

                  
                   v.vertex.y += displacement;                  
                   v.vertex.x -=cos(_Time.y * _AnimationSpeed - v.vertex.y * _OffsetSize);
                   
                   
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.texcoord;

                    return o;
                    }   

            

             fixed4 fragmentFunc(appdata IN): SV_TARGET
				{
					fixed4 pixelColor = tex2D(_MainTex, IN.uv);
					return pixelColor*_Color;
				}

                  

            ENDCG
        }
    }
}
