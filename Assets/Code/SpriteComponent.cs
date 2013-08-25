using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Animation
{
    StandTR,
    StandBR,
    StandBL,
    StandTL,
    WalkTR,
    WalkBR,
    WalkBL,
    WalkTL,
    AttackTR,
    AttackBR,
    AttackBL,
    AttackTL
}

public enum Direction
{
    TR,
    BR,
    BL,
    TL
}

public class SpriteAnimation
{
    public Animation animation;
    public Texture2D texture;
    public int frames;

    public SpriteAnimation(Animation animation, Texture2D texture, int frames)
    {
        this.animation = animation;
        this.texture = texture;
        this.frames = frames;
    }
}

[RequireComponent( typeof( MeshRenderer ) )]
public class SpriteComponent : MonoBehaviour
{
    public Texture2D TStandTR;
    public int TStandTRFrames;

    public Texture2D TStandBR;
    public int TStandBRFrames;

    public Texture2D TStandBL;
    public int TStandBLFrames;

    public Texture2D TStandTL;
    public int TStandTLFrames;

    public Texture2D TWalkTR;
    public int TWalkTRFrames;

    public Texture2D TWalkBR;
    public int TWalkBRFrames;

    public Texture2D TWalkBL;
    public int TWalkBLFrames;

    public Texture2D TWalkTL;
    public int TWalkTLFrames;

    public Texture2D TAttackTR;
    public int TAttackTRFrames;

    public Texture2D TAttackBR;
    public int TAttackBRFrames;

    public Texture2D TAttackBL;
    public int TAttackBLFrames;

    public Texture2D TAttackTL;
    public int TAttackTLFrames;



    public Animation ActiveAnimation;
    public Texture2D ActiveTexture;
    public int ActiveTextureFrames;
    public int CurrentFrame;

    public float AnimationSpeed;
    public float NextAnimationUpdate;

    Dictionary<Animation, SpriteAnimation> animations = new Dictionary<Animation, SpriteAnimation>();
    public Direction lastDirection;

    public float Size;
    bool forcedAnimation = false;

    MeshRenderer meshRenderer;

    public void UpdateSize()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        float width = meshRenderer.material.mainTexture.width * Size;
        float height = meshRenderer.material.mainTexture.height * Size;
        transform.localScale = new Vector3( width, height, 1 );
    }

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        EnableSprites(
            new SpriteAnimation( Animation.StandTR, TStandTR, TStandTRFrames ),
            new SpriteAnimation( Animation.StandBR, TStandBR, TStandBRFrames ),
            new SpriteAnimation( Animation.StandBL, TStandBL, TStandBLFrames ),
            new SpriteAnimation( Animation.StandTL, TStandTL, TStandTLFrames ),
            new SpriteAnimation( Animation.WalkTR, TWalkTR, TWalkTRFrames ),
            new SpriteAnimation( Animation.WalkBR, TWalkBR, TWalkBRFrames ),
            new SpriteAnimation( Animation.WalkBL, TWalkBL, TWalkBLFrames ),
            new SpriteAnimation( Animation.WalkTL, TWalkTL, TWalkTLFrames ),
            new SpriteAnimation( Animation.AttackTR, TAttackTR, TAttackTRFrames ),
            new SpriteAnimation( Animation.AttackBR, TAttackBR, TAttackBRFrames ),
            new SpriteAnimation( Animation.AttackBL, TAttackBL, TAttackBLFrames ),
            new SpriteAnimation( Animation.AttackTL, TAttackTL, TAttackTLFrames )
            );

        SetAnimation( Animation.WalkBL, 0.1f );
    }

    void Update()
    {
        if( ActiveTextureFrames == 1 ) return;

        if( Time.time > NextAnimationUpdate )
        {
            CurrentFrame++;
            NextAnimationUpdate = Time.time + AnimationSpeed;

            if( CurrentFrame == ActiveTextureFrames )
            {
                CurrentFrame = 0;
                forcedAnimation = false;
            }

            UpdateUV();
        }
    }

    void UpdateUV()
    {
        meshRenderer.material.mainTextureOffset = new Vector2( CurrentFrame * ( 1f / (float)ActiveTextureFrames ), 0f );
    }

    void SetAnimation( Animation animation, float speed )
    {
        if( animation != ActiveAnimation )
        {
            var spriteAnimation = animations[animation];
            ActiveAnimation = animation;
            AnimationSpeed = speed;
            ActiveTexture = spriteAnimation.texture;
            ActiveTextureFrames = spriteAnimation.frames;
            CurrentFrame = 0;
            NextAnimationUpdate = Time.time + AnimationSpeed;
            meshRenderer.material.mainTexture = ActiveTexture;
            meshRenderer.material.mainTextureScale = new Vector2( 1f / (float)ActiveTextureFrames, 1f );
            UpdateUV();
        }
    }

    public void UseStandAnimation( float speed )
    {
        if( forcedAnimation ) return;
        switch( lastDirection )
        {
            case Direction.TR: SetAnimation( Animation.StandTR, speed ); break;
            case Direction.BR: SetAnimation( Animation.StandBR, speed ); break;
            case Direction.BL: SetAnimation( Animation.StandBL, speed ); break;
            case Direction.TL: SetAnimation( Animation.StandTL, speed ); break;
        }
    }

    public void UseWalkAnimation( float speed, Direction direction )
    {
        if( forcedAnimation ) return;
        switch( direction )
        {
            case Direction.TR: SetAnimation( Animation.WalkTR, speed ); break;
            case Direction.BR: SetAnimation( Animation.WalkBR, speed ); break;
            case Direction.BL: SetAnimation( Animation.WalkBL, speed ); break;
            case Direction.TL: SetAnimation( Animation.WalkTL, speed ); break;
        }

        lastDirection = direction;
    }

    public void UseAttackAnimation( float speed, Direction direction )
    {
        if( forcedAnimation ) return;
        switch( direction )
        {
            case Direction.TR: SetAnimation( Animation.AttackTR, speed ); break;
            case Direction.BR: SetAnimation( Animation.AttackBR, speed ); break;
            case Direction.BL: SetAnimation( Animation.AttackBL, speed ); break;
            case Direction.TL: SetAnimation( Animation.AttackTL, speed ); break;
        }

        lastDirection = direction;
        forcedAnimation = true;
    }

    public void EnableSprites( params SpriteAnimation[] newAnimations )
    {
        foreach( var animation in newAnimations )
            animations.Add( animation.animation, animation );
    }
}
