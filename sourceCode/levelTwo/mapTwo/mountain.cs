using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{
	public class mountain
	{
		protected Texture2D texture;

		public Rectangle rectangle;

		public Rectangle Rectangle
		{

			get { return rectangle; }
			protected set { rectangle = value; }
		}
		private static ContentManager content;
		public static ContentManager Content
		{
			protected get { return content; }
			set { content = value; }
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, rectangle, Color.White);
		}
	}
	public class collisionTilesMapTwo : mountain
	{
		public collisionTilesMapTwo(int i, Rectangle newRectangle)
		{
			texture = Content.Load<Texture2D>("mapTwo/rock" + i);
			this.Rectangle = newRectangle;

		}
	}
}
