using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GeoFlash.World.Localization;
using GeoFlash.Library.Model;
using GeoFlash.Library.ViewModel;


namespace GeoFlash.World.CardLibrary
{
    public class FlashCardData : IFlashCardData
    {
		public void CreateFlashCards(int catagory = 0)
        {
            FlashCardRepo.FlashCards.Clear();
            LoadCards(catagory);
        }
        private void LoadCards(int catagory)
        {
            switch (catagory)
            {
                case 0:
                    addACard("_Africa", "_Angola", "World.ImagePath.AO.png");
                    addACard("_Africa", "_Burkina_Faso", "World.ImagePath.BF.png");
                    addACard("_Africa", "_Burundi", "World.ImagePath.BI.png");
                    addACard("_Africa", "_Benin", "World.ImagePath.BJ.png");
                    addACard("_Africa", "_Botswana", "World.ImagePath.BW.png");
                    addACard("_Africa", "_The_Democratic_Republic_of_the_Congo", "World.ImagePath.CD.png");
                    addACard("_Africa", "_Central_African_Republic", "World.ImagePath.CF.png");
                    addACard("_Africa", "_Congo", "World.ImagePath.CG.png");
                    addACard("_Africa", "_Cote_dIvoire", "World.ImagePath.CI.png");
                    addACard("_Africa", "_Cameroon", "World.ImagePath.CM.png");
                    addACard("_Africa", "_Cabo_Verde", "World.ImagePath.CV.png");
                    addACard("_Africa", "_Djibouti", "World.ImagePath.DJ.png");
                    addACard("_Africa", "_Algeria", "World.ImagePath.DZ.png");
                    addACard("_Africa", "_Egypt", "World.ImagePath.EG.png");
                    addACard("_Africa", "_Western_Sahara", "World.ImagePath.EH.png");
                    addACard("_Africa", "_Eritrea", "World.ImagePath.ER.png");
                    addACard("_Africa", "_Ethiopia", "World.ImagePath.ET.png");
                    addACard("_Africa", "_Gabon", "World.ImagePath.GA.png");
                    addACard("_Africa", "_Ghana", "World.ImagePath.GH.png");
                    addACard("_Africa", "_Gambia", "World.ImagePath.GM.png");
                    addACard("_Africa", "_Guinea", "World.ImagePath.GN.png");
                    addACard("_Africa", "_Equatorial_Guinea", "World.ImagePath.GQ.png");
                    addACard("_Africa", "_Guinea_Bissau", "World.ImagePath.GW.png");
                    addACard("_Africa", "_Kenya", "World.ImagePath.KE.png");
                    addACard("_Africa", "_Comoros", "World.ImagePath.KM.png");
                    addACard("_Africa", "_Liberia", "World.ImagePath.LR.png");
                    addACard("_Africa", "_Lesotho", "World.ImagePath.LS.png");
                    addACard("_Africa", "_Libya", "World.ImagePath.LY.png");
                    addACard("_Africa", "_Morocco", "World.ImagePath.MA.png");
                    addACard("_Africa", "_Madagascar", "World.ImagePath.MG.png");
                    addACard("_Africa", "_Mali", "World.ImagePath.ML.png");
                    addACard("_Africa", "_Mauritania", "World.ImagePath.MR.png");
                    addACard("_Africa", "_Mauritius", "World.ImagePath.MU.png");
                    addACard("_Africa", "_Malawi", "World.ImagePath.MW.png");
                    addACard("_Africa", "_Mozambique", "World.ImagePath.MZ.png");
                    addACard("_Africa", "_Namibia", "World.ImagePath.NA.png");
                    addACard("_Africa", "_Niger", "World.ImagePath.NE.png");
                    addACard("_Africa", "_Nigeria", "World.ImagePath.NG.png");
                    addACard("_Africa", "_Rwanda", "World.ImagePath.RW.png");
                    addACard("_Africa", "_Seychelles", "World.ImagePath.SC.png");
                    addACard("_Africa", "_Sudan", "World.ImagePath.SD.png");
                    addACard("_Africa", "_Saint_Helena", "World.ImagePath.SH.png");
                    addACard("_Africa", "_Sierra_Leone", "World.ImagePath.SL.png");
                    addACard("_Africa", "_Senegal", "World.ImagePath.SN.png");
                    addACard("_Africa", "_Somalia", "World.ImagePath.SO.png");
                    addACard("_Africa", "_South_Sudan", "World.ImagePath.SS.png");
                    addACard("_Africa", "_Sao_Tome_and_Principe", "World.ImagePath.ST.png");
                    addACard("_Africa", "_Swaziland", "World.ImagePath.SZ.png");
                    addACard("_Africa", "_Chad", "World.ImagePath.TD.png");
                    addACard("_Africa", "_Togo", "World.ImagePath.TG.png");
                    addACard("_Africa", "_Tunisia", "World.ImagePath.TN.png");
                    addACard("_Africa", "_United_Republic_of_Tanzania", "World.ImagePath.TZ.png");
                    addACard("_Africa", "_Uganda", "World.ImagePath.UG.png");
                    addACard("_Africa", "_South_Africa", "World.ImagePath.ZA.png");
                    addACard("_Africa", "_Zambia", "World.ImagePath.ZM.png");
                    addACard("_Africa", "_Zimbabwe", "World.ImagePath.ZW.png");
                    break;
                case 1:
                    addACard("_Asia", "_Afghanistan", "World.ImagePath.AF.png");
                    addACard("_Asia", "_Bahrain", "World.ImagePath.BH.png");
                    addACard("_Asia", "_Bangladesh", "World.ImagePath.BD.png");
                    addACard("_Asia", "_Bhutan", "World.ImagePath.BT.png");
                    addACard("_Asia", "_Brunei", "World.ImagePath.BN.png");
                    addACard("_Asia", "_Myanmar", "World.ImagePath.MM.png");
                    addACard("_Asia", "_Cambodia", "World.ImagePath.KH.png");
                    addACard("_Asia", "_China", "World.ImagePath.CN.png");
                    addACard("_Asia", "_Hong_Kong", "World.ImagePath.HK.png");
                    addACard("_Asia", "_India", "World.ImagePath.IN.png");
                    addACard("_Asia", "_Indonesia", "World.ImagePath.ID.png");
                    addACard("_Asia", "_Iran", "World.ImagePath.IR.png");
                    addACard("_Asia", "_Iraq", "World.ImagePath.IQ.png");
                    addACard("_Asia", "_Israel", "World.ImagePath.IL.png");
                    addACard("_Asia", "_Japan", "World.ImagePath.JP.png");
                    addACard("_Asia", "_Jordan", "World.ImagePath.JO.png");
                    addACard("_Asia", "_North_Korea", "World.ImagePath.KP.png");
                    addACard("_Asia", "_South_Korea", "World.ImagePath.KR.png");
                    addACard("_Asia", "_Kuwait", "World.ImagePath.KW.png");
                    addACard("_Asia", "_Kyrgyzstan", "World.ImagePath.KG.png");
                    addACard("_Asia", "_Laos", "World.ImagePath.LA.png");
                    addACard("_Asia", "_Lebanon", "World.ImagePath.LB.png");
                    addACard("_Asia", "_Malaysia", "World.ImagePath.MY.png");
                    addACard("_Asia", "_Maldives", "World.ImagePath.MV.png");
                    addACard("_Asia", "_Mongolia", "World.ImagePath.MN.png");
                    addACard("_Asia", "_Nepal", "World.ImagePath.NP.png");
                    addACard("_Asia", "_Oman", "World.ImagePath.OM.png");
                    addACard("_Asia", "_Pakistan", "World.ImagePath.PK.png");
                    addACard("_Asia", "_Philippines", "World.ImagePath.PH.png");
                    addACard("_Asia", "_Qatar", "World.ImagePath.QA.png");
                    addACard("_Asia", "_Saudi_Arabia", "World.ImagePath.SA.png");
                    addACard("_Asia", "_Singapore", "World.ImagePath.SG.png");
                    addACard("_Asia", "_Sri_Lanka", "World.ImagePath.LK.png");
                    addACard("_Asia", "_Syrian_Arab_Republic", "World.ImagePath.SY.png");
                    addACard("_Asia", "_Taiwan", "World.ImagePath.TW.png");
                    addACard("_Asia", "_Tajikistan", "World.ImagePath.TJ.png");
                    addACard("_Asia", "_Thailand", "World.ImagePath.TH.png");
                    addACard("_Asia", "_Timor_Leste", "World.ImagePath.TL.png");
                    addACard("_Asia", "_Turkmenistan", "World.ImagePath.TM.png");
                    addACard("_Asia", "_United_Arab_Emirates", "World.ImagePath.AE.png");
                    addACard("_Asia", "_Uzbekistan", "World.ImagePath.UZ.png");
                    addACard("_Asia", "_Vietnam", "World.ImagePath.VN.png");
                    addACard("_Asia", "_Yemen", "World.ImagePath.YE.png");
                    break;
                case 2:
                    addACard("_Australia", "_Australia", "World.ImagePath.AU.png");
                    addACard("_Australia", "_Fiji", "World.ImagePath.FJ.png");
                    addACard("_Australia", "_Marshall_Islands", "World.ImagePath.MH.png");
                    addACard("_Australia", "_Micronesia", "World.ImagePath.FM.png");
                    addACard("_Australia", "_Nauru", "World.ImagePath.NR.png");
                    addACard("_Australia", "_New_Zealand", "World.ImagePath.NZ.png");
                    addACard("_Australia", "_Palau", "World.ImagePath.PW.png");
                    addACard("_Australia", "_Papua_New_Guinea", "World.ImagePath.PG.png");
                    addACard("_Australia", "_Samoa", "World.ImagePath.WS.png");
                    addACard("_Australia", "_Solomon_Islands", "World.ImagePath.SB.png");
                    addACard("_Australia", "_Tonga", "World.ImagePath.TO.png");
                    addACard("_Australia", "_Tuvalu", "World.ImagePath.TV.png");
                    addACard("_Australia", "_Vanuatu", "World.ImagePath.VU.png");
                    break;
                case 3:
                    addACard("_Europe", "_Russia", "World.ImagePath.RU.png");
                    addACard("_Europe", "_Ukraine", "World.ImagePath.UA.png");
                    addACard("_Europe", "_France", "World.ImagePath.FR.png");
                    addACard("_Europe", "_Spain", "World.ImagePath.ES.png");
                    addACard("_Europe", "_Sweden", "World.ImagePath.SE.png");
                    addACard("_Europe", "_Germany", "World.ImagePath.DE.png");
                    addACard("_Europe", "_Finland", "World.ImagePath.FI.png");
                    addACard("_Europe", "_Norway", "World.ImagePath.NO.png");
                    addACard("_Europe", "_Poland", "World.ImagePath.PL.png");
                    addACard("_Europe", "_Italy", "World.ImagePath.IT.png");
                    addACard("_Europe", "_United_Kingdom", "World.ImagePath.GB.png");
                    addACard("_Europe", "_Romania", "World.ImagePath.RO.png");
                    addACard("_Europe", "_Belarus", "World.ImagePath.BY.png");
                    addACard("_Europe", "_Kazakhstan", "World.ImagePath.KZ.png");
                    addACard("_Europe", "_Greece", "World.ImagePath.GR.png");
                    addACard("_Europe", "_Bulgaria", "World.ImagePath.BG.png");
                    addACard("_Europe", "_Iceland", "World.ImagePath.IS.png");
                    addACard("_Europe", "_Hungary", "World.ImagePath.HU.png");
                    addACard("_Europe", "_Portugal", "World.ImagePath.PT.png");
                    addACard("_Europe", "_Serbia", "World.ImagePath.RS.png");
                    addACard("_Europe", "_Azerbaijan", "World.ImagePath.AZ.png");
                    addACard("_Europe", "_Austria", "World.ImagePath.AT.png");
                    addACard("_Europe", "_Czech_Republic", "World.ImagePath.CZ.png");
                    addACard("_Europe", "_Republic_of_Ireland", "World.ImagePath.IE.png");
                    addACard("_Europe", "_Georgia", "World.ImagePath.GE.png");
                    addACard("_Europe", "_Lithuania", "World.ImagePath.LT.png");
                    addACard("_Europe", "_Latvia", "World.ImagePath.LV.png");
                    addACard("_Europe", "_Croatia", "World.ImagePath.HR.png");
                    addACard("_Europe", "_Bosnia_and_Herzegovina", "World.ImagePath.BA.png");
                    addACard("_Europe", "_Slovakia", "World.ImagePath.SK.png");
                    addACard("_Europe", "_Estonia", "World.ImagePath.EE.png");
                    addACard("_Europe", "_Denmark", "World.ImagePath.DK.png");
                    addACard("_Europe", "_Netherlands", "World.ImagePath.NL.png");
                    addACard("_Europe", "_Switzerland", "World.ImagePath.CH.png");
                    addACard("_Europe", "_Moldova", "World.ImagePath.MD.png");
                    addACard("_Europe", "_Belgium", "World.ImagePath.BE.png");
                    addACard("_Europe", "_Armenia", "World.ImagePath.AM.png");
                    addACard("_Europe", "_Albania", "World.ImagePath.AL.png");
                    addACard("_Europe", "_Republic_of_Macedonia", "World.ImagePath.MK.png");
                    addACard("_Europe", "_Turkey", "World.ImagePath.TR.png");
                    addACard("_Europe", "_Slovenia", "World.ImagePath.SI.png");
                    addACard("_Europe", "_Montenegro", "World.ImagePath.ME.png");
                    addACard("_Europe", "_Cyprus", "World.ImagePath.CY.png");
                    addACard("_Europe", "_Luxembourg", "World.ImagePath.LU.png");
                    addACard("_Europe", "_Andorra", "World.ImagePath.AD.png");
                    addACard("_Europe", "_Malta", "World.ImagePath.MT.png");
                    addACard("_Europe", "_Liechtenstein", "World.ImagePath.LI.png");
                    addACard("_Europe", "_San_Marino", "World.ImagePath.SM.png");
                    addACard("_Europe", "_Monaco", "World.ImagePath.MC.png");
                    addACard("_Europe", "_Vatican_City", "World.ImagePath.VA.png");
                    break;
                case 4:
                    addACard("_North_America", "_United_States", "World.ImagePath.US.png");
                    addACard("_North_America", "_Saint_Pierre_and_Miquelon", "World.ImagePath.PM.png");
                    addACard("_North_America", "_Greenland", "World.ImagePath.GL.png");
                    addACard("_North_America", "_Bermuda", "World.ImagePath.BM.png");
                    addACard("_North_America", "_Canada", "World.ImagePath.CA.png");

                    addACard("_North_America", "_Mexico", "World.ImagePath.MX.png");
                    addACard("_North_America", "_Cuba", "World.ImagePath.CU.png");
                    addACard("_North_America", "_Guatemala", "World.ImagePath.GT.png");
                    addACard("_North_America", "_Haiti", "World.ImagePath.HT.png");
                    addACard("_North_America", "_Dominican_Republic", "World.ImagePath.DO.png");
                    addACard("_North_America", "_Honduras", "World.ImagePath.HN.png");
                    addACard("_North_America", "_Nicaragua", "World.ImagePath.NI.png");
                    addACard("_North_America", "_El_Salvador", "World.ImagePath.SV.png");
                    addACard("_North_America", "_Costa_Rica", "World.ImagePath.CR.png");
                    addACard("_North_America", "_Panama", "World.ImagePath.PA.png");
                    addACard("_North_America", "_Puerto_Rico", "World.ImagePath.PR.png");
                    addACard("_North_America", "_Jamaica", "World.ImagePath.JM.png");
                    addACard("_North_America", "_Trinidad_and_Tobago", "World.ImagePath.TT.png");
                    addACard("_North_America", "_Guadeloupe", "World.ImagePath.GP.png");
                    addACard("_North_America", "_Martinique", "World.ImagePath.MQ.png");
                    addACard("_North_America", "_Bahamas", "World.ImagePath.BS.png");
                    addACard("_North_America", "_Belize", "World.ImagePath.BZ.png");
                    addACard("_North_America", "_Barbados", "World.ImagePath.BB.png");
                    addACard("_North_America", "_Saint_Lucia", "World.ImagePath.LC.png");
                    addACard("_North_America", "_Curacao", "World.ImagePath.CW.png");
                    addACard("_North_America", "_Aruba", "World.ImagePath.AW.png");
                    addACard("_North_America", "_Saint_Vincent_and_the_Grenadines", "World.ImagePath.VC.png");
                    addACard("_North_America", "_United_States_Virgin_Islands", "World.ImagePath.VI.png");
                    addACard("_North_America", "_Grenada", "World.ImagePath.GD.png");
                    addACard("_North_America", "_Antigua_and_Barbuda", "World.ImagePath.AG.png");
                    addACard("_North_America", "_Dominica", "World.ImagePath.DM.png");
                    addACard("_North_America", "_Cayman_Islands", "World.ImagePath.KY.png");
                    addACard("_North_America", "_Saint_Kitts_and_Nevis", "World.ImagePath.KN.png");
                    addACard("_North_America", "_Sint_Maarten", "World.ImagePath.SX.png");
                    addACard("_North_America", "_Turks_and_Caicos_Islands", "World.ImagePath.TC.png");
                    addACard("_North_America", "_Saint_Martin", "World.ImagePath.MF.png");
                    addACard("_North_America", "_British_Virgin_Islands", "World.ImagePath.VG.png");
                    addACard("_North_America", "_Anguilla", "World.ImagePath.AI.png");
                    addACard("_North_America", "_Saint_Barthelemy", "World.ImagePath.BL.png");
                    addACard("_North_America", "_Montserrat", "World.ImagePath.MS.png");

                    break;
                case 5:
                    addACard("_South_America", "_Argentina", "World.ImagePath.AR.png");
                    addACard("_South_America", "_Bolivia", "World.ImagePath.BO.png");
                    addACard("_South_America", "_Brazil", "World.ImagePath.BR.png");
                    addACard("_South_America", "_Chile", "World.ImagePath.CL.png");
                    addACard("_South_America", "_Colombia", "World.ImagePath.CO.png");
                    addACard("_South_America", "_Ecuador", "World.ImagePath.EC.png");
                    addACard("_South_America", "_French_Guiana", "World.ImagePath.GF.png");
                    addACard("_South_America", "_Guyana", "World.ImagePath.GY.png");
                    addACard("_South_America", "_Paraguay", "World.ImagePath.PY.png");
                    addACard("_South_America", "_Peru", "World.ImagePath.PE.png");
                    addACard("_South_America", "_Suriname", "World.ImagePath.SR.png");
                    addACard("_South_America", "_Uruguay", "World.ImagePath.UY.png");
                    addACard("_South_America", "_Venezuela", "World.ImagePath.VE.png");
                    break;
            }

        }

        private static  void addACard(string Category, string title,string ImagePath)
        {
            string localizedTitle = AppResources.ResourceManager.GetString(title);
            string localizedCapitol = AppResources.ResourceManager.GetString(string.Concat(title,"_Capitol"));

            if(localizedTitle!=null)
            {
                title = localizedTitle;
            }

            if (localizedCapitol == null)
            {
                localizedCapitol = "None";
            }

            FlashCardRepo.FlashCards.Add(new FlashCardItem() {ImageCategory = Category, ImageName = title, ImagePath = ImagePath, ImageCapitol = localizedCapitol });
        }

        public List<string> FlashCardCatagories
        {
            get { return new List<string> { "_Africa", "_Asia", "_Australia", "_Europe", "_North_America", "_South_America" }; }
        }
    }
}
