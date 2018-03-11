using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Bushido
{
    class mapTile
    {
        Hero styrax;
        EnemyManager enManager;
        private List<collisionTiles2> collisionsTiles = new List<collisionTiles2>();
        public static List<Rectangle> river = new List<Rectangle>();
        public static List<Rectangle> river2 = new List<Rectangle>();
        public static List<Rectangle> step = new List<Rectangle>();
        public static List<Rectangle> step2 = new List<Rectangle>();
        public static List<Rectangle> step3 = new List<Rectangle>();
        public static List<Rectangle> step4 = new List<Rectangle>();


        public List<collisionTiles2> collisionTiles2
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
        public void getManagerAndStyrax(Hero styrax, EnemyManager enManager)
        {
            this.styrax = styrax;
            this.enManager = enManager;
        }

        public void Generate(int[,] map, int size)
        {

            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number > 0)
                        collisionsTiles.Add(new collisionTiles2(number, new Rectangle(x * size, y * size, size, size)));

                    width = (x + 20) * size;
                    height = (y + 20) * size;


                    if (number == 15)
                    {
                        river.Add(new Rectangle((x * size) , (y * size) , 64, 64));
                    }
                    if (number == 16)
                    {
                        river.Add(new Rectangle((x * size) + 3, (y * size), 64, 73));
                    }
                    if (number == 17)
                    {
                        river.Add(new Rectangle((x * size), (y * size), 64, 64));
                    }
                    if (number == 18)
                    {
                        river.Add(new Rectangle((x * size), (y * size), 64, 1));
                    }
                    if (number == 23)
                    {
                        river.Add(new Rectangle((x * size), (y * size), 64, 1));
                    }
                    if (number == 21)
                    {
                        river.Add(new Rectangle((x * size), (y * size), 64, 1));
                        river2.Add(new Rectangle((x * size) + 62, (y * size), 6, 64));
                    }
                    if (number == 26)
                    {
                        step.Add(new Rectangle((x * size), (y * size), 16, 3));
                        step2.Add(new Rectangle((x * size) + 16, (y * size) + 8, 16, 3));
                        step3.Add(new Rectangle((x * size) + 32, (y * size) + 17, 16, 3));
                        step4.Add(new Rectangle((x * size) + 48, (y * size) + 28, 16, 3));
                    }
                    if (number == 28)
                    {
                        step.Add(new Rectangle((x * size), (y * size) + 33, 15, 16));
                        step2.Add(new Rectangle((x * size) + 29, (y * size) + 48, 16, 5));
                        step3.Add(new Rectangle((x * size) + 47, (y * size) + 57, 14, 6));

                    }
                    if (number == 27)
                    {
                        step.Add(new Rectangle((x * size), (y * size) + 10, 64, 51));
                    }
                    if (number == 29)
                    {
                        step.Add(new Rectangle((x * size), (y * size) + 29, 15, 36));
                        step2.Add(new Rectangle((x * size) + 16, (y * size) + 39, 15, 20));
                        step3.Add(new Rectangle((x * size) + 46, (y * size) + 55, 15, 8));
                        step4.Add(new Rectangle((x * size) + 63, (y * size) + 56, 6, 3));
                    }
                    if (number == 3)
                    {
                        river.Add(new Rectangle((x * size), (y * size), 64, 60));
                    }
                    if (number == 24)
                    {
                        river.Add(new Rectangle((x * size) + 59, (y * size), 3, 64));
                    }
                }
            }
        }

        public void Intialize()
        {
            Generate(new int[,]
        {
                    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,11,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,11,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,11,1,1,13,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,7,10,10,12,10,10,14,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,16,17,1,1,1,1,1,1,1,1,1,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,11,1,1,11,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,31,30,32,10,10,10,10,10,10,8,1,1,1,11,1,1,11,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,36,35,34,1,1,1,1,1,1,11,1,1,1,7,10,10,12,10,10,14,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,11,1,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,11,1,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,11,1,1,1,1,1,1,11,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {18,23,21,1,1,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,7,10,10,10,10,10,10,14,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {22,1,24,18,23,21,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {22,1,1,26,28,24,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {22,1,1,33,33,1,26,28,1,1,1,1,1,1,1,1,16,17,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {19,25,20,27,29,1,33,33,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {3,3,3,22,1,24,27,29,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,24,1,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,1,15,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},


        }, 64);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (collisionTiles2 tile in collisionsTiles)
            {
                tile.Draw(spriteBatch);
            }

        }
        public void checkCollision(Rectangle heroRectangle)
        {
            foreach (Rectangle col in step4)
            {

                if (heroRectangle.isOnTopOf5(col))
                {
                    if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }

                }

                if (heroRectangle.isOnRightOf5(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }

                if (heroRectangle.isOnLeftOf5(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }

                if (heroRectangle.isOnBottomOf5(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }
            }
            foreach (Rectangle col in step3)
            {

                if (heroRectangle.isOnTopOf5(col))
                {
                    if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }

                }

                if (heroRectangle.isOnRightOf5(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }

                if (heroRectangle.isOnLeftOf5(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }

                if (heroRectangle.isOnBottomOf5(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }
            }
            foreach (Rectangle col in step2)
            {

                if (heroRectangle.isOnTopOf5(col))
                {
                    if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }

                }

                if (heroRectangle.isOnRightOf5(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }

                if (heroRectangle.isOnLeftOf5(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }

                if (heroRectangle.isOnBottomOf5(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }
            }
            foreach (Rectangle col in step)
            {

                if (heroRectangle.isOnTopOf5(col))
                {
                    if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }

                }

                if (heroRectangle.isOnRightOf5(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }

                if (heroRectangle.isOnLeftOf5(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }

                if (heroRectangle.isOnBottomOf5(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                      
                    }
                }
            }

            foreach (Rectangle col in river)
            {

                if (heroRectangle.isOnTopOf5(col))
                {
                    if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }

                }

                if (heroRectangle.isOnRightOf5(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }

                if (heroRectangle.isOnLeftOf5(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }

                if (heroRectangle.isOnBottomOf5(col))
                {
                    if (styrax.lookingDirection == 1 || styrax.lookingDirection == 5 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                       
                    }
                }
            }
            foreach (Rectangle col in river2)
            {

                if (heroRectangle.isOnTopOf5(col))
                {
                    if (styrax.lookingDirection == 3 || styrax.lookingDirection == 6 || styrax.lookingDirection == 7)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }

                }

                if (heroRectangle.isOnRightOf5(col))
                {
                    if (styrax.lookingDirection == 2 || styrax.lookingDirection == 5 || styrax.lookingDirection == 6)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }

                if (heroRectangle.isOnLeftOf5(col))
                {
                    if (styrax.lookingDirection == 4 || styrax.lookingDirection == 7 || styrax.lookingDirection == 8)
                    {
                        styrax.direction = Vector2.Zero;
                        
                    }
                }

                if (heroRectangle.isOnBottomOf5(col))
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

            
            foreach (Rectangle col in river)
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
            foreach (Rectangle col in river2)
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
            foreach (Rectangle col in step)
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
            foreach (Rectangle col in step2)
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
            foreach (Rectangle col in step3)
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
            foreach (Rectangle col in step4)
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
    static class RectangleHelper4
    {
        const int penetrationMargin = 5;

        public static bool isOnTopOf5(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin + 5 && r1.Bottom <= r2.Top + 1
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
        }

        public static bool isOnLeftOf5(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Right - penetrationMargin && r1.Left <= r2.Right + 1 &&
                    r1.Bottom >= r2.Top && r1.Top <= r2.Bottom && r1.Bottom <= r2.Bottom + 1);
        }

        public static bool isOnRightOf5(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right >= r2.Left - penetrationMargin && r1.Right <= r2.Left + 1 &&
              r1.Bottom >= r2.Top && r1.Top <= r2.Bottom && r1.Bottom <= r2.Bottom + 1);
        }
        public static bool isOnBottomOf5(this Rectangle r1, Rectangle r2)
        {
            return (r1.Top >= r2.Bottom - penetrationMargin && r1.Top <= r2.Bottom + 1
                && r1.Right >= r2.Left + 5 && r1.Left <= r2.Right - 5);
        }
    }



}




