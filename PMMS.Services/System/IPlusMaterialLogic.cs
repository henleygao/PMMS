using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMMS.Services.System
{
    public interface IPlusMaterialLogic
    {
        void AddPlusMaterial(PlusMaterialAddView addView);

        IList<PlusMaterialListView> ListPlusMaterial(ListPlusMaterialParmeters parmeters);

        void UpdatePlusMaterial(PlusMaterialUpdateView view);
    }
}
