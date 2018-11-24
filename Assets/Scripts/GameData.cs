using LOLSocketModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class GameData
    {
        

        private static UserDto user;
        public static UserDto User { get { return user; } set { user = value; } }
    }
}
