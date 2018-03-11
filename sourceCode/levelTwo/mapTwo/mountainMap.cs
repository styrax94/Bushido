using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework.Content;





namespace Bushido
{
 class mountainMap
	{


        Hero styrax;
        

		private List<collisionTilesMapTwo> collisionsTiles = new List<collisionTilesMapTwo>();

       // public static List<Rectangle> houses = new List<Rectangle>();
        public static List<Rectangle> trees = new List<Rectangle>();
		public static List<Rectangle> shack = new List<Rectangle>();
        public static List<Rectangle> lordStatue = new List<Rectangle>();
        public static List<Rectangle> statue = new List<Rectangle>();
        public static List<Rectangle> graves = new List<Rectangle>();
        public static List<Rectangle> fence = new List<Rectangle>();
        public static List<Rectangle> fence2 = new List<Rectangle>();
        public static List<Rectangle> fence3 = new List<Rectangle>();
        public static List<Rectangle> fence4 = new List<Rectangle>();
        public static List<Rectangle> fence5 = new List<Rectangle>();
        public static List<Rectangle> triangleTex = new List<Rectangle>();
        public static List<Rectangle> triangleTex2 = new List<Rectangle>();
        public static List<Rectangle> triangleTex3 = new List<Rectangle>();
        public static List<Rectangle> triangleTex4 = new List<Rectangle>();

        public List<collisionTilesMapTwo> collisionTiles2
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
						collisionsTiles.Add(new collisionTilesMapTwo(number, new Rectangle(x * size, y * size, size, size)));

					width = (x + 20) * size;
					height = (y + 20) * size;


