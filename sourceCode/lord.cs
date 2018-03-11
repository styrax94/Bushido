using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Bushido
{
    class lord : spriteAnimation
    {
        public bool stage1;
        public bool stage2;
        public bool stage3;
        public bool stage4;
        public bool stage5;
        public bool stage6;
        public bool stage7;
        public bool stage8;
        public bool endGameScene;

        Hero styrax;
        SFX soundEffects;
        Texture2D speechBubble;
        SpriteFont fontAyoub;
        Vector2 fontPos;
        EnemyManager enManager;
        public bool imLaughing;
        Timer timer = new Timer();
        public bool finishedSpeaking;
        public lord(Vector2 position) : base(position)
        {
            framesperSecond = 25;

            AddAnimation(1, 0, 0, "idleDown", 98, 142, new Vector2(0, 0));

            imLaughing = false;
            finishedSpeaking = false;
            endGameScene = false;
            playAnimation("idleDown", true);

        }
        public void LoadContent(ContentManager contentOne)
        {
            
            sTexture = contentOne.Load<Texture2D>("lord-Ayoub");
            speechBubble = contentOne.Load<Texture2D>("bubbleSpeech");
            fontAyoub = contentOne.Load<SpriteFont>("Font/borrowedFont");
            
        }

        public override void Update(GameTime gameTime)
        {

            if (!stage1 && !stage2 && !stage3 && !stage4 &&!stage5&&!stage6 && !stage7&&!stage8)
            {
                if (Vector2.Distance(sPosition, styrax.position) <= 200)
                {
                    stage1 = true;

                }
            }
            else if (stage1)
            {
                timer.startTimer(3);
                timer.update(gameTime);
                if (timer.checkTimer)
                {
                    stage1 = false;
                    stage2 = true;
                }
            }
            else if (stage2)
            {
                timer.startTimer(3);
                timer.update(gameTime);
                if (timer.checkTimer)
                {
                    stage2 = false;
                    stage3 = true;
                }
            }
            else if (stage3)
            {
                timer.startTimer(3);
                timer.update(gameTime);
                if (timer.checkTimer)
                {
                    stage3 = false;
                    stage4 = true;
                }
            }
            else if (stage4)
            {
                soundEffects.playLaugh(1);
                finishedSpeaking = true;
                stage4 = false;
                stage5 = true;
            }
            else if (stage5)
            {
                timer.startTimer(7);
                    timer.update(gameTime);
                if (timer.checkTimer)
                {
                    stage4 = true;
                    stage5 = false;
                }
                

                if (endGameScene && Vector2.Distance(sPosition, styrax.position) <= 200)
                {
                    stage5 = false;
                    stage6 = true;
                }
            }
            else if (stage6)
            {
                timer.startTimer(5);
                timer.update(gameTime);
                if (timer.checkTimer)
                {
                    stage6 = false;
                    stage7 = true;
                }

            }
            else if (stage7)
            {
                timer.startTimer(2);
                timer.update(gameTime);
                if (timer.checkTimer)
                {
                    styrax.chaseAyoub = true;
                    stage7 = false;
                    stage8 = true;
                }

            }
            else if (stage8)
            {

            }


            base.Update(gameTime);
        }



        public void getSound(SFX soundEffects)
        {
            this.soundEffects = soundEffects;
        }
        public void drawSpeech(SpriteBatch spritebatch)
        {

            if (stage1)
            {
                spritebatch.Draw(speechBubble, new Rectangle((int)sPosition.X - speechBubble.Width, (int)sPosition.Y , speechBubble.Width, speechBubble.Height), Color.White);
                spritebatch.DrawString(fontAyoub,"You petty Ninja!",new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 10), Color.White);
                spritebatch.DrawString(fontAyoub, "you wish to defy me?", new Vector2((int)sPosition.X -speechBubble.Width+ 10, (int)sPosition.Y + 30), Color.White);
                spritebatch.DrawString(fontAyoub, "and my Zombies?", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 50), Color.White);
            }

           else if (stage2)
            {
                spritebatch.Draw(speechBubble, new Rectangle((int)styrax.position.X + 100, (int)styrax.position.Y, speechBubble.Width, speechBubble.Height), Color.White);
                spritebatch.DrawString(fontAyoub, "You will pay for", new Vector2((int)styrax.position.X + 110, (int)styrax.position.Y+30), Color.White);
                spritebatch.DrawString(fontAyoub, "destroying my clan!!", new Vector2((int)styrax.position.X + 110, (int)styrax.position.Y + 50 ), Color.White);
               
            }
            else if (stage3)
            {
                spritebatch.Draw(speechBubble, new Rectangle((int)sPosition.X - speechBubble.Width, (int)sPosition.Y, speechBubble.Width, speechBubble.Height), Color.White);
                spritebatch.DrawString(fontAyoub, "Hah! Don't make me", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 10), Color.White);
                spritebatch.DrawString(fontAyoub, "laugh. You shall ", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 30), Color.White);
                spritebatch.DrawString(fontAyoub, "become my pawn", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 50), Color.White);
                spritebatch.DrawString(fontAyoub, "just like your clan!!!", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 70), Color.White);
            }
            else if (stage6)
            {
                spritebatch.Draw(speechBubble, new Rectangle((int)sPosition.X - speechBubble.Width, (int)sPosition.Y, speechBubble.Width, speechBubble.Height), Color.White);
                spritebatch.DrawString(fontAyoub, "MY ARMY!!!", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 10), Color.White);
                spritebatch.DrawString(fontAyoub, "INSOLENT FOOl! ", new Vector2((int)sPosition.X - speechBubble.Width + 10, (int)sPosition.Y + 30), Color.White);
            }
            else if (stage7)
            {
                spritebatch.Draw(speechBubble, new Rectangle((int)styrax.position.X + 100, (int)styrax.position.Y, speechBubble.Width, speechBubble.Height), Color.White);
                spritebatch.DrawString(fontAyoub, "I Shall Destroy", new Vector2((int)styrax.position.X + 110, (int)styrax.position.Y + 30), Color.White);
                spritebatch.DrawString(fontAyoub, "YOU!!", new Vector2((int)styrax.position.X + 110, (int)styrax.position.Y + 50), Color.White);
            }
        }

        public void getClasses(Hero styrax,EnemyManager enManager)
        {
            this.styrax = styrax;
            this.enManager = enManager;
        }
    }

}