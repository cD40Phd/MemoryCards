using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLibrary
{
    public class LogicMemory
    {
        private IPaybleInterface play;
        
        private int[] carts = new int[16];

        private bool[] opens = new bool[16];
        public int clickCounter = 0;
        
        private int done;
        private int status;

        private int activPictureA;
        private int activPictureB;

        static Random random = new Random();

        public LogicMemory(IPaybleInterface play)
        {
            this.play = play;
        }
        public void CreateGame()
        {
            clickCounter = 0;
            done = 0;
            status = 0;

            for (int i = 0; i < carts.Length; i++)
            {
                carts[i] = i % (carts.Length / 2) + 1;
            }

            for (int i = 0; i < random.Next(70, 100); i++)
            {
                shuffleСards();
            }

            for (int i = 0; i < carts.Length; i++)
            {
                opens[i] = false;
            }

            for (int i = 0; i < carts.Length; i++)
            {
                play.HideCard(i);
            }


        }

        public void ClikPicture(int numerPicture)
        {
            clickCounter ++;
            play.ShowNumerClic(clickCounter);
            if (opens[numerPicture])
            {
                return;
            }
            switch (status)
            {
                case 0: statusPositionsNull(numerPicture); break;
                case 1: statusPositionsOne(numerPicture); break;
                case 2: statusPositionsTwo(numerPicture); break;
                case 3: statusPositionsThree(numerPicture); break;
                default:break;
            }
        }

        private void shuffleСards()
        {
            int a = random.Next(0, carts.Length);
            int b = random.Next(0, carts.Length);
            if (a == b) return;
            int x;
            x = carts[a];
            carts[a] = carts[b];
            carts[b] = x;
        }

        private void OpenPicture(int numerPicture)
        {
            opens[numerPicture] = true;
            play.ShowCard(numerPicture, carts[numerPicture]);
        }

        private void statusPositionsThree(int numberPicture)
        {
            play.HideCard(activPictureA);
            play.HideCard(activPictureB);
            statusPositionsNull(numberPicture);
        }

        private void statusPositionsTwo(int numberPicture)
        {
            statusPositionsNull(numberPicture);
        }

        private void statusPositionsOne(int numberPicture)
        {
            activPictureB = numberPicture;
            if (activPictureA == activPictureB)
            {
                return;
            }
            play.ShowCard(activPictureB, carts[activPictureB]);
            status = 2;
            if (carts[activPictureA] == carts[activPictureB])
            {
                OpenPicture(activPictureA);
                OpenPicture(activPictureB);
                done += 2;
                if (done == 16)
                {
                    play.ShowWinner(clickCounter);
                }
                else
                {
                    status = 0;
                }
            }
            else
            {
                status = 3;
            }
        }
        
        private void statusPositionsNull(int numberPicture)
        {
            activPictureA = numberPicture;
            play.ShowCard(activPictureA, carts[activPictureA]);
            status = 1;
        }
        
    }
}
