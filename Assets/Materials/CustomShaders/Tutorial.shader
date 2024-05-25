// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Tutorials/Tutorial" {
    
    Properties {

        _Amplitude("Amplitude", Range(0,1)) = 0.5
        _Thickness("Thickness",Range(0,1)) = 2.5
        _Exponent("Exponent influence", Range(0,1)) = 0.5 
        _Spread("Spread",Range(0.1,10)) = 5
        _Amount("Amount",Integer) = 10

        _Begin("Begin",Vector) = (0,0.5,0,0)
        _End("End",Vector) = (1,0.5,0,0)

    }

    SubShader {

        Pass {

            Tags {"RenderType" = "Transparent"}

            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Back

            CGPROGRAM
            
            #pragma vertex vertexMain
            #pragma fragment fragMain

            #include "UnityCG.cginc"

            struct v2f {

                float4 pos: SV_POSITION;
                float2 uv: TEXCOORD0;
                float4 color: COLOR;

            };

            struct fragOut {

                float4 color: COLOR;

            };

            float _Amplitude;
            float _Thickness;
            float _Spread;
            int _Amount;
            float2 _Begin;
            float2 _End;
            float _Exponent;

            v2f vertexMain(appdata_full IN) {

                v2f OUT;

                OUT.pos = UnityObjectToClipPos(IN.vertex);
                OUT.uv  = IN.texcoord;
                OUT.color = IN.color;

                return OUT;

            }

            float myFunc(float IN) {

                float a = 0.01;
                float b = _Spread;
                return clamp(-a/((b-a)*IN) + 1,0,1);

            }

            float random(float2 IN) {

                return frac(sin(dot(IN,float2(12.9898,78.233))) * 43758.5453123);

            }

            float4 drawLine(float2 beginPoint, float2 endPoint, float2 currentPoint, float thickness ) {

                float2 direction = normalize(endPoint - beginPoint);

                float2 projection = beginPoint + direction * dot(direction, currentPoint - beginPoint);

                float2 height = currentPoint - projection;

                float dist = length(height);

                fixed beginFallback = dot(direction, currentPoint - beginPoint);
                fixed endFallback   = dot(direction, currentPoint - endPoint);

                return (dist < thickness) * (beginFallback > 0) * (endFallback < 0);

            }

            float4 stylize(float IN) {

                float result = smoothstep(0,1,clamp(IN,0,1));

                return myFunc(result);

            }

            fixed _exp(float IN) {

                return 1 - _Exponent * (exp(abs(IN - 0.5)/0.5 - 0.5413) - 0.5820);

            }

            fragOut fragMain(v2f IN) : SV_Target {

                fragOut OUT;

                float defaultThickness = 0.01;

                float4 result = 0;

                float2 actualBegin = float2(0,0.5);
                float2 actualEnd   = float2(1,0.5);

                float2 begin = _Begin;
                float2 end   = _End;

                float2 prev = begin;

                result += drawLine(actualBegin, begin, IN.uv, defaultThickness);

                for (float i = 1; i < _Amount + 1; i++) {

                    float2 middle = lerp(begin, end, i/(_Amount + 1));

                    float rand = clamp(_Amplitude * random(middle * _Time.x),0,1);  

                    middle.y = rand + 0.5 * (1 - _Amplitude);

                    middle.y = 0.5 + (middle.y - 0.5) * _exp(middle.x);

                    result += drawLine(prev, middle, IN.uv,_Thickness);

                    prev = middle;

                }

                result += drawLine(prev, end, IN.uv,_Thickness);

                result += drawLine(end,actualEnd,IN.uv,defaultThickness);

                result.xyz = stylize(result.x);

                OUT.color = result * IN.color;

                return OUT;

            }

            ENDCG

        }     

    }

}