﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cocos2D;

namespace tests
{
    public class LightningStreakTest : MotionStreakTest
    {
        public LightningStreakTest()
        {
        }
        public override void OnEnter()
        {
            base.OnEnter();
            TouchEnabled = true;
        }

        public override void TouchesBegan(List<CCTouch> touches)
        {
            foreach (CCTouch t in touches)
            {
                // ask director the the window size
                CCSize size = CCDirector.SharedDirector.WinSize;

                CCPoint center = new CCPoint(size.Width / 2, size.Height / 2);
                CCPoint end = t.Location;
                float fadeTime = CCMacros.CCRandomBetween0And1() * 5f;
                CCLightningStreak s = new CCLightningStreak(center, end, fadeTime, 5f, 4.0f, new CCColor3B(0, 0, 255), TestResource.s_fire);
                AddChild(s);
            }
        }
        public override string title()
        {
            return "Lightning Streak Test";
        }
    }
}
