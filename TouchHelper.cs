using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace XNAHelper
{
    class TouchHelper
    {
        TouchCollection touchCollection;
        public TouchLocation Touch;
        public TouchLocationState prevTouchState;
        public TouchLocationState curTouchState;
        public Vector2 curTouchPoint;
        private Vector2 prevTouchPoint;
        private bool FlickActive;

        public TouchHelper()
        {
            prevTouchState = TouchLocationState.Invalid;
            curTouchState = TouchLocationState.Invalid;
        }

        public void Update(TouchCollection NewCollection)
        {
            this.touchCollection = NewCollection;
            Touch = touchCollection[0];
            prevTouchState = curTouchState;
            curTouchState = Touch.State;
        }

        public Vector2 GetFlick()
        {
            Vector2 direction = new Vector2();
            if(curTouchState == TouchLocationState.Pressed)
            {
                FlickActive = true;
                curTouchPoint = Touch.Position;
            }
            if (curTouchState == TouchLocationState.Moved && FlickActive)
            {
                prevTouchPoint = curTouchPoint;
                curTouchPoint = Touch.Position;
                direction = new Vector2(curTouchPoint.X - prevTouchPoint.X, curTouchPoint.Y - prevTouchPoint.Y);
                try
                {
                    direction.Normalize();
                }
                catch (Exception e)
                {
                    direction = Vector2.Zero;
                }
            }
            return direction;
        }
    }
}
