using GpsMapLibP3Agr2Library.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GpsMapLibP3Agr2Library.Interfaces
{
    public interface IMovable
    {
        public void MoveBy(Town endTown,Road road, bool fromAtoB);

        public void ChooseWay();

    }
}
