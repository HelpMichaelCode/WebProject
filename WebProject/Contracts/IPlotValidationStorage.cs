using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Contracts
{
    public interface IPlotValidationStorage
    {
        bool checkIEMIRange();
        bool checkDateRANGE();
        bool checkMissingRange();
        bool checkTotalPlotsReviewedRange();
    }
}
