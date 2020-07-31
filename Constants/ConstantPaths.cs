using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Constants
{
    class ConstantPaths
    {
        public readonly string redHeartImage = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources\\Images\\redFavouriteIcon.png";
        public readonly string greyHeartImage = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources\\Images\\greyFavouriteIcon.png";
        public readonly string crossOutImage = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources\\Images\\cross-out.png";
        public readonly string shoppingListImage = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Resources\\Images\\shopping-list.png";
    }
}
