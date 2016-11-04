using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.DomainServices.EntityFramework;

namespace IntegratedSystem.Web
{
    public partial class IntegratedSystemDomainService : LinqToEntitiesDomainService<HesabR1Entities>
    {

        #region My Methods

        public IQueryable<EntityMetaData> GetEntityMetaDatasByEntitySet(int EntitySet_id)
        {
            return this.ObjectContext.EntityMetaDatas.Where<EntityMetaData>(a => a.EntitySet_id == EntitySet_id);
        }
        public IQueryable<Acct_Ac_tblHesabTafsily> GetAcct_Ac_tblHesabTafsilyByAcct_ActblGoroohTafsily(int Acct_Ac_tblHesabTafsilyID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabTafsily.Where<Acct_Ac_tblHesabTafsily>(a => a.Acct_Ac_tblHesabTafsilyID == Acct_Ac_tblHesabTafsilyID);
        }

        public IQueryable<AD_GeneralItems> GetAD_GeneralItems(int ItemsId)
        {
            return this.ObjectContext.AD_GeneralItems.Where<AD_GeneralItems>(a => a.ItemsId == ItemsId);
        }


        #endregion

        #region Generated Methods

        
        public IQueryable<Acct_Ac_tblAbzareYadavarySatr> GetAcct_Ac_tblAbzareYadavarySatrByAcct_Ac_tblAbzarYadAvaryTitr(int Acct_Ac_tblAbzarYadAvaryTitrID)
        {
            return this.ObjectContext.Acct_Ac_tblAbzareYadavarySatr.Where<Acct_Ac_tblAbzareYadavarySatr>(a => a.Acct_Ac_tblAbzarYadAvaryTitrID == Acct_Ac_tblAbzarYadAvaryTitrID);
        }        





















        public IQueryable<Acct_Ac_tblFasl> GetAcct_Ac_tblFaslByAcct_Ac_tblBab(int Acct_Ac_tblBabID)
        {
            return this.ObjectContext.Acct_Ac_tblFasl.Where<Acct_Ac_tblFasl>(a => a.Acct_Ac_tblBabID == Acct_Ac_tblBabID);
        }




        public IQueryable<Acct_Ac_tblBab> GetAcct_Ac_tblBabByAcct_Ac_tblBakhsh(int Acct_Ac_tblBakhshID)
        {
            return this.ObjectContext.Acct_Ac_tblBab.Where<Acct_Ac_tblBab>(a => a.Acct_Ac_tblBakhshID == Acct_Ac_tblBakhshID);
        }



































































































        public IQueryable<Acct_Ac_tblControlCheck> GetAcct_Ac_tblControlCheckByAcct_Ac_tblControlHesab(int Acct_Ac_tblControlHesabID)
        {
            return this.ObjectContext.Acct_Ac_tblControlCheck.Where<Acct_Ac_tblControlCheck>(a => a.Acct_Ac_tblControlHesabID == Acct_Ac_tblControlHesabID);
        }

































        public IQueryable<Acct_Ac_tblDarkhastCheckSatr> GetAcct_Ac_tblDarkhastCheckSatrByAcct_Ac_tblDarkhastCheck(int Acct_Ac_tblDarkhastCheckID)
        {
            return this.ObjectContext.Acct_Ac_tblDarkhastCheckSatr.Where<Acct_Ac_tblDarkhastCheckSatr>(a => a.Acct_Ac_tblDarkhastCheckID == Acct_Ac_tblDarkhastCheckID);
        }























        public IQueryable<Acct_Ac_tblControlHesab> GetAcct_Ac_tblControlHesabByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        {
            return this.ObjectContext.Acct_Ac_tblControlHesab.Where<Acct_Ac_tblControlHesab>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        }

        public IQueryable<Acct_Ac_tblDarkhastCheck> GetAcct_Ac_tblDarkhastCheckByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        {
            return this.ObjectContext.Acct_Ac_tblDarkhastCheck.Where<Acct_Ac_tblDarkhastCheck>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        }

        public IQueryable<Acct_Ac_tblHadEtebar> GetAcct_Ac_tblHadEtebarByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        {
            return this.ObjectContext.Acct_Ac_tblHadEtebar.Where<Acct_Ac_tblHadEtebar>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        }

