﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cocos2D
{
    public class CCLightningStreak : CCMotionStreak
    {
        private CCLightningTrack _Track;
        private float _CurrentTime = 0f;
        private bool _Cyclical = false;

        public CCLightningStreak(CCPoint start, CCPoint end, float fadeTime, float minSegLength, float streakWidth, CCColor3B color, string pathToTexture)
            : base(fadeTime, minSegLength, streakWidth, color, pathToTexture)
        {
            _Track = new CCLightningTrack(start, end);
        }

        public CCLightningStreak(CCPoint start, CCPoint end, float fadeTime, float minSegLength, float streakWidth, CCColor3B color, CCTexture2D texture)
            : base(fadeTime, minSegLength, streakWidth, color, texture)
        {
            _Track = new CCLightningTrack(start, end);
        }

        public CCLightningStreak(CCPoint start, CCPoint end, float sway, float fadeTime, float minSegLength, float streakWidth, CCColor3B color, string pathToTexture)
            : base(fadeTime, minSegLength, streakWidth, color, pathToTexture)
        {
            _Track = new CCLightningTrack(start, end);
            _Track.Sway = sway;
        }

        public CCLightningStreak(CCPoint start, CCPoint end, float sway, float fadeTime, float minSegLength, float streakWidth, CCColor3B color, CCTexture2D texture)
            : base(fadeTime, minSegLength, streakWidth, color, texture)
        {
            _Track = new CCLightningTrack(start, end);
            _Track.Sway = sway;
        }

        /// <summary>
        /// Set to true if you want to re-start the strike when the 'time' has reached 1. The default is
        /// false, which will stop the strike and fade out the segments.
        /// </summary>
        public virtual bool Cyclical
        {
            get
            {
                return (_Cyclical);
            }
            set
            {
                _Cyclical = value;
            }
        }

        public override void Update(float delta)
        {
            _CurrentTime += delta;
            if (_CurrentTime > 1f)
            {
                if (_Cyclical)
                {
                    // Automatic recycle?
                    _CurrentTime = 0f;
                }
                else
                {
                    // Don't update the position as this strike is just fading now
                    base.Update(delta);
                    return;
                }
            }
            Position = _Track.GetPoint(_CurrentTime);
            base.Update(delta);
        }
    }
}
