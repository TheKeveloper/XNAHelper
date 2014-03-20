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
		public Texture2D Texture;
		public Color color;
		public float Width;
		public float Height;
		public Vector2 Position;
		public Vector2 Direction;
		public float Speed;
		public Rectangle Rect
		{
			get
			{

			}
			set
			{

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
		}
	}
}
