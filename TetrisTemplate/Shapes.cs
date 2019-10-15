﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class Shapes
{
    public Texture2D block = TetrisGame.ContentManager.Load<Texture2D>("block");
    public Texture2D yellow = TetrisGame.ContentManager.Load<Texture2D>("yellow");
    public Texture2D blue = TetrisGame.ContentManager.Load<Texture2D>("blue");
    public Texture2D red = TetrisGame.ContentManager.Load<Texture2D>("red");
    public Texture2D green = TetrisGame.ContentManager.Load<Texture2D>("green");
    public Texture2D purple = TetrisGame.ContentManager.Load<Texture2D>("purple");
    public Texture2D babyblue = TetrisGame.ContentManager.Load<Texture2D>("babyblue");
    public Texture2D orange = TetrisGame.ContentManager.Load<Texture2D>("orange");
    public Texture2D[,] array;
    public Point gridpos;
    public Shapes()
    {
        Random random = new Random();
        gridpos = new Point(4, 0);
    }
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        int Height = array.GetLength(1);
        int Width = Height;
        Vector2 position;
        position.X = gridpos.X * block.Width;
        position.Y = gridpos.Y * block.Height;
        for (int y = 0; y != Height; y++)
        {
            for (int x = 0; x != Width; x++)
            {
                if (array[x,y] != block)
                spriteBatch.Draw(array[x, y], position, Color.White);  //als kleur, geef kleur
                position.X += block.Width;
            }
            position.X = gridpos.X * block.Width;
            position.Y += block.Height;
        }
    }
    public void RotateRight() //TODO let op dat geen blokjes buiten het veld komen
    {
        int x = array.GetLength(1);
        Texture2D[,] tempArray = new Texture2D[x,x];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < x; j++)
            {
                tempArray[i, j] = array[x - j - 1, i];
            }
        }
        if (!Collision()) ;
        array = tempArray;
    }

    public void RotateLeft()
    {
        for (int i = 0; i < 3; i++)
        {
            RotateRight();
        }
    }

    public bool Collision()
    {
        bool collision = false;
        int length = array.GetLength(1);
        //switch (direction)
        //{
        //    case "left":
        //        if (gridpos.X <= 0) {
        //            for (int y = 0; y < length; y++)
        //            {
        //                if (array[(-gridpos.X), y] != block)
        //                {
        //                    collision = true;
        //                }
        //            }
        //        }
        //        break;

        //    case "right":
        //        for (int y = 0; y < length; y++)
        //        {
        //            if (array[length, y] != block)
        //            {
        //                collision = true;
        //            }
        //        }
        //        break;
        //    case "bottom":
        //        for (int x = 0; x < length; x++)
        //        {
        //            if (array[x, length] != block)
        //            {
        //                collision = true;
        //            }
        //        }
        //        break;
        //    case "all":
        //        if(Collision("left") || Collision("right") || Collision("bottom"))
        //        break;
        //}
        for (int x = 0; x < length; x++)
        {
            for(int y = 0; y> length; y++)
            {
                if(array[x,y] != block && (x+gridpos.X < 0 || x+gridpos.X >10))
                {
                    collision = true;
                }
            }
        }
        return collision;
    }
}

class T : Shapes
{
    public T()
    {
        array = new Texture2D[3, 3]{               {orange, orange, orange},
                                                                     {block, orange, block},
                                                                     {block, block, block}};
    }
}
class I : Shapes
{
    public I()
    {
        array = new Texture2D[4, 4]{   {block, block, block, block},
                                                        {block, block, block, block},
                                                        {babyblue,babyblue,babyblue,babyblue},
                                                        {block, block, block, block}};
    }
}

class J : Shapes
{
    public J()
    {
        array = new Texture2D[3, 3]{{block, orange, orange},
                                                     {block, orange, block},
                                                    {block, orange, block}};
    }
}
class L : Shapes
{
    public L()
    {
        array = new Texture2D[3, 3]{{block, orange, block},
                                                     {block, orange, block},
                                                     {block, orange, orange}};
    }
}


class S : Shapes
{
    public S()
    {
        array = new Texture2D[3, 3]{{block, orange, orange},
                                                     {orange, orange, block},
                                                     {block, block, block}};
    }
}

class Z : Shapes
{
    public Z()
    {
        array = new Texture2D[3, 3]{{orange, orange, block},
                                                     {block, orange, orange},
                                                    {block, block, block}};
    }
}

class O : Shapes
{
    public O()
    {
        array = new Texture2D[2, 2]{{yellow, yellow},
                                                    {yellow, yellow}};
    }
}
