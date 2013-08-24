Shader "Custom/SpriteShader" {
	Properties
	{
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
    }
     
    Category
	{
	    Tags
		{
            "Queue" = "Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
        }
 
        Zwrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Lighting Off
        Cull Back
     
        Fog
		{
            Mode Off
        }
     
        SubShader
		{
            Pass
			{
                SetTexture [_MainTex]
				{
                    Combine texture
                }
            }
        }
    }
}
