using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine;
using Spine.Unity;
using UnityEditor;

public class SpineAPITest : MonoBehaviour
{

    public float cutSpeed;
    protected SkeletonMecanim skeletonMecanim;
    protected Animator animator;



    protected Skeleton skeleton;
    protected SkeletonData skeletonData;
    protected Spine.Animation moveAnimation;


    void Start()
    {
        skeletonMecanim = GetComponent<SkeletonMecanim>();
        animator = GetComponent<Animator>();
        skeleton = skeletonMecanim.skeleton;
        skeletonData = skeleton.Data;

        //这段代码先雪藏起来
        //AnimationClip clip = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        //clip.SetCurve("", typeof(GameObject), "dummy", AnimationCurve.Linear(0, 0, 10, 0));

        //AnimationClipSettings settings = AnimationUtility.GetAnimationClipSettings(clip);
        //settings.stopTime = 10;
        //AnimationUtility.SetAnimationClipSettings(clip, settings);

        ////get animation , because there are only 1 animation and only 1 timeline so i write like this
        //foreach (Spine.Animation animation in skeletonData.Animations)
        //{
        //    moveAnimation = animation;
        //}

        ////look at this！
        ////This does not take effect. The length is still the original length
        //moveAnimation.Duration = 10;

        ////get TranslateTimeline
        //TranslateTimeline translateTimeline = null;
        //foreach (Timeline timeline in moveAnimation.Timelines)
        //{
        //    translateTimeline = timeline as TranslateTimeline;
        //}

        ////The moving value of this frame has been successfully changed,
        ////but the animation length still remains unchanged
        ////why and how to deal with this orzzzzzzzz
        //translateTimeline.SetFrame(1, 10, 50, 60);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
