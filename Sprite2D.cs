//Copyright (c) 2014, Kevin L. Bi, All Rights Reserved. 
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace XNAHelper
{ 
	public class Sprite2D
	{
        public Texture2D Texture
        {
            get;
            private set;
        }
		public Color color;
		public float Width;
		public float Height;
        public float Scale
        {
            get;
            set
            {
                Width = Texture.Width * Scale;
                Height = Texture.Height * Scale;
                Scale = value;
            }
        }
		public Vector2 Position;
        public String name;
        public Vector2 Direction
        {
            get;
            set
            {
                Direction = value;
                Direction.Normalize();
            }
        }
		public float Speed;
		public Rectangle Rect
		{
			get
			{
                return new Rectangle((int)Position.X, (int)Position.Y, (int)Width, (int)Height);
			}
			set
			{
                Position.X = value.X;
                Position.Y = value.Y;
                Width = value.Width;
                Height = value.Height;
			}
		}
        public float RotationAngle;
        public Vector2 RotationOrigin;
        public SpriteEffects spriteEffect;
        public bool Visible;
        public Vector2 Center
        {
            get
            {
                return new Vector2(Position.X + (Width / 2), Position.Y + (Height / 2));
            }
            set
            {
                Position = new Vector2(value.X - (Width / 2), value.Y - (Height / 2));
            }
        }

		public Sprite2D(Texture2D texture, Vector2 position, Color color)
		{
			this.Texture = texture;
			this.color = color;
			this.Width = texture.Width;
			this.Height = texture.Height;
			this.Position = position;
			this.Speed = 0;
			this.Direction = Vector2.Zero;
            this.Visible = true;
		}

        public void Move()
        {
            Position += Direction * Speed;
        }

        public bool CollideWalls(float WindowWidth, float WindowHeight)
        {
            return Position.X <= 0 || Position.Y <= 0 || Position.X + Width >= WindowWidth || Position.Y + Height >= WindowHeight;
        }

        public bool Intersects(Sprite2D sprite)
        {
            return this.Rect.Intersects(sprite.Rect);
        }

        public bool Contains(Vector2 point)
        {
            return this.Rect.Contains(new Point((int)point.X, (int)point.Y));
        }

        public bool Tapped(TouchHelper tHelper)
        {
            if (tHelper.curTouchState == TouchLocationState.Released && (tHelper.prevTouchState == TouchLocationState.Pressed || tHelper.prevTouchState == TouchLocationState.Moved)
                && this.Contains(tHelper.curTouchPoint))
            {
                tHelper.prevTouchState = tHelper.curTouchState;
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                spriteBatch.Draw(this.Texture,
                    this.Rect,
                    null,
                    this.color,
                    this.RotationAngle,
                    this.RotationOrigin,
                    spriteEffect,
                    0);
            }
        }
	}
}
