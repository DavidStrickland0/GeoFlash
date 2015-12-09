using GeoFlash.Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFlash.Library.Model
{
    public class FlashCardRepo
    {
        static FlashCardRepo()
        {
            FlashCards = new ObservableCollection<FlashCardItem>();
        }

        public static IList<FlashCardItem> FlashCards { get; set; }
        public static void RadomizeList()
        {
            var rnd = new Random();
            SortedDictionary<int, FlashCardItem> sortedDic = new SortedDictionary<int, FlashCardItem>();
            foreach (FlashCardItem item in FlashCards)
            {
                sortedDic.Add(rnd.Next(), item);
            }
            FlashCards = new List<FlashCardItem>(sortedDic.Values);
        }
    }
}
