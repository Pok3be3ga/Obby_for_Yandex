Shader"Custom/TopFaceOnly"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
LOD200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "UnityCG.cginc"

struct appdata
{
    float4 vertex : POSITION;
    float3 normal : NORMAL;
    float2 uv : TEXCOORD0;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 pos : SV_POSITION;
    float3 worldNormal : TEXCOORD1;
};

sampler2D _MainTex;

v2f vert(appdata v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    o.worldNormal = normalize(mul((float3x3) unity_ObjectToWorld, v.normal)); // Преобразование нормали
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
                // Отображаем текстуру только на верхней грани
    if (i.worldNormal.y > 0.9)
    {
        return tex2D(_MainTex, i.uv);
    }
    else
    {
        return float4(0, 0, 0, 0); // Остальные стороны прозрачные
    }
}
            ENDCG
        }
    }
FallBack"Diffuse"
}
