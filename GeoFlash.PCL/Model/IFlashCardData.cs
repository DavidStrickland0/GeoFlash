using System;
using System.Collections.Generic;
namespace GeoFlash.Library.Model
{
    public interface IFlashCardData
    {
        void CreateFlashCards(int catagory=0);

        List<string> FlashCardCatagories { get; }

    }
}