                    if (number == 10)
                    {
                        trees.Add(new Rectangle((x * size)+ 58, (y * size)+63, 15, 25));
                    }
					if (number == 9)
					{
						shack.Add(new Rectangle((x * size) + 38, (y * size) + 88, 130, 53));
					}
					if (number == 23) 
					{
						lordStatue.Add(new Rectangle((x* size) + 21, (y* size) + 60, 90, 20));
					}
					if (number == 18) 
					{
						statue.Add(new Rectangle((x* size) + 15, (y* size), 28, 20));
					}
					if (number == 11) 
					{
						graves.Add(new Rectangle((x* size) + 2, (y* size)+20, 47, 17));
					}
					if (number == 15 ) 
					{
						fence.Add(new Rectangle((x* size) + 24, (y* size), 14, 64));
					}
					if (number == 16) 
					{
                        fence2.Add(new Rectangle((x* size) + 24, (y* size), 14, 22));
					}
					if (number == 13) 
					{
                        fence3.Add(new Rectangle((x* size), (y* size)+30, 60, 5));
					}
					if (number == 14) 
					{
						fence4.Add(new Rectangle((x* size), (y* size)+30, 60, 5));
					}
					if (number == 5) 
					{
						triangleTex.Add(new Rectangle((x* size), (y* size), 64, 64));
					}
					if (number == 6) 
					{
						triangleTex2.Add(new Rectangle((x* size), (y* size), 64, 64));
					}
					if (number == 3) 
					{
						triangleTex3.Add(new Rectangle((x* size), (y* size), 64, 64));
					}
					if (number == 4) 
					{
						triangleTex4.Add(new Rectangle((x* size), (y* size), 64, 64));
					}

                }
			}
		}

		public void Initialize( Hero styrax) 
		{
				//mountain.Content = Content;
                 this.styrax = styrax;
            Generate(new int[,]
			{
                {0,0,0,0,0,0,0,0,0,0,0,0,32,32,32,32,32,32,32,31,31,31,31,31,31,31,31,31,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,5,20,29,29,29,29,29,29,30,30,30,30,30,30,30,30,21,6,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,27,28,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,6,0,0,0},
                {0,0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,15,2,2,12,12,12,2,2,6,0,0},
                {0,5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,15,12,12,12,12,12,2,2,2,6,0},
                {5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,15,12,12,12,12,12,2,2,2,2,6},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,15,12,12,12,12,12,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,15,12,12,12,12,12,12,2,2,2,2},
                 {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,15,12,12,12,12,12,12,12,12,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,16,12,12,12,12,12,12,12,12,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,12,12,2,2,2,2,2,2,2,2,12,13,14,13,14,13,14,13,14,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,12,12,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,12,12,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
                {4,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1},
                {1,4,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,27,28,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1,1},
                {1,1,4,2,2,2,2,2,2,2,2,2,2,2,2,2,2,27,12,12,28,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1,1,1},
                {1,1,1,4,2,2,2,2,2,2,2,2,2,2,2,2,27,12,12,12,12,28,2,2,2,2,2,2,2,2,2,2,2,2,2,3,1,1,1,1},
                {1,1,1,1,4,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,3,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,26,26,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},


            }, 64);
            Generate(new int[,]
      {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,40,40,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

          }, 64);


            Generate(new int[,] 
			{ 
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,9,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0},


			
			}, 192);


            Generate(new int[,] 
			{
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,10,0,10,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,10,0,0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,10,10,0,0,0,0,0,0,0,0,0,0,0},
                {0,10,0,0,0,10,0,0,0,22,0,0,0,10,0,0,0,10,0},
                {0,0,0,0,0,10,0,0,0,23,0,0,10,0,0,10,0,0,10},
                {0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,10,0,0,0,0,0,0,0,10,0,10,0,0,10,0,0,0,0},
                {0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,10,0,0,0,0,0,10,0,0,10,0,0,0,10,0,0,0,0},



            }, 128);


			Generate(new int[,] 
			
			{ 
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,11},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,11},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,11},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,11},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,0,0,17,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
				{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,18,0,0,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

			}, 53);




		}


		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (collisionTilesMapTwo tile in collisionsTiles)
			{
				tile.Draw(spriteBatch);
			}

		}
        public void checkCollision(Rectangle heroRectangle)
        {

            

            foreach (Rectangle col in trees)
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

			foreach (Rectangle col in shack )
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
			foreach (Rectangle col in lordStatue)
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

			foreach (Rectangle col in statue)
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
			foreach (Rectangle col in graves)
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
			foreach (Rectangle col in fence)
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
			foreach (Rectangle col in fence2)
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
			foreach (Rectangle col in fence3)
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
			foreach (Rectangle col in fence4)
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
			foreach (Rectangle col in triangleTex)
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
			foreach (Rectangle col in triangleTex2)
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
			foreach (Rectangle col in triangleTex3)
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
			foreach (Rectangle col in triangleTex4)
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
            foreach (Rectangle col in trees)
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

            //collisionHouses
            foreach (Rectangle coll in shack)
            {

                if (zombieRectangle.isOnTopOf(coll))
                {
                    i = 1;

                }


                if (zombieRectangle.isOnRightOf(coll))
                {
                    i = 2;
                }

                if (zombieRectangle.isOnLeftOf(coll))
                {
                    i = 3;
                }

                if (zombieRectangle.isOnBottOf(coll))
                {
                    i = 4;
                }

            }

            foreach (Rectangle col in shack)
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
            foreach (Rectangle col in lordStatue)
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

            foreach (Rectangle col in statue)
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


            
            foreach (Rectangle col in graves)
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
            foreach (Rectangle col in fence)
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
            foreach (Rectangle col in fence2)
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
            foreach (Rectangle col in fence4)
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
            foreach (Rectangle col in triangleTex)
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
            foreach (Rectangle col in triangleTex2)
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
            foreach (Rectangle col in triangleTex3)
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
            foreach (Rectangle col in triangleTex4)
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
    static class RectangleHelper2
    {
        const int penetrationMargin = 5;

        public static bool isOnTopOf2(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin && r1.Bottom <= r2.Top +1
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
        }

        public static bool isOnLeftOf2(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Right - penetrationMargin && r1.Left <= r2.Right + 1 &&
			        r1.Bottom >= r2.Top && r1.Top <= r2.Bottom );
        }

        public static bool isOnRightOf2(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right >= r2.Left - penetrationMargin && r1.Right <= r2.Left +1 &&
              r1.Bottom >= r2.Top && r1.Top <= r2.Bottom );
        }
        public static bool isOnBottomOf2(this Rectangle r1, Rectangle r2)
        {
			return (r1.Top >= r2.Bottom - penetrationMargin && r1.Top <= r2.Bottom + 1
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
        }
    }

}
