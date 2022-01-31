using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IValidation
    {
        bool IsInputValidate(string[] strInput);
        bool IsInputPlateauValidate(List<int> plateau);
    }

}
