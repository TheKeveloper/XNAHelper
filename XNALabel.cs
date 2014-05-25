using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNAHelper
{
    public class XNALabel
    {
        public String Text;
        public SpriteFont Font;
        public String Name;
        public Vector2 Position;
        public SpriteEffects Effects;
        public int ZIndex;
        public Color TextColor;
        public float Scale;
        public float Width { get { return Font.MeasureString(Text).X; } }
        public float Height { get { return Font.MeasureString(Text).Y; } }
        public Vector2 Center
        {
            get
            {
                return new Vector2(Position.X + (Width / 2), Position.Y + (Height / 2));
            }
            set
            {
                Position = new Vector2(value.X - (Width / 2), value.Y - (Height / 2));
            }
        }

        public XNALabel()
        {
            new XNALabel(String.Empty, null, Vector2.Zero);
        }

        public XNALabel(String text, SpriteFont font, Vector2 pos)
        {
            new XNALabel(text, font, pos, Color.White);
        }

        public XNALabel(String text, SpriteFont font, Vector2 pos, Color textColor)
        {
            new XNALabel(text, font, pos, textColor, SpriteEffects.None, 0, 1, String.Empty);
        }

        public XNALabel(String text, SpriteFont font, Vector2 pos, Color textColor, SpriteEffects effects, int zIndex, float scale, String name)
        {
            this.Text = text;
            this.Font = font;
            this.Position = pos;
            this.TextColor = textColor;
            this.Effects = effects;
            this.ZIndex = zIndex;
            this.Scale = scale;
            this.Name = name;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.Font, this.Text, this.Position, this.TextColor, 0, this.Position, this.Scale, this.Effects, this.ZIndex);
        }
    }
}