        public IQueryable<Acct_Ac_tblMoghayertBanky> GetAcct_Ac_tblMoghayertBankyByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        {
            return this.ObjectContext.Acct_Ac_tblMoghayertBanky.Where<Acct_Ac_tblMoghayertBanky>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        }

        //public IQueryable<Acct_Ac_tblSanadHesabdaryDeleted> GetAcct_Ac_tblSanadHesabdaryDeletedByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        //{
        //    return this.ObjectContext.Acct_Ac_tblSanadHesabdaryDeleted.Where<Acct_Ac_tblSanadHesabdaryDeleted>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        //}

        //public IQueryable<Acct_Ac_tblSanadHesabdaryTitr> GetAcct_Ac_tblSanadHesabdaryTitrByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        //{
        //    return this.ObjectContext.Acct_Ac_tblSanadHesabdaryTitr.Where<Acct_Ac_tblSanadHesabdaryTitr>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        //}






























        public IQueryable<Acct_Ac_tblHesabMarakez> GetAcct_Ac_tblHesabMarakezByAcct_Ac_tblGoroohMarakez(int Acct_Ac_tblGoroohMarakezID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabMarakez.Where<Acct_Ac_tblHesabMarakez>(a => a.Acct_Ac_tblGoroohMarakezID == Acct_Ac_tblGoroohMarakezID);
        }














        public IQueryable<Acct_Ac_tblTafsily> GetAcct_Ac_tblTafsilyByAcct_Ac_tblGoroohTafsily(int Acct_Ac_tblGoroohTafsilyID)
        {
            return this.ObjectContext.Acct_Ac_tblTafsily.Where<Acct_Ac_tblTafsily>(a => a.Acct_Ac_tblGoroohTafsilyID == Acct_Ac_tblGoroohTafsilyID);
        }













        public IQueryable<Acct_Ac_tblGozareshNesbatHayMalySatr> GetAcct_Ac_tblGozareshNesbatHayMalySatrByAcct_Ac_tblGozareshNesbatHayMalyTitr(int Acct_Ac_tblGozareshNesbatHayMalyTitrID)
        {
            return this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalySatr.Where<Acct_Ac_tblGozareshNesbatHayMalySatr>(a => a.Acct_Ac_tblGozareshNesbatHayMalyTitrID == Acct_Ac_tblGozareshNesbatHayMalyTitrID);
        }











        public IQueryable<Acct_Ac_tblTashilat> GetAcct_Ac_tblTashilatByAcct_Ac_tblHadEtebar(int Acct_Ac_tblHadEtebarID)
        {
            return this.ObjectContext.Acct_Ac_tblTashilat.Where<Acct_Ac_tblTashilat>(a => a.Acct_Ac_tblHadEtebarID == Acct_Ac_tblHadEtebarID);
        }








        public IQueryable<Acct_Ac_tblHesabKol> GetAcct_Ac_tblHesabKolByAcct_Ac_tblHesabGoroh(int Acct_Ac_tblHesabGorohID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabKol.Where<Acct_Ac_tblHesabKol>(a => a.Acct_Ac_tblHesabGorohID == Acct_Ac_tblHesabGorohID);
        }



















































        public IQueryable<Acct_Ac_tblSerialChek> GetAcct_Ac_tblSerialChekByAcct_Ac_tblHesabha(int Acct_Ac_tblHesabhaID)
        {
            return this.ObjectContext.Acct_Ac_tblSerialChek.Where<Acct_Ac_tblSerialChek>(a => a.Acct_Ac_tblHesabhaID == Acct_Ac_tblHesabhaID);
        }











        public IQueryable<Acct_Ac_tblHesabMoeen> GetAcct_Ac_tblHesabMoeenByAcct_Ac_tblHesabKol(int Acct_Ac_tblHesabKolID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabMoeen.Where<Acct_Ac_tblHesabMoeen>(a => a.Acct_Ac_tblHesabKolID == Acct_Ac_tblHesabKolID);
        }























        public IQueryable<Acct_Ac_tblAfrad> GetAcct_Ac_tblAfradByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        {
            return this.ObjectContext.Acct_Ac_tblAfrad.Where<Acct_Ac_tblAfrad>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        }

