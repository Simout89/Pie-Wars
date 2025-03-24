Shader "Custom/HexOutlineShader"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (1,1,1,1) // Цвет обводки
        _OutlineWidth ("Outline Width", Range(0.0, 0.5)) = 0.1 // Ширина обводки
        _FadeStart ("Fade Start", Range(0.0, 1.0)) = 0.8 // Где начинается прозрачность
    }
    
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };
            
            float _OutlineWidth;
            float _FadeStart;
            fixed4 _OutlineColor;
            
            // Вершины гексагона
            static float outerRadius = 10.0;
            static float innerRadius = outerRadius * 0.866025404;
            static float3 corners[7] = {
                float3(0.0, 0.0, outerRadius),
                float3(innerRadius, 0.0, 0.5 * outerRadius),
                float3(innerRadius, 0.0, -0.5 * outerRadius),
                float3(0.0, 0.0, -outerRadius),
                float3(-innerRadius, 0.0, -0.5 * outerRadius),
                float3(-innerRadius, 0.0, 0.5 * outerRadius),
                float3(0.0, 0.0, outerRadius)
            };
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }
            
            // Функция для определения расстояния до сегмента линии
            float distanceToSegment(float2 p, float2 a, float2 b)
            {
                float2 pa = p - a;
                float2 ba = b - a;
                float h = clamp(dot(pa, ba) / dot(ba, ba), 0.0, 1.0);
                return length(pa - ba * h);
            }
            
            // Функция для определения расстояния до центра
            float distanceToCenter(float2 p)
            {
                return length(p);
            }
            
            // Функция для проверки, находится ли точка внутри гексагона
            bool isInsideHexagon(float2 p)
            {
                int intersections = 0;
                float2 p1 = float2(corners[0].x, corners[0].z);
                float2 p2;
                
                for (int i = 1; i < 7; i++)
                {
                    p2 = float2(corners[i].x, corners[i].z);
                    
                    if (p.y > min(p1.y, p2.y))
                    {
                        if (p.y <= max(p1.y, p2.y))
                        {
                            if (p.x <= max(p1.x, p2.x))
                            {
                                float xinters = (p.y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) + p1.x;
                                if (p1.x == p2.x || p.x <= xinters)
                                    intersections++;
                            }
                        }
                    }
                    p1 = p2;
                }
                return intersections % 2 != 0;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // Преобразуем мировые координаты в локальные
                float3 localPos = mul(unity_WorldToObject, float4(i.worldPos, 1.0)).xyz;
                
                // Проецируем на XZ плоскость
                float2 pos = float2(localPos.x, localPos.z);
                
                // Проверяем находится ли точка внутри гексагона
                bool inside = isInsideHexagon(pos);
                if (!inside)
                    return float4(0,0,0,0); // Полная прозрачность снаружи
                
                // Проверяем расстояние до центра
                float centerDist = distanceToCenter(pos);
                float normalizedDist = centerDist / outerRadius;
                
                // Проверяем расстояние до каждой стороны гексагона
                float minDist = 10000.0;
                for (int j = 0; j < 6; j++)
                {
                    float2 a = float2(corners[j].x, corners[j].z);
                    float2 b = float2(corners[j+1].x, corners[j+1].z);
                    float dist = distanceToSegment(pos, a, b);
                    minDist = min(minDist, dist);
                }
                
                // Если точка близко к границе - рисуем обводку
                if (minDist < _OutlineWidth)
                {
                    return _OutlineColor;
                }
                
                // Плавное увеличение прозрачности к центру
                float alpha = smoothstep(0.0, _FadeStart, normalizedDist);
                return float4(_OutlineColor.rgb, alpha * _OutlineColor.a);
            }
            ENDCG
        }
    }
}