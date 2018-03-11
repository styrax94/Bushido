using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Bushido
{
	public class Fog
	{
		

		Texture2D texture;
		Vector2[] positions;
		int speed;
		int bgHeight,
		bgWidth;

		public void initialize(ContentManager content, String texturePath, int screenWidth, int screenHeight, int speed) 
		{
			screenWidth = 2400;
			screenHeight = 1600;

			bgHeight = screenHeight;
			bgWidth = screenWidth;





			texture = content.Load<Texture2D>(texturePath);

			this.speed = speed;


			positions = new Vector2[screenWidth / texture.Width + 3];

			for (int i = 0; i < positions.Length; i++) 
			{
				positions[i] = new Vector2(i * texture.Width, 0);
			}
		}
		public void Update() 
		{
			for (int i = 0; i < positions.Length; i++) 
			{
				positions[i].X += speed;
				if (speed <= 0)
				{
					if (positions[i].X <= -texture.Width)
					{
						positions[i].X = texture.Width * (positions.Length - 1);
					}
				}
				else 
				{
					if (positions[i].X >= texture.Width * (positions.Length + 1)) 
					{
						positions[i].X = -texture.Width;
					}
				}
			}
			
		}
		public void Draw(SpriteBatch spriteBatch) 
		{
			for (int i = 0; i < positions.Length; i++) 
			{
				Rectangle recBg = new Rectangle((int)positions[i].X, (int)positions[i].Y, bgWidth, bgHeight);
				spriteBatch.Draw(texture, recBg, Color.White);
				
			}

		}
		

	}
}