        public IQueryable<Acct_Ac_tblAnvaeTafsily_Moeen> GetAcct_Ac_tblAnvaeTafsily_MoeenByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        {
            return this.ObjectContext.Acct_Ac_tblAnvaeTafsily_Moeen.Where<Acct_Ac_tblAnvaeTafsily_Moeen>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        }

        public IQueryable<Acct_Ac_tblHesabha> GetAcct_Ac_tblHesabhaByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabha.Where<Acct_Ac_tblHesabha>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        }

        public IQueryable<Acct_Ac_tblHesabTafsily> GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabTafsily.Where<Acct_Ac_tblHesabTafsily>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        }

        //public IQueryable<Acct_Ac_tblSanadHesabdary> GetAcct_Ac_tblSanadHesabdaryByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        //{
        //    return this.ObjectContext.Acct_Ac_tblSanadHesabdary.Where<Acct_Ac_tblSanadHesabdary>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        //}

        public IQueryable<Acct_Ac_tblSandoghha> GetAcct_Ac_tblSandoghhaByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        {
            return this.ObjectContext.Acct_Ac_tblSandoghha.Where<Acct_Ac_tblSandoghha>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        }
























        public IQueryable<Acct_Ac_tblHesabRizMarakez> GetAcct_Ac_tblHesabRizMarakezByAcct_Ac_tblHesabTafsily(int Acct_Ac_tblHesabTafsilyID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabRizMarakez.Where<Acct_Ac_tblHesabRizMarakez>(a => a.Acct_Ac_tblHesabTafsilyID == Acct_Ac_tblHesabTafsilyID);
        }

        public IQueryable<Acct_Ac_tblHesabTafsilyMarakez> GetAcct_Ac_tblHesabTafsilyMarakezByAcct_Ac_tblHesabTafsily(int Acct_Ac_tblHesabTafsilyID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabTafsilyMarakez.Where<Acct_Ac_tblHesabTafsilyMarakez>(a => a.Acct_Ac_tblHesabTafsilyID == Acct_Ac_tblHesabTafsilyID);
        }

















































































































































































        public IQueryable<Acct_Ac_tblMohasebehSarmayeSatr> GetAcct_Ac_tblMohasebehSarmayeSatrByAcct_Ac_tblMohasebehSarmayeTitr(int Acct_Ac_tblMohasebehSarmayeTitrID)
        {
            return this.ObjectContext.Acct_Ac_tblMohasebehSarmayeSatr.Where<Acct_Ac_tblMohasebehSarmayeSatr>(a => a.Acct_Ac_tblMohasebehSarmayeTitrID == Acct_Ac_tblMohasebehSarmayeTitrID);
        }
















        public IQueryable<Acct_Ac_tblPardakhtAghsatBeRiz> GetAcct_Ac_tblPardakhtAghsatBeRizByAcct_Ac_tblPardakhtAghsat(int Acct_Ac_tblPardakhtAghsatID)
        {
            return this.ObjectContext.Acct_Ac_tblPardakhtAghsatBeRiz.Where<Acct_Ac_tblPardakhtAghsatBeRiz>(a => a.Acct_Ac_tblPardakhtAghsatID == Acct_Ac_tblPardakhtAghsatID);
        }















































































































        //public IQueryable<Acct_Ac_tblSanadHesabdary> GetAcct_Ac_tblSanadHesabdaryByAcct_Ac_tblSanadHesabdaryTitr(int Acct_Ac_tblSanadHesabdaryTitrID)
        //{
        //    return this.ObjectContext.Acct_Ac_tblSanadHesabdary.Where<Acct_Ac_tblSanadHesabdary>(a => a.Acct_Ac_tblSanadHesabdaryTitrID == Acct_Ac_tblSanadHesabdaryTitrID);
        //}

        //public IQueryable<Acct_Ac_tblSanadHesabdaryAttachMents> GetAcct_Ac_tblSanadHesabdaryAttachMentsByAcct_Ac_tblSanadHesabdaryTitr(int Acct_Ac_tblSanadHesabdaryTitrID)
        //{
        //    return this.ObjectContext.Acct_Ac_tblSanadHesabdaryAttachMents.Where<Acct_Ac_tblSanadHesabdaryAttachMents>(a => a.Acct_Ac_tblSanadHesabdaryTitrID == Acct_Ac_tblSanadHesabdaryTitrID);
        //}

        //public IQueryable<Acct_Ac_tblSharhKolySanad> GetAcct_Ac_tblSharhKolySanadByAcct_Ac_tblSanadHesabdaryTitr(int Acct_Ac_tblSanadHesabdaryTitrID)
        //{
        //    return this.ObjectContext.Acct_Ac_tblSharhKolySanad.Where<Acct_Ac_tblSharhKolySanad>(a => a.Acct_Ac_tblSanadHesabdaryTitrID == Acct_Ac_tblSanadHesabdaryTitrID);
        //}















        public IQueryable<Acct_Ac_tblSerialSandogh> GetAcct_Ac_tblSerialSandoghByAcct_Ac_tblSandoghha(int Acct_Ac_tblSandoghhaID)
        {
            return this.ObjectContext.Acct_Ac_tblSerialSandogh.Where<Acct_Ac_tblSerialSandogh>(a => a.Acct_Ac_tblSandoghhaID == Acct_Ac_tblSandoghhaID);
        }























































        public IQueryable<Acct_Ac_tblBankS> GetAcct_Ac_tblBankSByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblBankS.Where<Acct_Ac_tblBankS>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblDorehMaly> GetAcct_Ac_tblDorehMalyByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblDorehMaly.Where<Acct_Ac_tblDorehMaly>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblGoroohMarakez> GetAcct_Ac_tblGoroohMarakezByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblGoroohMarakez.Where<Acct_Ac_tblGoroohMarakez>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblGoroohTafsily> GetAcct_Ac_tblGoroohTafsilyByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblGoroohTafsily.Where<Acct_Ac_tblGoroohTafsily>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblMohasebehNesbatHayMaly> GetAcct_Ac_tblMohasebehNesbatHayMalyByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblMohasebehNesbatHayMaly.Where<Acct_Ac_tblMohasebehNesbatHayMaly>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblMohasebehSarmayeTitr> GetAcct_Ac_tblMohasebehSarmayeTitrByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblMohasebehSarmayeTitr.Where<Acct_Ac_tblMohasebehSarmayeTitr>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblProject> GetAcct_Ac_tblProjectByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblProject.Where<Acct_Ac_tblProject>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblShoabBank> GetAcct_Ac_tblShoabBankByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblShoabBank.Where<Acct_Ac_tblShoabBank>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }

        public IQueryable<Acct_Ac_tblUsers_Sherkat> GetAcct_Ac_tblUsers_SherkatByAcct_Ac_tblSherkatha(int Acct_Ac_tblSherkathaID)
        {
            return this.ObjectContext.Acct_Ac_tblUsers_Sherkat.Where<Acct_Ac_tblUsers_Sherkat>(a => a.Acct_Ac_tblSherkathaID == Acct_Ac_tblSherkathaID);
        }











        public IQueryable<Acct_Ac_tblHesabha> GetAcct_Ac_tblHesabhaByAcct_Ac_tblShoabBank(int Acct_Ac_tblShoabBankID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabha.Where<Acct_Ac_tblHesabha>(a => a.Acct_Ac_tblShoabBankID == Acct_Ac_tblShoabBankID);
        }








        public IQueryable<Acct_Ac_tblHesabTafsily> GetAcct_Ac_tblHesabTafsilyByAcct_Ac_tblTafsily(int Acct_Ac_tblTafsilyID)
        {
            return this.ObjectContext.Acct_Ac_tblHesabTafsily.Where<Acct_Ac_tblHesabTafsily>(a => a.Acct_Ac_tblTafsilyID == Acct_Ac_tblTafsilyID);
        }










































        public IQueryable<Acct_Ac_tblPardakhtAghsat> GetAcct_Ac_tblPardakhtAghsatByAcct_Ac_tblTashilat(int Acct_Ac_tblTashilatID)
        {
            return this.ObjectContext.Acct_Ac_tblPardakhtAghsat.Where<Acct_Ac_tblPardakhtAghsat>(a => a.Acct_Ac_tblTashilatID == Acct_Ac_tblTashilatID);
        }

        public IQueryable<Acct_Ac_tblVasighe> GetAcct_Ac_tblVasigheByAcct_Ac_tblTashilat(int Acct_Ac_tblTashilatID)
        {
            return this.ObjectContext.Acct_Ac_tblVasighe.Where<Acct_Ac_tblVasighe>(a => a.Acct_Ac_tblTashilatID == Acct_Ac_tblTashilatID);
        }












        public IQueryable<Acct_Ac_tblUsers_Sherkat> GetAcct_Ac_tblUsers_SherkatByAcct_Ac_tblUsers(int Acct_Ac_tblUsersID)
        {
            return this.ObjectContext.Acct_Ac_tblUsers_Sherkat.Where<Acct_Ac_tblUsers_Sherkat>(a => a.Acct_Ac_tblUsersID == Acct_Ac_tblUsersID);
        }





























        public IQueryable<AD_Organization> GetAD_OrganizationByAD_Client(int ClientID)
        {
            return this.ObjectContext.AD_Organization.Where<AD_Organization>(a => a.ClientID == ClientID);
        }


















        public IQueryable<EntitySet> GetEntitySetByAD_Subsystem(int SubsystemID)
        {
            return this.ObjectContext.EntitySets.Where<EntitySet>(e => e.SubsystemID == SubsystemID);
        }




































        public IQueryable<FooterInfo> GetFooterInfoByEntityMetaData(int id)
        {
            return this.ObjectContext.FooterInfoes.Where<FooterInfo>(f => f.propertyID == id);
        }






        public IQueryable<EntityMetaData> GetEntityMetaDataByEntitySet(int id)
        {
            return this.ObjectContext.EntityMetaDatas.Where<EntityMetaData>(e => e.EntitySet_id == id);
        }











        #endregion


