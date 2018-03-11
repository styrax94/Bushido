using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bushido

{
    
     class Camera
    {

        public Matrix transform;
        public Viewport view;
        public Vector2 centre;
        GUI gui;
        HealthBar healthbar;
        
        public Camera(Viewport newView, GUI gui, HealthBar healthbar)
        {
            view = newView;
            this.gui = gui;
            this.healthbar = healthbar;
        }
        public void Update(GameTime gameTime, Hero styrax)
        {
            float X = styrax.position.X;
            float Y = styrax.position.Y;
            centre = new Vector2(X + (64 / 2) - 550, Y + (64 / 2) - 300);
            centre.X = MathHelper.Clamp(centre.X, 0, 1300);
            centre.Y = MathHelper.Clamp(centre.Y, 0, 950);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
            Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));




            //centre = position;

            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
            Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0));

       
                      gui.position = centre;

            if (levelManager.levelIndicator != levelManager.levels.levelThree || levelManager.levelIndicator != levelManager.levels.trainLevel)
                          {
                if (waveManager.bossBattle)
                {
                    healthbar.positions = centre;
                }
            } 


        }
        public Matrix Transform
        {
            get { return transform; }
        }


    }
}