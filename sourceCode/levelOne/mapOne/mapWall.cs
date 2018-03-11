using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Bushido
{
	public class mapWall
	{
		private List<collisionTiles3> collisionsTiles = new List<collisionTiles3>();

		public List<collisionTiles3> collisionTiles2
		{
			get { return collisionsTiles; }
		}
		private int width, height;

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}


		public void Generate(int[,] map, int size)
		{
			

			for (int x = 0; x < map.GetLength(1); x++)
			{
				for (int y = 0; y < map.GetLength(0); y++)
				{
					int number = map[y, x];
					if (number > 0)
						collisionsTiles.Add(new collisionTiles3(number, new Rectangle(x * size, y * size, size, size)));

					width = (x + 20) * size ;
					height = (y + 20) * size;
				}
			}
		}
		public void Initilize() 
		{

				Generate(new int[,]
			{
				{0,0,0,0,0,8,7,7,7,6,7,7,7,9,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

			}, 128);





		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (collisionTiles3 tile in collisionsTiles)
			{
				tile.Draw(spriteBatch);
			}

		}
	}

}
