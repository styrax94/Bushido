using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;


namespace Bushido
{
	class CastleTile
	{
		Hero styrax;


		private List<collisionTilesMapThree> collisionsTiles3 = new List<collisionTilesMapThree>();

		// public static List<Rectangle> houses = new List<Rectangle>();
		public static List<Rectangle> wall = new List<Rectangle>();
        public static List<Rectangle> over = new List<Rectangle>();
        public static List<Rectangle> barrier = new List<Rectangle>();
        public static List<Rectangle> pillow = new List<Rectangle>();


		public List<collisionTilesMapThree> collisionTiles3
		{
			get { return collisionsTiles3; }
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
						collisionsTiles3.Add(new collisionTilesMapThree(number, new Rectangle(x * size, y * size, size, size)));

					width = (x + 20) * size;
					height = (y + 20) * size;


					if (number == 1 || number==5 || number==4)
					{
						wall.Add(new Rectangle((x* size) , (y* size), 32, 32));
					}
					if (number == 12)
					{
						over.Add(new Rectangle((x* size) , (y* size), 32, 10));
					}
					if (number == 11)
					{
						barrier.Add(new Rectangle((x* size) , (y* size), 32, 1));
					}
					if (number == 14 || number==15)
					{
						pillow.Add(new Rectangle((x* size)+5 , (y* size)+10, 32, 10));
					}
				}
			}
		}

		public void Initialize(Hero styrax)
		{
			//mountain.Content = Content;
			this.styrax = styrax;



            Generate(new int[,]

			{
                {0,0,0,0,0,0,0,0,0,0,0,0,6,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,7,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,11,11,11,11,11,11,11,11,11,11,11,13,13,13,13,13,11,11,11,11,11,11,11,11,11,11,11,11,11,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,9,4,4,4,4,4,4,4,4,4,4,4,2,2,2,2,2,2,4,4,4,4,4,4,4,4,4,4,4,4,8,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,8,2,2,2,2,9,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,4,1,2,2,2,2,1,4,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,1,3,2,2,2,2,3,1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,3,2,2,2,2,2,2,3,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,2,2,2,2,2,2,2,2,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

			}, 32);




			Generate(new int[,]

			{   
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,0,0,0,0,0,15,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

				}, 46);





		}


		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (collisionTilesMapThree tile in collisionsTiles3)
			{
				tile.Draw(spriteBatch);

			}
		}
		public void checkCollision(Rectangle heroRectangle)
		{


			
			foreach (Rectangle col in wall)
			{

	           if (heroRectangle.isOnTopOf2(col))
                {
					if (styrax.lookingDirection == 3 || styrax.lookingDirection ==6 || styrax.lookingDirection ==7)
                    {
                        styrax.direction = Vector2.Zero;
                    }

                }

                if (heroRectangle.isOnLeftOf2(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection ==7 || styrax.lookingDirection ==8)
                    {
                        styrax.direction = Vector2.Zero;
                    }
                }

                if (heroRectangle.isOnRightOf2(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection ==5|| styrax.lookingDirection ==6)
                    {
                        styrax.direction = Vector2.Zero;
                    }
                }
                if (heroRectangle.isOnBottomOf2(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection ==5 || styrax.lookingDirection ==8)
                    {
                        styrax.direction = Vector2.Zero;
                    }

                }


			}

	
			foreach (Rectangle col in over)
			{

				if (heroRectangle.isOnTopOf3(col))
				{
					if (styrax.lookingDirection == 3 || styrax.lookingDirection ==6 || styrax.lookingDirection ==7)
					{
						styrax.direction = Vector2.Zero;
					}

				}


				if (heroRectangle.isOnBottomOf3(col))
				{
					if (styrax.lookingDirection == 1 || styrax.lookingDirection ==5 || styrax.lookingDirection ==8)
					{
						styrax.direction = Vector2.Zero;
					}

				}


			}
			foreach (Rectangle col in barrier)
			{

           if (heroRectangle.isOnTopOf2(col))
                {
					if (styrax.lookingDirection == 3 || styrax.lookingDirection ==6 || styrax.lookingDirection ==7)
                    {
                        styrax.direction = Vector2.Zero;
                    }

                }

                if (heroRectangle.isOnLeftOf2(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection ==7 || styrax.lookingDirection ==8)
                    {
                        styrax.direction = Vector2.Zero;
                    }
                }

                if (heroRectangle.isOnRightOf2(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection ==5|| styrax.lookingDirection ==6)
                    {
                        styrax.direction = Vector2.Zero;
                    }
                }
                if (heroRectangle.isOnBottomOf2(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection ==5 || styrax.lookingDirection ==8)
                    {
                        styrax.direction = Vector2.Zero;
                    }

                }


			}
			foreach (Rectangle col in pillow)
			{

           if (heroRectangle.isOnTopOf2(col))
                {
					if (styrax.lookingDirection == 3 || styrax.lookingDirection ==6 || styrax.lookingDirection ==7)
                    {
                        styrax.direction = Vector2.Zero;
                    }

                }

                if (heroRectangle.isOnLeftOf2(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection ==7 || styrax.lookingDirection ==8)
                    {
                        styrax.direction = Vector2.Zero;
                    }
                }

                if (heroRectangle.isOnRightOf2(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection ==5|| styrax.lookingDirection ==6)
                    {
                        styrax.direction = Vector2.Zero;
                    }
                }
                if (heroRectangle.isOnBottomOf2(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection ==5 || styrax.lookingDirection ==8)
                    {
                        styrax.direction = Vector2.Zero;
                    }

                }

			}
		}

		public int checkCollisionforZombies(Rectangle zombieRectangle)
		{
			int i = 0;

			Vector2 check = Vector2.Zero;
			foreach (Rectangle col in wall)
			{

				if (zombieRectangle.isOnTopOf(col))
				{
					i = 1;

				}


				/*if (zombieRectangle.isOnRightOf(col))
				{
					i = 2;
				}

				if (zombieRectangle.isOnLeftOf(col))
				{
					i = 3;
				}*/

				if (zombieRectangle.isOnBottOf(col))
				{
					i = 4;
				}
			}
			foreach (Rectangle col in over)
			{

				if (zombieRectangle.isOnTopOf(col))
				{
					i = 1;

				}


				if (zombieRectangle.isOnRightOf(col))
				{
					i = 2;
				}

				if (zombieRectangle.isOnLeftOf(col))
				{
					i = 3;
				}

				if (zombieRectangle.isOnBottOf(col))
				{
					i = 4;
				}
			}

			foreach (Rectangle col in barrier)
			{

				if (zombieRectangle.isOnTopOf(col))
				{
					i = 1;

				}


				if (zombieRectangle.isOnRightOf(col))
				{
					i = 2;
				}

				if (zombieRectangle.isOnLeftOf(col))
				{
					i = 3;
				}

				if (zombieRectangle.isOnBottOf(col))
				{
					i = 4;
				}
			}
			foreach (Rectangle col in pillow)
			{

				if (zombieRectangle.isOnTopOf(col))
				{
					i = 1;

				}


				if (zombieRectangle.isOnRightOf(col))
				{
					i = 2;
				}

				if (zombieRectangle.isOnLeftOf(col))
				{
					i = 3;
				}

				if (zombieRectangle.isOnBottOf(col))
				{
					i = 4;
				}
			}
			return i;
		}




	}
	static class RectangleHelper3
	{
		const int penetrationMargin = 5;

		public static bool isOnTopOf3(this Rectangle r1, Rectangle r2)
		{
			return (r1.Bottom >= r2.Top - penetrationMargin && r1.Bottom <= r2.Top + 1
				&& r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
		}

		public static bool isOnLeftOf3(this Rectangle r1, Rectangle r2)
		{
			return (r1.Left >= r2.Right - penetrationMargin && r1.Left <= r2.Right + 1 &&
					r1.Bottom >= r2.Top && r1.Top <= r2.Bottom);
		}

		public static bool isOnRightOf3(this Rectangle r1, Rectangle r2)
		{
			return (r1.Right >= r2.Left - penetrationMargin && r1.Right <= r2.Left + 1 &&
			  r1.Bottom >= r2.Top && r1.Top <= r2.Bottom);
		}
		public static bool isOnBottomOf3(this Rectangle r1, Rectangle r2)
		{
			return (r1.Top >= r2.Bottom - penetrationMargin && r1.Top <= r2.Bottom + 1
				&& r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
		}
	}
}