using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Bushido
{
    class Map
    {


        Hero styrax;
        EnemyManager enManager;

        private List<collisionTiles> collisionsTiles = new List<collisionTiles>();

        public static List<Rectangle> houses = new List<Rectangle>();
        public static List<Rectangle> trees = new List<Rectangle>();
		public static List<Rectangle> borderTree = new List<Rectangle>();
		public static List<Rectangle> borderTree2 = new List<Rectangle>();
		public static List<Rectangle> rock = new List<Rectangle>();

        public List<collisionTiles> collisionTiles2
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
                        collisionsTiles.Add(new collisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 20) * size;
                    height = (y + 20) * size;


                     if (number == 5)
                    {
                        houses.Add(new Rectangle((x* size) + 11, (y* size) + 90, 172, 100));
                    }
                    if (number == 1)
                    {
                        trees.Add(new Rectangle((x* size) + 60, (y* size) + 126, 41, 20));
                    }
					  if (number == 14)
                    {
						borderTree.Add(new Rectangle((x* size) + 20, (y* size), 122, 105));
                    }
					  if (number == 15)
                    {
						borderTree.Add(new Rectangle((x* size) + 20, (y* size) , 104, 150));
                    }
					  if (number == 11)
                    {
						borderTree2.Add(new Rectangle((x* size), (y* size), 150, 150));
                    }
					  if (number == 12)
                    {
						borderTree2.Add(new Rectangle((x* size)+15, (y* size) , 128, 150));
                    }
					  if (number == 13)
                    {
						borderTree2.Add(new Rectangle((x* size), (y* size) , 128, 150));
                    }
					  if (number == 10)
                    {
						rock.Add(new Rectangle((x* size) + 9, (y* size)+35 , 74, 50));
                    }

                }




            }
        }
        public void Initialize(Hero styrax, EnemyManager enManager)
        {
            this.styrax = styrax;
            this.enManager = enManager;


            Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,10,0,10,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,10,0},
                {0,0,0,0,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},

            }, 90);



            Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,5,0,5,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,5,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,5,0,5,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},


            }, 192);

            Generate(new int[,]
        {
                {14,12,11,13,0,0,0,0,0,0,0,0,12,11,11,13,14,11},
                {14,0,0,0,1,1,0,0,0,1,1,0,0,0,0,0,14,14},
                {14,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,14,14},
                {14,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,14,14},
                {14,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,14,14},
                {14,1,0,0,1,0,0,0,1,0,0,0,0,0,0,1,14,14},
                {15,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,14,14},
                {0,0,0,0,0,1,0,1,0,0,0,1,0,0,0,0,14,14},
                {0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,1,14,14},
                {0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,15,14},
                {0,12,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,1},


        }, 150);


        }

        public void checkCollision(Rectangle heroRectangle)
        {
			foreach (Rectangle coll in rock)
			{

			   if (heroRectangle.isOnTopOf(coll))
                    {
                        if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                        {
                            styrax.direction = Vector2.Zero;
                         
                        }

                    }

                    if (heroRectangle.isOnRightOf(coll))
                    {
                        if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                        {
                            styrax.direction = Vector2.Zero;
                          
                        }
                    }

                    if (heroRectangle.isOnLeftOf(coll))
                    {
                        if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                        {
                            styrax.direction = Vector2.Zero;
                           
                        }
                    }

                    if (heroRectangle.isOnBottOf(coll))
                    {
                        if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
                        {
                            styrax.direction = Vector2.Zero;
                         
                        }
                    }
			}

			foreach (Rectangle col in borderTree2)
			{

				if (heroRectangle.isOnTopOf(col))
				{
					if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
					{
						styrax.direction = Vector2.Zero;
						
					}

				}

		

				if (heroRectangle.isOnBottOf(col))
				{
					if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
					{
						styrax.direction = Vector2.Zero;
					
					}
				}
			}

			foreach (Rectangle col in borderTree)
			{

				if (heroRectangle.isOnTopOf(col))
				{
					if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
					{
						styrax.direction = Vector2.Zero;
						
					}

				}

				if (heroRectangle.isOnRightOf(col))
				{
					if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
					{
						styrax.direction = Vector2.Zero;
						
					}
				}

				if (heroRectangle.isOnLeftOf(col))
				{
					if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
					{
						styrax.direction = Vector2.Zero;
						
					}
				}

				if (heroRectangle.isOnBottOf(col))
				{
					if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
					{
						styrax.direction = Vector2.Zero;
						
					}
				}
			}


			foreach (Rectangle col in trees)
			{

				if (heroRectangle.isOnTopOf(col))
				{
					if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
					{
						styrax.direction = Vector2.Zero;
						
					}

				}

				if (heroRectangle.isOnRightOf(col))
				{
					if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
					{
						styrax.direction = Vector2.Zero;
						
					}
				}

				if (heroRectangle.isOnLeftOf(col))
				{
					if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
					{
						styrax.direction = Vector2.Zero;
						
					}
				}

				if (heroRectangle.isOnBottOf(col))
				{
					if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
					{
						styrax.direction = Vector2.Zero;
						
					}
				}
			}
                //collisionHouses
                foreach (Rectangle coll in houses)
                {

                    if (heroRectangle.isOnTopOf(coll))
                    {
                        if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                        {
                            styrax.direction = Vector2.Zero;
                            
                        }

                    }

                    if (heroRectangle.isOnRightOf(coll))
                    {
                        if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                        {
                            styrax.direction = Vector2.Zero;
                           
                        }
                    }

                    if (heroRectangle.isOnLeftOf(coll))
                    {
                        if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                        {
                            styrax.direction = Vector2.Zero;
                            
                        }
                    }

                    if (heroRectangle.isOnBottOf(coll))
                    {
                        if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
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


            foreach (Rectangle col in borderTree2)
            {
                if (zombieRectangle.isOnTopOf(col))
                {
                    i = 1;

                }


                if (zombieRectangle.isOnBottOf(col))
                {
                    i = 4;
                }

            }

            foreach (Rectangle col in borderTree)
            {
               


                if (zombieRectangle.isOnRightOf(col))
                {
                    i = 2;
                }

                if (zombieRectangle.isOnLeftOf(col))
                {
                    i = 3;
                }


            }

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
                foreach (Rectangle coll in houses)
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
            foreach (Rectangle coll in rock)
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

            foreach (Rectangle col in borderTree2)
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
            return  i;
        }
            
        

        public void Draw(SpriteBatch spriteBatch) 
		{
			foreach (collisionTiles tile in collisionsTiles) 
			{
				tile.Draw(spriteBatch);
			}

		}
	}

    static class RectangleHelper
    {
        const int penetrationMargin = 5;

        public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin && r1.Bottom <= r2.Top + 3
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right);
        }

        public static bool isOnLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Right - penetrationMargin && r1.Left <= r2.Right + 1 &&
              r1.Bottom >= r2.Top && r1.Top <= r2.Bottom - 15 && r1.Bottom <= r2.Bottom + 1);         
        }

        public static bool isOnRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Left && r1.Right >= r2.Left -1   &&
              r1.Bottom >= r2.Top && r1.Top <= r2.Bottom && r1.Bottom <= r2.Bottom + 1);
        }

        public static bool isOnBottOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom <= r2.Bottom +10 && r1.Bottom >= r2.Bottom +5 &&
              r1.Right >= r2.Left+5 && r1.Left <= r2.Right);
        }
    }

}
