Shader "Hidden/RefreshShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FillAmount("Fill Amount", Range(0, 1)) = 0
        _Intensity ("Grayscale Intensity", Range(0, 1)) = 1 // Интенсивность обесцвечивания
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float AngleBetweenVectors(float2 vecA, float2 vecB)
            {
          

                float dotProduct = dot(vecA, vecB);

                // Векторное произведение 
                float crossProduct = vecA.x * vecB.y - vecA.y * vecB.x;

                // Угол в радианах
                float angleRadians = acos(dotProduct);

                // Определение направления
                if (crossProduct < 0)
                {
                    // Угол по часовой стрелке
                    angleRadians = 2 * 3.14159265359 - angleRadians;
                }

                
                return degrees(angleRadians);
        }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _FillAmount;
            float _Intensity;

            fixed4 frag (v2f i) : SV_Target
            {
                
                // Получаем цвет из текстуры
                fixed4 originalColor = tex2D(_MainTex, i.uv);

                // Вычисляем яркость
                float luminance = dot(originalColor.rgb, float3(0.299, 0.587, 0.114));

                // Смешиваем исходный цвет с черно-белым
                fixed3 grayscaleColor = lerp(originalColor.rgb, luminance, _Intensity);


                float2 vecToCenter = normalize(float2(0,1));
                float2 vecToPoint = normalize(float2(i.uv.x-0.5,i.uv.y-0.5));
                float angle = AngleBetweenVectors(vecToCenter,vecToPoint);

               
              
                
  
                    if (angle <= degrees(_FillAmount*2*UNITY_PI))// & i.uv.x>0.5)
                    {
                        //return tex2D(_MainTex, i.uv);
                        return fixed4(grayscaleColor, originalColor.a);
                    }
                    else
                    {
                        //return fixed4(grayscaleColor, originalColor.a);
                        return tex2D(_MainTex, i.uv);
                        //return fixed4(0.5, 0.5, 0.5, 1); // Прозрачный цвет
                    }
               
                




            }
            ENDCG
        }
    }
}