#region  tempppppp




        public IQueryable<Acct_Ac_tblJournalDeleted> GetAcct_Ac_tblJournalDeletedByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        {
            return this.ObjectContext.Acct_Ac_tblJournalDeleted.Where<Acct_Ac_tblJournalDeleted>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        }

        public IQueryable<Acct_Ac_tblJournal> GetAcct_Ac_tblJournalByAcct_Ac_tblDorehMaly(int Acct_Ac_tblDorehMalyID)
        {
            return this.ObjectContext.Acct_Ac_tblJournal.Where<Acct_Ac_tblJournal>(a => a.Acct_Ac_tblDorehMalyID == Acct_Ac_tblDorehMalyID);
        }





















        public IQueryable<Acct_Ac_tblJournalLine> GetAcct_Ac_tblJournalLineByAcct_Ac_tblHesabMoeen(int Acct_Ac_tblHesabMoeenID)
        {
            return this.ObjectContext.Acct_Ac_tblJournalLine.Where<Acct_Ac_tblJournalLine>(a => a.Acct_Ac_tblHesabMoeenID == Acct_Ac_tblHesabMoeenID);
        }

      






        public IQueryable<Acct_Ac_tblJournalLine> GetAcct_Ac_tblJournalLineByAcct_Ac_tblJournal(int Acct_Ac_tblJournalID)
        {
            return this.ObjectContext.Acct_Ac_tblJournalLine.Where<Acct_Ac_tblJournalLine>(a => a.Acct_Ac_tblJournalID == Acct_Ac_tblJournalID);
        }

        public IQueryable<Acct_Ac_tblJournalAttachments> GetAcct_Ac_tblJournalAttachmentsByAcct_Ac_tblJournal(int Acct_Ac_tblJournalID)
        {
            return this.ObjectContext.Acct_Ac_tblJournalAttachments.Where<Acct_Ac_tblJournalAttachments>(a => a.Acct_Ac_tblJournalID == Acct_Ac_tblJournalID);
        }   
           

       


        public IQueryable<Acct_Ac_tblJournal> GetAcct_Ac_tblJournalByAD_GeneralItems(int id)
        {
            return this.ObjectContext.Acct_Ac_tblJournal.Where<Acct_Ac_tblJournal>(a => a.NoeSanad == id);
        }



#endregion
    }
}