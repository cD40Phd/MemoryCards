using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MemoryLibrary
{
     public interface IPaybleInterface
    {
        void HideCard(int numerPicture);
        void ShowCard(int numerPicture, int card);
        void ShowWinner(int clickCountern);
        void ShowNumerClic(int clickCounter);
    }
}
