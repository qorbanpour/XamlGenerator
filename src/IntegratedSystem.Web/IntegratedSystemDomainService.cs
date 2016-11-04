
namespace IntegratedSystem.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the HesabR1Entities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class IntegratedSystemDomainService : LinqToEntitiesDomainService<HesabR1Entities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_CodingDigits' query.
        public IQueryable<Acct_Ac_CodingDigits> GetAcct_Ac_CodingDigits()
        {
            return this.ObjectContext.Acct_Ac_CodingDigits;
        }

        public void InsertAcct_Ac_CodingDigits(Acct_Ac_CodingDigits acct_Ac_CodingDigits)
        {
            if ((acct_Ac_CodingDigits.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_CodingDigits, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_CodingDigits.AddObject(acct_Ac_CodingDigits);
            }
        }

        public void UpdateAcct_Ac_CodingDigits(Acct_Ac_CodingDigits currentAcct_Ac_CodingDigits)
        {
            this.ObjectContext.Acct_Ac_CodingDigits.AttachAsModified(currentAcct_Ac_CodingDigits, this.ChangeSet.GetOriginal(currentAcct_Ac_CodingDigits));
        }

        public void DeleteAcct_Ac_CodingDigits(Acct_Ac_CodingDigits acct_Ac_CodingDigits)
        {
            if ((acct_Ac_CodingDigits.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_CodingDigits, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_CodingDigits.Attach(acct_Ac_CodingDigits);
                this.ObjectContext.Acct_Ac_CodingDigits.DeleteObject(acct_Ac_CodingDigits);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_dtproperties' query.
        public IQueryable<Acct_Ac_dtproperties> GetAcct_Ac_dtproperties()
        {
            return this.ObjectContext.Acct_Ac_dtproperties;
        }

        public void InsertAcct_Ac_dtproperties(Acct_Ac_dtproperties acct_Ac_dtproperties)
        {
            if ((acct_Ac_dtproperties.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_dtproperties, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_dtproperties.AddObject(acct_Ac_dtproperties);
            }
        }

        public void UpdateAcct_Ac_dtproperties(Acct_Ac_dtproperties currentAcct_Ac_dtproperties)
        {
            this.ObjectContext.Acct_Ac_dtproperties.AttachAsModified(currentAcct_Ac_dtproperties, this.ChangeSet.GetOriginal(currentAcct_Ac_dtproperties));
        }

        public void DeleteAcct_Ac_dtproperties(Acct_Ac_dtproperties acct_Ac_dtproperties)
        {
            if ((acct_Ac_dtproperties.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_dtproperties, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_dtproperties.Attach(acct_Ac_dtproperties);
                this.ObjectContext.Acct_Ac_dtproperties.DeleteObject(acct_Ac_dtproperties);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_Hdbh' query.
        public IQueryable<Acct_Ac_Hdbh> GetAcct_Ac_Hdbh()
        {
            return this.ObjectContext.Acct_Ac_Hdbh;
        }

        public void InsertAcct_Ac_Hdbh(Acct_Ac_Hdbh acct_Ac_Hdbh)
        {
            if ((acct_Ac_Hdbh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_Hdbh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_Hdbh.AddObject(acct_Ac_Hdbh);
            }
        }

        public void UpdateAcct_Ac_Hdbh(Acct_Ac_Hdbh currentAcct_Ac_Hdbh)
        {
            this.ObjectContext.Acct_Ac_Hdbh.AttachAsModified(currentAcct_Ac_Hdbh, this.ChangeSet.GetOriginal(currentAcct_Ac_Hdbh));
        }

        public void DeleteAcct_Ac_Hdbh(Acct_Ac_Hdbh acct_Ac_Hdbh)
        {
            if ((acct_Ac_Hdbh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_Hdbh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_Hdbh.Attach(acct_Ac_Hdbh);
                this.ObjectContext.Acct_Ac_Hdbh.DeleteObject(acct_Ac_Hdbh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_MotefareSatr' query.
        public IQueryable<Acct_Ac_MotefareSatr> GetAcct_Ac_MotefareSatr()
        {
            return this.ObjectContext.Acct_Ac_MotefareSatr;
        }

        public void InsertAcct_Ac_MotefareSatr(Acct_Ac_MotefareSatr acct_Ac_MotefareSatr)
        {
            if ((acct_Ac_MotefareSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_MotefareSatr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_MotefareSatr.AddObject(acct_Ac_MotefareSatr);
            }
        }

        public void UpdateAcct_Ac_MotefareSatr(Acct_Ac_MotefareSatr currentAcct_Ac_MotefareSatr)
        {
            this.ObjectContext.Acct_Ac_MotefareSatr.AttachAsModified(currentAcct_Ac_MotefareSatr, this.ChangeSet.GetOriginal(currentAcct_Ac_MotefareSatr));
        }

        public void DeleteAcct_Ac_MotefareSatr(Acct_Ac_MotefareSatr acct_Ac_MotefareSatr)
        {
            if ((acct_Ac_MotefareSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_MotefareSatr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_MotefareSatr.Attach(acct_Ac_MotefareSatr);
                this.ObjectContext.Acct_Ac_MotefareSatr.DeleteObject(acct_Ac_MotefareSatr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_MotefarTitr' query.
        public IQueryable<Acct_Ac_MotefarTitr> GetAcct_Ac_MotefarTitr()
        {
            return this.ObjectContext.Acct_Ac_MotefarTitr;
        }

        public void InsertAcct_Ac_MotefarTitr(Acct_Ac_MotefarTitr acct_Ac_MotefarTitr)
        {
            if ((acct_Ac_MotefarTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_MotefarTitr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_MotefarTitr.AddObject(acct_Ac_MotefarTitr);
            }
        }

        public void UpdateAcct_Ac_MotefarTitr(Acct_Ac_MotefarTitr currentAcct_Ac_MotefarTitr)
        {
            this.ObjectContext.Acct_Ac_MotefarTitr.AttachAsModified(currentAcct_Ac_MotefarTitr, this.ChangeSet.GetOriginal(currentAcct_Ac_MotefarTitr));
        }

        public void DeleteAcct_Ac_MotefarTitr(Acct_Ac_MotefarTitr acct_Ac_MotefarTitr)
        {
            if ((acct_Ac_MotefarTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_MotefarTitr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_MotefarTitr.Attach(acct_Ac_MotefarTitr);
                this.ObjectContext.Acct_Ac_MotefarTitr.DeleteObject(acct_Ac_MotefarTitr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_Table1' query.
        public IQueryable<Acct_Ac_Table1> GetAcct_Ac_Table1()
        {
            return this.ObjectContext.Acct_Ac_Table1;
        }

        public void InsertAcct_Ac_Table1(Acct_Ac_Table1 acct_Ac_Table1)
        {
            if ((acct_Ac_Table1.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_Table1, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_Table1.AddObject(acct_Ac_Table1);
            }
        }

        public void UpdateAcct_Ac_Table1(Acct_Ac_Table1 currentAcct_Ac_Table1)
        {
            this.ObjectContext.Acct_Ac_Table1.AttachAsModified(currentAcct_Ac_Table1, this.ChangeSet.GetOriginal(currentAcct_Ac_Table1));
        }

        public void DeleteAcct_Ac_Table1(Acct_Ac_Table1 acct_Ac_Table1)
        {
            if ((acct_Ac_Table1.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_Table1, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_Table1.Attach(acct_Ac_Table1);
                this.ObjectContext.Acct_Ac_Table1.DeleteObject(acct_Ac_Table1);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblAbzareYadavarySatr' query.
        public IQueryable<Acct_Ac_tblAbzareYadavarySatr> GetAcct_Ac_tblAbzareYadavarySatr()
        {
            return this.ObjectContext.Acct_Ac_tblAbzareYadavarySatr;
        }

        public void InsertAcct_Ac_tblAbzareYadavarySatr(Acct_Ac_tblAbzareYadavarySatr acct_Ac_tblAbzareYadavarySatr)
        {
            if ((acct_Ac_tblAbzareYadavarySatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAbzareYadavarySatr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAbzareYadavarySatr.AddObject(acct_Ac_tblAbzareYadavarySatr);
            }
        }

        public void UpdateAcct_Ac_tblAbzareYadavarySatr(Acct_Ac_tblAbzareYadavarySatr currentAcct_Ac_tblAbzareYadavarySatr)
        {
            this.ObjectContext.Acct_Ac_tblAbzareYadavarySatr.AttachAsModified(currentAcct_Ac_tblAbzareYadavarySatr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblAbzareYadavarySatr));
        }

        public void DeleteAcct_Ac_tblAbzareYadavarySatr(Acct_Ac_tblAbzareYadavarySatr acct_Ac_tblAbzareYadavarySatr)
        {
            if ((acct_Ac_tblAbzareYadavarySatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAbzareYadavarySatr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAbzareYadavarySatr.Attach(acct_Ac_tblAbzareYadavarySatr);
                this.ObjectContext.Acct_Ac_tblAbzareYadavarySatr.DeleteObject(acct_Ac_tblAbzareYadavarySatr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblAbzarYadAvaryTitr' query.
        public IQueryable<Acct_Ac_tblAbzarYadAvaryTitr> GetAcct_Ac_tblAbzarYadAvaryTitr()
        {
            return this.ObjectContext.Acct_Ac_tblAbzarYadAvaryTitr;
        }

        public void InsertAcct_Ac_tblAbzarYadAvaryTitr(Acct_Ac_tblAbzarYadAvaryTitr acct_Ac_tblAbzarYadAvaryTitr)
        {
            if ((acct_Ac_tblAbzarYadAvaryTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAbzarYadAvaryTitr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAbzarYadAvaryTitr.AddObject(acct_Ac_tblAbzarYadAvaryTitr);
            }
        }

        public void UpdateAcct_Ac_tblAbzarYadAvaryTitr(Acct_Ac_tblAbzarYadAvaryTitr currentAcct_Ac_tblAbzarYadAvaryTitr)
        {
            this.ObjectContext.Acct_Ac_tblAbzarYadAvaryTitr.AttachAsModified(currentAcct_Ac_tblAbzarYadAvaryTitr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblAbzarYadAvaryTitr));
        }

        public void DeleteAcct_Ac_tblAbzarYadAvaryTitr(Acct_Ac_tblAbzarYadAvaryTitr acct_Ac_tblAbzarYadAvaryTitr)
        {
            if ((acct_Ac_tblAbzarYadAvaryTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAbzarYadAvaryTitr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAbzarYadAvaryTitr.Attach(acct_Ac_tblAbzarYadAvaryTitr);
                this.ObjectContext.Acct_Ac_tblAbzarYadAvaryTitr.DeleteObject(acct_Ac_tblAbzarYadAvaryTitr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblAfrad' query.
        public IQueryable<Acct_Ac_tblAfrad> GetAcct_Ac_tblAfrad()
        {
            return this.ObjectContext.Acct_Ac_tblAfrad;
        }

        public void InsertAcct_Ac_tblAfrad(Acct_Ac_tblAfrad acct_Ac_tblAfrad)
        {
            if ((acct_Ac_tblAfrad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAfrad, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAfrad.AddObject(acct_Ac_tblAfrad);
            }
        }

        public void UpdateAcct_Ac_tblAfrad(Acct_Ac_tblAfrad currentAcct_Ac_tblAfrad)
        {
            this.ObjectContext.Acct_Ac_tblAfrad.AttachAsModified(currentAcct_Ac_tblAfrad, this.ChangeSet.GetOriginal(currentAcct_Ac_tblAfrad));
        }

        public void DeleteAcct_Ac_tblAfrad(Acct_Ac_tblAfrad acct_Ac_tblAfrad)
        {
            if ((acct_Ac_tblAfrad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAfrad, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAfrad.Attach(acct_Ac_tblAfrad);
                this.ObjectContext.Acct_Ac_tblAfrad.DeleteObject(acct_Ac_tblAfrad);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblAnvaeTafsily_Moeen' query.
        public IQueryable<Acct_Ac_tblAnvaeTafsily_Moeen> GetAcct_Ac_tblAnvaeTafsily_Moeen()
        {
            return this.ObjectContext.Acct_Ac_tblAnvaeTafsily_Moeen;
        }

        public void InsertAcct_Ac_tblAnvaeTafsily_Moeen(Acct_Ac_tblAnvaeTafsily_Moeen acct_Ac_tblAnvaeTafsily_Moeen)
        {
            if ((acct_Ac_tblAnvaeTafsily_Moeen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAnvaeTafsily_Moeen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAnvaeTafsily_Moeen.AddObject(acct_Ac_tblAnvaeTafsily_Moeen);
            }
        }

        public void UpdateAcct_Ac_tblAnvaeTafsily_Moeen(Acct_Ac_tblAnvaeTafsily_Moeen currentAcct_Ac_tblAnvaeTafsily_Moeen)
        {
            this.ObjectContext.Acct_Ac_tblAnvaeTafsily_Moeen.AttachAsModified(currentAcct_Ac_tblAnvaeTafsily_Moeen, this.ChangeSet.GetOriginal(currentAcct_Ac_tblAnvaeTafsily_Moeen));
        }

        public void DeleteAcct_Ac_tblAnvaeTafsily_Moeen(Acct_Ac_tblAnvaeTafsily_Moeen acct_Ac_tblAnvaeTafsily_Moeen)
        {
            if ((acct_Ac_tblAnvaeTafsily_Moeen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAnvaeTafsily_Moeen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAnvaeTafsily_Moeen.Attach(acct_Ac_tblAnvaeTafsily_Moeen);
                this.ObjectContext.Acct_Ac_tblAnvaeTafsily_Moeen.DeleteObject(acct_Ac_tblAnvaeTafsily_Moeen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblAyeen' query.
        public IQueryable<Acct_Ac_tblAyeen> GetAcct_Ac_tblAyeen()
        {
            return this.ObjectContext.Acct_Ac_tblAyeen;
        }

        public void InsertAcct_Ac_tblAyeen(Acct_Ac_tblAyeen acct_Ac_tblAyeen)
        {
            if ((acct_Ac_tblAyeen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAyeen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAyeen.AddObject(acct_Ac_tblAyeen);
            }
        }

        public void UpdateAcct_Ac_tblAyeen(Acct_Ac_tblAyeen currentAcct_Ac_tblAyeen)
        {
            this.ObjectContext.Acct_Ac_tblAyeen.AttachAsModified(currentAcct_Ac_tblAyeen, this.ChangeSet.GetOriginal(currentAcct_Ac_tblAyeen));
        }

        public void DeleteAcct_Ac_tblAyeen(Acct_Ac_tblAyeen acct_Ac_tblAyeen)
        {
            if ((acct_Ac_tblAyeen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblAyeen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblAyeen.Attach(acct_Ac_tblAyeen);
                this.ObjectContext.Acct_Ac_tblAyeen.DeleteObject(acct_Ac_tblAyeen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblBab' query.
        public IQueryable<Acct_Ac_tblBab> GetAcct_Ac_tblBab()
        {
            return this.ObjectContext.Acct_Ac_tblBab;
        }

        public void InsertAcct_Ac_tblBab(Acct_Ac_tblBab acct_Ac_tblBab)
        {
            if ((acct_Ac_tblBab.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBab, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBab.AddObject(acct_Ac_tblBab);
            }
        }

        public void UpdateAcct_Ac_tblBab(Acct_Ac_tblBab currentAcct_Ac_tblBab)
        {
            this.ObjectContext.Acct_Ac_tblBab.AttachAsModified(currentAcct_Ac_tblBab, this.ChangeSet.GetOriginal(currentAcct_Ac_tblBab));
        }

        public void DeleteAcct_Ac_tblBab(Acct_Ac_tblBab acct_Ac_tblBab)
        {
            if ((acct_Ac_tblBab.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBab, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBab.Attach(acct_Ac_tblBab);
                this.ObjectContext.Acct_Ac_tblBab.DeleteObject(acct_Ac_tblBab);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblBakhsh' query.
        public IQueryable<Acct_Ac_tblBakhsh> GetAcct_Ac_tblBakhsh()
        {
            return this.ObjectContext.Acct_Ac_tblBakhsh;
        }

        public void InsertAcct_Ac_tblBakhsh(Acct_Ac_tblBakhsh acct_Ac_tblBakhsh)
        {
            if ((acct_Ac_tblBakhsh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBakhsh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBakhsh.AddObject(acct_Ac_tblBakhsh);
            }
        }

        public void UpdateAcct_Ac_tblBakhsh(Acct_Ac_tblBakhsh currentAcct_Ac_tblBakhsh)
        {
            this.ObjectContext.Acct_Ac_tblBakhsh.AttachAsModified(currentAcct_Ac_tblBakhsh, this.ChangeSet.GetOriginal(currentAcct_Ac_tblBakhsh));
        }

        public void DeleteAcct_Ac_tblBakhsh(Acct_Ac_tblBakhsh acct_Ac_tblBakhsh)
        {
            if ((acct_Ac_tblBakhsh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBakhsh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBakhsh.Attach(acct_Ac_tblBakhsh);
                this.ObjectContext.Acct_Ac_tblBakhsh.DeleteObject(acct_Ac_tblBakhsh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblBakhshname' query.
        public IQueryable<Acct_Ac_tblBakhshname> GetAcct_Ac_tblBakhshname()
        {
            return this.ObjectContext.Acct_Ac_tblBakhshname;
        }

        public void InsertAcct_Ac_tblBakhshname(Acct_Ac_tblBakhshname acct_Ac_tblBakhshname)
        {
            if ((acct_Ac_tblBakhshname.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBakhshname, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBakhshname.AddObject(acct_Ac_tblBakhshname);
            }
        }

        public void UpdateAcct_Ac_tblBakhshname(Acct_Ac_tblBakhshname currentAcct_Ac_tblBakhshname)
        {
            this.ObjectContext.Acct_Ac_tblBakhshname.AttachAsModified(currentAcct_Ac_tblBakhshname, this.ChangeSet.GetOriginal(currentAcct_Ac_tblBakhshname));
        }

        public void DeleteAcct_Ac_tblBakhshname(Acct_Ac_tblBakhshname acct_Ac_tblBakhshname)
        {
            if ((acct_Ac_tblBakhshname.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBakhshname, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBakhshname.Attach(acct_Ac_tblBakhshname);
                this.ObjectContext.Acct_Ac_tblBakhshname.DeleteObject(acct_Ac_tblBakhshname);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblBankS' query.
        public IQueryable<Acct_Ac_tblBankS> GetAcct_Ac_tblBankS()
        {
            return this.ObjectContext.Acct_Ac_tblBankS;
        }

        public void InsertAcct_Ac_tblBankS(Acct_Ac_tblBankS acct_Ac_tblBankS)
        {
            if ((acct_Ac_tblBankS.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBankS, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBankS.AddObject(acct_Ac_tblBankS);
            }
        }

        public void UpdateAcct_Ac_tblBankS(Acct_Ac_tblBankS currentAcct_Ac_tblBankS)
        {
            this.ObjectContext.Acct_Ac_tblBankS.AttachAsModified(currentAcct_Ac_tblBankS, this.ChangeSet.GetOriginal(currentAcct_Ac_tblBankS));
        }

        public void DeleteAcct_Ac_tblBankS(Acct_Ac_tblBankS acct_Ac_tblBankS)
        {
            if ((acct_Ac_tblBankS.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblBankS, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblBankS.Attach(acct_Ac_tblBankS);
                this.ObjectContext.Acct_Ac_tblBankS.DeleteObject(acct_Ac_tblBankS);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblControlCheck' query.
        public IQueryable<Acct_Ac_tblControlCheck> GetAcct_Ac_tblControlCheck()
        {
            return this.ObjectContext.Acct_Ac_tblControlCheck;
        }

        public void InsertAcct_Ac_tblControlCheck(Acct_Ac_tblControlCheck acct_Ac_tblControlCheck)
        {
            if ((acct_Ac_tblControlCheck.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblControlCheck, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblControlCheck.AddObject(acct_Ac_tblControlCheck);
            }
        }

        public void UpdateAcct_Ac_tblControlCheck(Acct_Ac_tblControlCheck currentAcct_Ac_tblControlCheck)
        {
            this.ObjectContext.Acct_Ac_tblControlCheck.AttachAsModified(currentAcct_Ac_tblControlCheck, this.ChangeSet.GetOriginal(currentAcct_Ac_tblControlCheck));
        }

        public void DeleteAcct_Ac_tblControlCheck(Acct_Ac_tblControlCheck acct_Ac_tblControlCheck)
        {
            if ((acct_Ac_tblControlCheck.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblControlCheck, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblControlCheck.Attach(acct_Ac_tblControlCheck);
                this.ObjectContext.Acct_Ac_tblControlCheck.DeleteObject(acct_Ac_tblControlCheck);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblControlHesab' query.
        public IQueryable<Acct_Ac_tblControlHesab> GetAcct_Ac_tblControlHesab()
        {
            return this.ObjectContext.Acct_Ac_tblControlHesab;
        }

        public void InsertAcct_Ac_tblControlHesab(Acct_Ac_tblControlHesab acct_Ac_tblControlHesab)
        {
            if ((acct_Ac_tblControlHesab.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblControlHesab, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblControlHesab.AddObject(acct_Ac_tblControlHesab);
            }
        }

        public void UpdateAcct_Ac_tblControlHesab(Acct_Ac_tblControlHesab currentAcct_Ac_tblControlHesab)
        {
            this.ObjectContext.Acct_Ac_tblControlHesab.AttachAsModified(currentAcct_Ac_tblControlHesab, this.ChangeSet.GetOriginal(currentAcct_Ac_tblControlHesab));
        }

        public void DeleteAcct_Ac_tblControlHesab(Acct_Ac_tblControlHesab acct_Ac_tblControlHesab)
        {
            if ((acct_Ac_tblControlHesab.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblControlHesab, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblControlHesab.Attach(acct_Ac_tblControlHesab);
                this.ObjectContext.Acct_Ac_tblControlHesab.DeleteObject(acct_Ac_tblControlHesab);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblDarkhastCheck' query.
        public IQueryable<Acct_Ac_tblDarkhastCheck> GetAcct_Ac_tblDarkhastCheck()
        {
            return this.ObjectContext.Acct_Ac_tblDarkhastCheck;
        }

        public void InsertAcct_Ac_tblDarkhastCheck(Acct_Ac_tblDarkhastCheck acct_Ac_tblDarkhastCheck)
        {
            if ((acct_Ac_tblDarkhastCheck.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDarkhastCheck, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDarkhastCheck.AddObject(acct_Ac_tblDarkhastCheck);
            }
        }

        public void UpdateAcct_Ac_tblDarkhastCheck(Acct_Ac_tblDarkhastCheck currentAcct_Ac_tblDarkhastCheck)
        {
            this.ObjectContext.Acct_Ac_tblDarkhastCheck.AttachAsModified(currentAcct_Ac_tblDarkhastCheck, this.ChangeSet.GetOriginal(currentAcct_Ac_tblDarkhastCheck));
        }

        public void DeleteAcct_Ac_tblDarkhastCheck(Acct_Ac_tblDarkhastCheck acct_Ac_tblDarkhastCheck)
        {
            if ((acct_Ac_tblDarkhastCheck.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDarkhastCheck, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDarkhastCheck.Attach(acct_Ac_tblDarkhastCheck);
                this.ObjectContext.Acct_Ac_tblDarkhastCheck.DeleteObject(acct_Ac_tblDarkhastCheck);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblDarkhastCheckSatr' query.
        public IQueryable<Acct_Ac_tblDarkhastCheckSatr> GetAcct_Ac_tblDarkhastCheckSatr()
        {
            return this.ObjectContext.Acct_Ac_tblDarkhastCheckSatr;
        }

        public void InsertAcct_Ac_tblDarkhastCheckSatr(Acct_Ac_tblDarkhastCheckSatr acct_Ac_tblDarkhastCheckSatr)
        {
            if ((acct_Ac_tblDarkhastCheckSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDarkhastCheckSatr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDarkhastCheckSatr.AddObject(acct_Ac_tblDarkhastCheckSatr);
            }
        }

        public void UpdateAcct_Ac_tblDarkhastCheckSatr(Acct_Ac_tblDarkhastCheckSatr currentAcct_Ac_tblDarkhastCheckSatr)
        {
            this.ObjectContext.Acct_Ac_tblDarkhastCheckSatr.AttachAsModified(currentAcct_Ac_tblDarkhastCheckSatr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblDarkhastCheckSatr));
        }

        public void DeleteAcct_Ac_tblDarkhastCheckSatr(Acct_Ac_tblDarkhastCheckSatr acct_Ac_tblDarkhastCheckSatr)
        {
            if ((acct_Ac_tblDarkhastCheckSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDarkhastCheckSatr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDarkhastCheckSatr.Attach(acct_Ac_tblDarkhastCheckSatr);
                this.ObjectContext.Acct_Ac_tblDarkhastCheckSatr.DeleteObject(acct_Ac_tblDarkhastCheckSatr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblDorehMaly' query.
        public IQueryable<Acct_Ac_tblDorehMaly> GetAcct_Ac_tblDorehMaly()
        {
            return this.ObjectContext.Acct_Ac_tblDorehMaly;
        }

        public void InsertAcct_Ac_tblDorehMaly(Acct_Ac_tblDorehMaly acct_Ac_tblDorehMaly)
        {
            if ((acct_Ac_tblDorehMaly.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDorehMaly, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDorehMaly.AddObject(acct_Ac_tblDorehMaly);
            }
        }

        public void UpdateAcct_Ac_tblDorehMaly(Acct_Ac_tblDorehMaly currentAcct_Ac_tblDorehMaly)
        {
            this.ObjectContext.Acct_Ac_tblDorehMaly.AttachAsModified(currentAcct_Ac_tblDorehMaly, this.ChangeSet.GetOriginal(currentAcct_Ac_tblDorehMaly));
        }

        public void DeleteAcct_Ac_tblDorehMaly(Acct_Ac_tblDorehMaly acct_Ac_tblDorehMaly)
        {
            if ((acct_Ac_tblDorehMaly.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDorehMaly, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDorehMaly.Attach(acct_Ac_tblDorehMaly);
                this.ObjectContext.Acct_Ac_tblDorehMaly.DeleteObject(acct_Ac_tblDorehMaly);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblDorehYekParcheh' query.
        public IQueryable<Acct_Ac_tblDorehYekParcheh> GetAcct_Ac_tblDorehYekParcheh()
        {
            return this.ObjectContext.Acct_Ac_tblDorehYekParcheh;
        }

        public void InsertAcct_Ac_tblDorehYekParcheh(Acct_Ac_tblDorehYekParcheh acct_Ac_tblDorehYekParcheh)
        {
            if ((acct_Ac_tblDorehYekParcheh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDorehYekParcheh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDorehYekParcheh.AddObject(acct_Ac_tblDorehYekParcheh);
            }
        }

        public void UpdateAcct_Ac_tblDorehYekParcheh(Acct_Ac_tblDorehYekParcheh currentAcct_Ac_tblDorehYekParcheh)
        {
            this.ObjectContext.Acct_Ac_tblDorehYekParcheh.AttachAsModified(currentAcct_Ac_tblDorehYekParcheh, this.ChangeSet.GetOriginal(currentAcct_Ac_tblDorehYekParcheh));
        }

        public void DeleteAcct_Ac_tblDorehYekParcheh(Acct_Ac_tblDorehYekParcheh acct_Ac_tblDorehYekParcheh)
        {
            if ((acct_Ac_tblDorehYekParcheh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblDorehYekParcheh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblDorehYekParcheh.Attach(acct_Ac_tblDorehYekParcheh);
                this.ObjectContext.Acct_Ac_tblDorehYekParcheh.DeleteObject(acct_Ac_tblDorehYekParcheh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblEmzaKonnande' query.
        public IQueryable<Acct_Ac_tblEmzaKonnande> GetAcct_Ac_tblEmzaKonnande()
        {
            return this.ObjectContext.Acct_Ac_tblEmzaKonnande;
        }

        public void InsertAcct_Ac_tblEmzaKonnande(Acct_Ac_tblEmzaKonnande acct_Ac_tblEmzaKonnande)
        {
            if ((acct_Ac_tblEmzaKonnande.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblEmzaKonnande, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblEmzaKonnande.AddObject(acct_Ac_tblEmzaKonnande);
            }
        }

        public void UpdateAcct_Ac_tblEmzaKonnande(Acct_Ac_tblEmzaKonnande currentAcct_Ac_tblEmzaKonnande)
        {
            this.ObjectContext.Acct_Ac_tblEmzaKonnande.AttachAsModified(currentAcct_Ac_tblEmzaKonnande, this.ChangeSet.GetOriginal(currentAcct_Ac_tblEmzaKonnande));
        }

        public void DeleteAcct_Ac_tblEmzaKonnande(Acct_Ac_tblEmzaKonnande acct_Ac_tblEmzaKonnande)
        {
            if ((acct_Ac_tblEmzaKonnande.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblEmzaKonnande, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblEmzaKonnande.Attach(acct_Ac_tblEmzaKonnande);
                this.ObjectContext.Acct_Ac_tblEmzaKonnande.DeleteObject(acct_Ac_tblEmzaKonnande);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblFasl' query.
        public IQueryable<Acct_Ac_tblFasl> GetAcct_Ac_tblFasl()
        {
            return this.ObjectContext.Acct_Ac_tblFasl;
        }

        public void InsertAcct_Ac_tblFasl(Acct_Ac_tblFasl acct_Ac_tblFasl)
        {
            if ((acct_Ac_tblFasl.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblFasl, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblFasl.AddObject(acct_Ac_tblFasl);
            }
        }

        public void UpdateAcct_Ac_tblFasl(Acct_Ac_tblFasl currentAcct_Ac_tblFasl)
        {
            this.ObjectContext.Acct_Ac_tblFasl.AttachAsModified(currentAcct_Ac_tblFasl, this.ChangeSet.GetOriginal(currentAcct_Ac_tblFasl));
        }

        public void DeleteAcct_Ac_tblFasl(Acct_Ac_tblFasl acct_Ac_tblFasl)
        {
            if ((acct_Ac_tblFasl.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblFasl, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblFasl.Attach(acct_Ac_tblFasl);
                this.ObjectContext.Acct_Ac_tblFasl.DeleteObject(acct_Ac_tblFasl);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblGeneralCoding' query.
        public IQueryable<Acct_Ac_tblGeneralCoding> GetAcct_Ac_tblGeneralCoding()
        {
            return this.ObjectContext.Acct_Ac_tblGeneralCoding;
        }

        public void InsertAcct_Ac_tblGeneralCoding(Acct_Ac_tblGeneralCoding acct_Ac_tblGeneralCoding)
        {
            if ((acct_Ac_tblGeneralCoding.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGeneralCoding, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGeneralCoding.AddObject(acct_Ac_tblGeneralCoding);
            }
        }

        public void UpdateAcct_Ac_tblGeneralCoding(Acct_Ac_tblGeneralCoding currentAcct_Ac_tblGeneralCoding)
        {
            this.ObjectContext.Acct_Ac_tblGeneralCoding.AttachAsModified(currentAcct_Ac_tblGeneralCoding, this.ChangeSet.GetOriginal(currentAcct_Ac_tblGeneralCoding));
        }

        public void DeleteAcct_Ac_tblGeneralCoding(Acct_Ac_tblGeneralCoding acct_Ac_tblGeneralCoding)
        {
            if ((acct_Ac_tblGeneralCoding.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGeneralCoding, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGeneralCoding.Attach(acct_Ac_tblGeneralCoding);
                this.ObjectContext.Acct_Ac_tblGeneralCoding.DeleteObject(acct_Ac_tblGeneralCoding);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblGoroohMarakez' query.
        public IQueryable<Acct_Ac_tblGoroohMarakez> GetAcct_Ac_tblGoroohMarakez()
        {
            return this.ObjectContext.Acct_Ac_tblGoroohMarakez;
        }

        public void InsertAcct_Ac_tblGoroohMarakez(Acct_Ac_tblGoroohMarakez acct_Ac_tblGoroohMarakez)
        {
            if ((acct_Ac_tblGoroohMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGoroohMarakez, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGoroohMarakez.AddObject(acct_Ac_tblGoroohMarakez);
            }
        }

        public void UpdateAcct_Ac_tblGoroohMarakez(Acct_Ac_tblGoroohMarakez currentAcct_Ac_tblGoroohMarakez)
        {
            this.ObjectContext.Acct_Ac_tblGoroohMarakez.AttachAsModified(currentAcct_Ac_tblGoroohMarakez, this.ChangeSet.GetOriginal(currentAcct_Ac_tblGoroohMarakez));
        }

        public void DeleteAcct_Ac_tblGoroohMarakez(Acct_Ac_tblGoroohMarakez acct_Ac_tblGoroohMarakez)
        {
            if ((acct_Ac_tblGoroohMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGoroohMarakez, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGoroohMarakez.Attach(acct_Ac_tblGoroohMarakez);
                this.ObjectContext.Acct_Ac_tblGoroohMarakez.DeleteObject(acct_Ac_tblGoroohMarakez);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblGoroohProject' query.
        public IQueryable<Acct_Ac_tblGoroohProject> GetAcct_Ac_tblGoroohProject()
        {
            return this.ObjectContext.Acct_Ac_tblGoroohProject;
        }

        public void InsertAcct_Ac_tblGoroohProject(Acct_Ac_tblGoroohProject acct_Ac_tblGoroohProject)
        {
            if ((acct_Ac_tblGoroohProject.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGoroohProject, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGoroohProject.AddObject(acct_Ac_tblGoroohProject);
            }
        }

        public void UpdateAcct_Ac_tblGoroohProject(Acct_Ac_tblGoroohProject currentAcct_Ac_tblGoroohProject)
        {
            this.ObjectContext.Acct_Ac_tblGoroohProject.AttachAsModified(currentAcct_Ac_tblGoroohProject, this.ChangeSet.GetOriginal(currentAcct_Ac_tblGoroohProject));
        }

        public void DeleteAcct_Ac_tblGoroohProject(Acct_Ac_tblGoroohProject acct_Ac_tblGoroohProject)
        {
            if ((acct_Ac_tblGoroohProject.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGoroohProject, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGoroohProject.Attach(acct_Ac_tblGoroohProject);
                this.ObjectContext.Acct_Ac_tblGoroohProject.DeleteObject(acct_Ac_tblGoroohProject);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblGoroohTafsily' query.
        public IQueryable<Acct_Ac_tblGoroohTafsily> GetAcct_Ac_tblGoroohTafsily()
        {
            return this.ObjectContext.Acct_Ac_tblGoroohTafsily;
        }

        public void InsertAcct_Ac_tblGoroohTafsily(Acct_Ac_tblGoroohTafsily acct_Ac_tblGoroohTafsily)
        {
            if ((acct_Ac_tblGoroohTafsily.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGoroohTafsily, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGoroohTafsily.AddObject(acct_Ac_tblGoroohTafsily);
            }
        }

        public void UpdateAcct_Ac_tblGoroohTafsily(Acct_Ac_tblGoroohTafsily currentAcct_Ac_tblGoroohTafsily)
        {
            this.ObjectContext.Acct_Ac_tblGoroohTafsily.AttachAsModified(currentAcct_Ac_tblGoroohTafsily, this.ChangeSet.GetOriginal(currentAcct_Ac_tblGoroohTafsily));
        }

        public void DeleteAcct_Ac_tblGoroohTafsily(Acct_Ac_tblGoroohTafsily acct_Ac_tblGoroohTafsily)
        {
            if ((acct_Ac_tblGoroohTafsily.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGoroohTafsily, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGoroohTafsily.Attach(acct_Ac_tblGoroohTafsily);
                this.ObjectContext.Acct_Ac_tblGoroohTafsily.DeleteObject(acct_Ac_tblGoroohTafsily);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblGozareshNesbatHayMalySatr' query.
        public IQueryable<Acct_Ac_tblGozareshNesbatHayMalySatr> GetAcct_Ac_tblGozareshNesbatHayMalySatr()
        {
            return this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalySatr;
        }

        public void InsertAcct_Ac_tblGozareshNesbatHayMalySatr(Acct_Ac_tblGozareshNesbatHayMalySatr acct_Ac_tblGozareshNesbatHayMalySatr)
        {
            if ((acct_Ac_tblGozareshNesbatHayMalySatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGozareshNesbatHayMalySatr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalySatr.AddObject(acct_Ac_tblGozareshNesbatHayMalySatr);
            }
        }

        public void UpdateAcct_Ac_tblGozareshNesbatHayMalySatr(Acct_Ac_tblGozareshNesbatHayMalySatr currentAcct_Ac_tblGozareshNesbatHayMalySatr)
        {
            this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalySatr.AttachAsModified(currentAcct_Ac_tblGozareshNesbatHayMalySatr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblGozareshNesbatHayMalySatr));
        }

        public void DeleteAcct_Ac_tblGozareshNesbatHayMalySatr(Acct_Ac_tblGozareshNesbatHayMalySatr acct_Ac_tblGozareshNesbatHayMalySatr)
        {
            if ((acct_Ac_tblGozareshNesbatHayMalySatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGozareshNesbatHayMalySatr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalySatr.Attach(acct_Ac_tblGozareshNesbatHayMalySatr);
                this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalySatr.DeleteObject(acct_Ac_tblGozareshNesbatHayMalySatr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblGozareshNesbatHayMalyTitr' query.
        public IQueryable<Acct_Ac_tblGozareshNesbatHayMalyTitr> GetAcct_Ac_tblGozareshNesbatHayMalyTitr()
        {
            return this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalyTitr;
        }

        public void InsertAcct_Ac_tblGozareshNesbatHayMalyTitr(Acct_Ac_tblGozareshNesbatHayMalyTitr acct_Ac_tblGozareshNesbatHayMalyTitr)
        {
            if ((acct_Ac_tblGozareshNesbatHayMalyTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGozareshNesbatHayMalyTitr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalyTitr.AddObject(acct_Ac_tblGozareshNesbatHayMalyTitr);
            }
        }

        public void UpdateAcct_Ac_tblGozareshNesbatHayMalyTitr(Acct_Ac_tblGozareshNesbatHayMalyTitr currentAcct_Ac_tblGozareshNesbatHayMalyTitr)
        {
            this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalyTitr.AttachAsModified(currentAcct_Ac_tblGozareshNesbatHayMalyTitr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblGozareshNesbatHayMalyTitr));
        }

        public void DeleteAcct_Ac_tblGozareshNesbatHayMalyTitr(Acct_Ac_tblGozareshNesbatHayMalyTitr acct_Ac_tblGozareshNesbatHayMalyTitr)
        {
            if ((acct_Ac_tblGozareshNesbatHayMalyTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblGozareshNesbatHayMalyTitr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalyTitr.Attach(acct_Ac_tblGozareshNesbatHayMalyTitr);
                this.ObjectContext.Acct_Ac_tblGozareshNesbatHayMalyTitr.DeleteObject(acct_Ac_tblGozareshNesbatHayMalyTitr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHadEtebar' query.
        public IQueryable<Acct_Ac_tblHadEtebar> GetAcct_Ac_tblHadEtebar()
        {
            return this.ObjectContext.Acct_Ac_tblHadEtebar;
        }

        public void InsertAcct_Ac_tblHadEtebar(Acct_Ac_tblHadEtebar acct_Ac_tblHadEtebar)
        {
            if ((acct_Ac_tblHadEtebar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHadEtebar, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHadEtebar.AddObject(acct_Ac_tblHadEtebar);
            }
        }

        public void UpdateAcct_Ac_tblHadEtebar(Acct_Ac_tblHadEtebar currentAcct_Ac_tblHadEtebar)
        {
            this.ObjectContext.Acct_Ac_tblHadEtebar.AttachAsModified(currentAcct_Ac_tblHadEtebar, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHadEtebar));
        }

        public void DeleteAcct_Ac_tblHadEtebar(Acct_Ac_tblHadEtebar acct_Ac_tblHadEtebar)
        {
            if ((acct_Ac_tblHadEtebar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHadEtebar, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHadEtebar.Attach(acct_Ac_tblHadEtebar);
                this.ObjectContext.Acct_Ac_tblHadEtebar.DeleteObject(acct_Ac_tblHadEtebar);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabGoroh' query.
        public IQueryable<Acct_Ac_tblHesabGoroh> GetAcct_Ac_tblHesabGoroh()
        {
            return this.ObjectContext.Acct_Ac_tblHesabGoroh;
        }

        public void InsertAcct_Ac_tblHesabGoroh(Acct_Ac_tblHesabGoroh acct_Ac_tblHesabGoroh)
        {
            if ((acct_Ac_tblHesabGoroh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabGoroh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabGoroh.AddObject(acct_Ac_tblHesabGoroh);
            }
        }

        public void UpdateAcct_Ac_tblHesabGoroh(Acct_Ac_tblHesabGoroh currentAcct_Ac_tblHesabGoroh)
        {
            this.ObjectContext.Acct_Ac_tblHesabGoroh.AttachAsModified(currentAcct_Ac_tblHesabGoroh, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabGoroh));
        }

        public void DeleteAcct_Ac_tblHesabGoroh(Acct_Ac_tblHesabGoroh acct_Ac_tblHesabGoroh)
        {
            if ((acct_Ac_tblHesabGoroh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabGoroh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabGoroh.Attach(acct_Ac_tblHesabGoroh);
                this.ObjectContext.Acct_Ac_tblHesabGoroh.DeleteObject(acct_Ac_tblHesabGoroh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabha' query.
        public IQueryable<Acct_Ac_tblHesabha> GetAcct_Ac_tblHesabha()
        {
            return this.ObjectContext.Acct_Ac_tblHesabha;
        }

        public void InsertAcct_Ac_tblHesabha(Acct_Ac_tblHesabha acct_Ac_tblHesabha)
        {
            if ((acct_Ac_tblHesabha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabha, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabha.AddObject(acct_Ac_tblHesabha);
            }
        }

        public void UpdateAcct_Ac_tblHesabha(Acct_Ac_tblHesabha currentAcct_Ac_tblHesabha)
        {
            this.ObjectContext.Acct_Ac_tblHesabha.AttachAsModified(currentAcct_Ac_tblHesabha, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabha));
        }

        public void DeleteAcct_Ac_tblHesabha(Acct_Ac_tblHesabha acct_Ac_tblHesabha)
        {
            if ((acct_Ac_tblHesabha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabha, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabha.Attach(acct_Ac_tblHesabha);
                this.ObjectContext.Acct_Ac_tblHesabha.DeleteObject(acct_Ac_tblHesabha);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabKol' query.
        public IQueryable<Acct_Ac_tblHesabKol> GetAcct_Ac_tblHesabKol()
        {
            return this.ObjectContext.Acct_Ac_tblHesabKol;
        }

        public void InsertAcct_Ac_tblHesabKol(Acct_Ac_tblHesabKol acct_Ac_tblHesabKol)
        {
            if ((acct_Ac_tblHesabKol.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabKol, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabKol.AddObject(acct_Ac_tblHesabKol);
            }
        }

        public void UpdateAcct_Ac_tblHesabKol(Acct_Ac_tblHesabKol currentAcct_Ac_tblHesabKol)
        {
            this.ObjectContext.Acct_Ac_tblHesabKol.AttachAsModified(currentAcct_Ac_tblHesabKol, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabKol));
        }

        public void DeleteAcct_Ac_tblHesabKol(Acct_Ac_tblHesabKol acct_Ac_tblHesabKol)
        {
            if ((acct_Ac_tblHesabKol.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabKol, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabKol.Attach(acct_Ac_tblHesabKol);
                this.ObjectContext.Acct_Ac_tblHesabKol.DeleteObject(acct_Ac_tblHesabKol);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabMarakez' query.
        public IQueryable<Acct_Ac_tblHesabMarakez> GetAcct_Ac_tblHesabMarakez()
        {
            return this.ObjectContext.Acct_Ac_tblHesabMarakez;
        }

        public void InsertAcct_Ac_tblHesabMarakez(Acct_Ac_tblHesabMarakez acct_Ac_tblHesabMarakez)
        {
            if ((acct_Ac_tblHesabMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabMarakez, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabMarakez.AddObject(acct_Ac_tblHesabMarakez);
            }
        }

        public void UpdateAcct_Ac_tblHesabMarakez(Acct_Ac_tblHesabMarakez currentAcct_Ac_tblHesabMarakez)
        {
            this.ObjectContext.Acct_Ac_tblHesabMarakez.AttachAsModified(currentAcct_Ac_tblHesabMarakez, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabMarakez));
        }

        public void DeleteAcct_Ac_tblHesabMarakez(Acct_Ac_tblHesabMarakez acct_Ac_tblHesabMarakez)
        {
            if ((acct_Ac_tblHesabMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabMarakez, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabMarakez.Attach(acct_Ac_tblHesabMarakez);
                this.ObjectContext.Acct_Ac_tblHesabMarakez.DeleteObject(acct_Ac_tblHesabMarakez);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabMoeen' query.
        public IQueryable<Acct_Ac_tblHesabMoeen> GetAcct_Ac_tblHesabMoeen()
        {
            return this.ObjectContext.Acct_Ac_tblHesabMoeen;
        }

        public void InsertAcct_Ac_tblHesabMoeen(Acct_Ac_tblHesabMoeen acct_Ac_tblHesabMoeen)
        {
            if ((acct_Ac_tblHesabMoeen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabMoeen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabMoeen.AddObject(acct_Ac_tblHesabMoeen);
            }
        }

        public void UpdateAcct_Ac_tblHesabMoeen(Acct_Ac_tblHesabMoeen currentAcct_Ac_tblHesabMoeen)
        {
            this.ObjectContext.Acct_Ac_tblHesabMoeen.AttachAsModified(currentAcct_Ac_tblHesabMoeen, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabMoeen));
        }

        public void DeleteAcct_Ac_tblHesabMoeen(Acct_Ac_tblHesabMoeen acct_Ac_tblHesabMoeen)
        {
            if ((acct_Ac_tblHesabMoeen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabMoeen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabMoeen.Attach(acct_Ac_tblHesabMoeen);
                this.ObjectContext.Acct_Ac_tblHesabMoeen.DeleteObject(acct_Ac_tblHesabMoeen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabRizMarakez' query.
        public IQueryable<Acct_Ac_tblHesabRizMarakez> GetAcct_Ac_tblHesabRizMarakez()
        {
            return this.ObjectContext.Acct_Ac_tblHesabRizMarakez;
        }

        public void InsertAcct_Ac_tblHesabRizMarakez(Acct_Ac_tblHesabRizMarakez acct_Ac_tblHesabRizMarakez)
        {
            if ((acct_Ac_tblHesabRizMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabRizMarakez, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabRizMarakez.AddObject(acct_Ac_tblHesabRizMarakez);
            }
        }

        public void UpdateAcct_Ac_tblHesabRizMarakez(Acct_Ac_tblHesabRizMarakez currentAcct_Ac_tblHesabRizMarakez)
        {
            this.ObjectContext.Acct_Ac_tblHesabRizMarakez.AttachAsModified(currentAcct_Ac_tblHesabRizMarakez, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabRizMarakez));
        }

        public void DeleteAcct_Ac_tblHesabRizMarakez(Acct_Ac_tblHesabRizMarakez acct_Ac_tblHesabRizMarakez)
        {
            if ((acct_Ac_tblHesabRizMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabRizMarakez, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabRizMarakez.Attach(acct_Ac_tblHesabRizMarakez);
                this.ObjectContext.Acct_Ac_tblHesabRizMarakez.DeleteObject(acct_Ac_tblHesabRizMarakez);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabTafsily' query.
        public IQueryable<Acct_Ac_tblHesabTafsily> GetAcct_Ac_tblHesabTafsily()
        {
            return this.ObjectContext.Acct_Ac_tblHesabTafsily;
        }

        public void InsertAcct_Ac_tblHesabTafsily(Acct_Ac_tblHesabTafsily acct_Ac_tblHesabTafsily)
        {
            if ((acct_Ac_tblHesabTafsily.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabTafsily, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabTafsily.AddObject(acct_Ac_tblHesabTafsily);
            }
        }

        public void UpdateAcct_Ac_tblHesabTafsily(Acct_Ac_tblHesabTafsily currentAcct_Ac_tblHesabTafsily)
        {
            this.ObjectContext.Acct_Ac_tblHesabTafsily.AttachAsModified(currentAcct_Ac_tblHesabTafsily, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabTafsily));
        }

        public void DeleteAcct_Ac_tblHesabTafsily(Acct_Ac_tblHesabTafsily acct_Ac_tblHesabTafsily)
        {
            if ((acct_Ac_tblHesabTafsily.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabTafsily, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabTafsily.Attach(acct_Ac_tblHesabTafsily);
                this.ObjectContext.Acct_Ac_tblHesabTafsily.DeleteObject(acct_Ac_tblHesabTafsily);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblHesabTafsilyMarakez' query.
        public IQueryable<Acct_Ac_tblHesabTafsilyMarakez> GetAcct_Ac_tblHesabTafsilyMarakez()
        {
            return this.ObjectContext.Acct_Ac_tblHesabTafsilyMarakez;
        }

        public void InsertAcct_Ac_tblHesabTafsilyMarakez(Acct_Ac_tblHesabTafsilyMarakez acct_Ac_tblHesabTafsilyMarakez)
        {
            if ((acct_Ac_tblHesabTafsilyMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabTafsilyMarakez, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabTafsilyMarakez.AddObject(acct_Ac_tblHesabTafsilyMarakez);
            }
        }

        public void UpdateAcct_Ac_tblHesabTafsilyMarakez(Acct_Ac_tblHesabTafsilyMarakez currentAcct_Ac_tblHesabTafsilyMarakez)
        {
            this.ObjectContext.Acct_Ac_tblHesabTafsilyMarakez.AttachAsModified(currentAcct_Ac_tblHesabTafsilyMarakez, this.ChangeSet.GetOriginal(currentAcct_Ac_tblHesabTafsilyMarakez));
        }

        public void DeleteAcct_Ac_tblHesabTafsilyMarakez(Acct_Ac_tblHesabTafsilyMarakez acct_Ac_tblHesabTafsilyMarakez)
        {
            if ((acct_Ac_tblHesabTafsilyMarakez.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblHesabTafsilyMarakez, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblHesabTafsilyMarakez.Attach(acct_Ac_tblHesabTafsilyMarakez);
                this.ObjectContext.Acct_Ac_tblHesabTafsilyMarakez.DeleteObject(acct_Ac_tblHesabTafsilyMarakez);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblJournal' query.
        public IQueryable<Acct_Ac_tblJournal> GetAcct_Ac_tblJournal()
        {
            return this.ObjectContext.Acct_Ac_tblJournal;
        }

        public void InsertAcct_Ac_tblJournal(Acct_Ac_tblJournal acct_Ac_tblJournal)
        {
            if ((acct_Ac_tblJournal.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournal, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournal.AddObject(acct_Ac_tblJournal);
            }
        }

        public void UpdateAcct_Ac_tblJournal(Acct_Ac_tblJournal currentAcct_Ac_tblJournal)
        {
            this.ObjectContext.Acct_Ac_tblJournal.AttachAsModified(currentAcct_Ac_tblJournal, this.ChangeSet.GetOriginal(currentAcct_Ac_tblJournal));
        }

        public void DeleteAcct_Ac_tblJournal(Acct_Ac_tblJournal acct_Ac_tblJournal)
        {
            if ((acct_Ac_tblJournal.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournal, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournal.Attach(acct_Ac_tblJournal);
                this.ObjectContext.Acct_Ac_tblJournal.DeleteObject(acct_Ac_tblJournal);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblJournalAttachments' query.
        public IQueryable<Acct_Ac_tblJournalAttachments> GetAcct_Ac_tblJournalAttachments()
        {
            return this.ObjectContext.Acct_Ac_tblJournalAttachments;
        }

        public void InsertAcct_Ac_tblJournalAttachments(Acct_Ac_tblJournalAttachments acct_Ac_tblJournalAttachments)
        {
            if ((acct_Ac_tblJournalAttachments.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournalAttachments, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournalAttachments.AddObject(acct_Ac_tblJournalAttachments);
            }
        }

        public void UpdateAcct_Ac_tblJournalAttachments(Acct_Ac_tblJournalAttachments currentAcct_Ac_tblJournalAttachments)
        {
            this.ObjectContext.Acct_Ac_tblJournalAttachments.AttachAsModified(currentAcct_Ac_tblJournalAttachments, this.ChangeSet.GetOriginal(currentAcct_Ac_tblJournalAttachments));
        }

        public void DeleteAcct_Ac_tblJournalAttachments(Acct_Ac_tblJournalAttachments acct_Ac_tblJournalAttachments)
        {
            if ((acct_Ac_tblJournalAttachments.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournalAttachments, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournalAttachments.Attach(acct_Ac_tblJournalAttachments);
                this.ObjectContext.Acct_Ac_tblJournalAttachments.DeleteObject(acct_Ac_tblJournalAttachments);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblJournalDeleted' query.
        public IQueryable<Acct_Ac_tblJournalDeleted> GetAcct_Ac_tblJournalDeleted()
        {
            return this.ObjectContext.Acct_Ac_tblJournalDeleted;
        }

        public void InsertAcct_Ac_tblJournalDeleted(Acct_Ac_tblJournalDeleted acct_Ac_tblJournalDeleted)
        {
            if ((acct_Ac_tblJournalDeleted.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournalDeleted, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournalDeleted.AddObject(acct_Ac_tblJournalDeleted);
            }
        }

        public void UpdateAcct_Ac_tblJournalDeleted(Acct_Ac_tblJournalDeleted currentAcct_Ac_tblJournalDeleted)
        {
            this.ObjectContext.Acct_Ac_tblJournalDeleted.AttachAsModified(currentAcct_Ac_tblJournalDeleted, this.ChangeSet.GetOriginal(currentAcct_Ac_tblJournalDeleted));
        }

        public void DeleteAcct_Ac_tblJournalDeleted(Acct_Ac_tblJournalDeleted acct_Ac_tblJournalDeleted)
        {
            if ((acct_Ac_tblJournalDeleted.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournalDeleted, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournalDeleted.Attach(acct_Ac_tblJournalDeleted);
                this.ObjectContext.Acct_Ac_tblJournalDeleted.DeleteObject(acct_Ac_tblJournalDeleted);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblJournalLine' query.
        public IQueryable<Acct_Ac_tblJournalLine> GetAcct_Ac_tblJournalLine()
        {
            return this.ObjectContext.Acct_Ac_tblJournalLine;
        }

        public void InsertAcct_Ac_tblJournalLine(Acct_Ac_tblJournalLine acct_Ac_tblJournalLine)
        {
            if ((acct_Ac_tblJournalLine.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournalLine, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournalLine.AddObject(acct_Ac_tblJournalLine);
            }
        }

        public void UpdateAcct_Ac_tblJournalLine(Acct_Ac_tblJournalLine currentAcct_Ac_tblJournalLine)
        {
            this.ObjectContext.Acct_Ac_tblJournalLine.AttachAsModified(currentAcct_Ac_tblJournalLine, this.ChangeSet.GetOriginal(currentAcct_Ac_tblJournalLine));
        }

        public void DeleteAcct_Ac_tblJournalLine(Acct_Ac_tblJournalLine acct_Ac_tblJournalLine)
        {
            if ((acct_Ac_tblJournalLine.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblJournalLine, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblJournalLine.Attach(acct_Ac_tblJournalLine);
                this.ObjectContext.Acct_Ac_tblJournalLine.DeleteObject(acct_Ac_tblJournalLine);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblKarbarg' query.
        public IQueryable<Acct_Ac_tblKarbarg> GetAcct_Ac_tblKarbarg()
        {
            return this.ObjectContext.Acct_Ac_tblKarbarg;
        }

        public void InsertAcct_Ac_tblKarbarg(Acct_Ac_tblKarbarg acct_Ac_tblKarbarg)
        {
            if ((acct_Ac_tblKarbarg.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblKarbarg, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblKarbarg.AddObject(acct_Ac_tblKarbarg);
            }
        }

        public void UpdateAcct_Ac_tblKarbarg(Acct_Ac_tblKarbarg currentAcct_Ac_tblKarbarg)
        {
            this.ObjectContext.Acct_Ac_tblKarbarg.AttachAsModified(currentAcct_Ac_tblKarbarg, this.ChangeSet.GetOriginal(currentAcct_Ac_tblKarbarg));
        }

        public void DeleteAcct_Ac_tblKarbarg(Acct_Ac_tblKarbarg acct_Ac_tblKarbarg)
        {
            if ((acct_Ac_tblKarbarg.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblKarbarg, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblKarbarg.Attach(acct_Ac_tblKarbarg);
                this.ObjectContext.Acct_Ac_tblKarbarg.DeleteObject(acct_Ac_tblKarbarg);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblKetab' query.
        public IQueryable<Acct_Ac_tblKetab> GetAcct_Ac_tblKetab()
        {
            return this.ObjectContext.Acct_Ac_tblKetab;
        }

        public void InsertAcct_Ac_tblKetab(Acct_Ac_tblKetab acct_Ac_tblKetab)
        {
            if ((acct_Ac_tblKetab.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblKetab, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblKetab.AddObject(acct_Ac_tblKetab);
            }
        }

        public void UpdateAcct_Ac_tblKetab(Acct_Ac_tblKetab currentAcct_Ac_tblKetab)
        {
            this.ObjectContext.Acct_Ac_tblKetab.AttachAsModified(currentAcct_Ac_tblKetab, this.ChangeSet.GetOriginal(currentAcct_Ac_tblKetab));
        }

        public void DeleteAcct_Ac_tblKetab(Acct_Ac_tblKetab acct_Ac_tblKetab)
        {
            if ((acct_Ac_tblKetab.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblKetab, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblKetab.Attach(acct_Ac_tblKetab);
                this.ObjectContext.Acct_Ac_tblKetab.DeleteObject(acct_Ac_tblKetab);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblKhoroj' query.
        public IQueryable<Acct_Ac_tblKhoroj> GetAcct_Ac_tblKhoroj()
        {
            return this.ObjectContext.Acct_Ac_tblKhoroj;
        }

        public void InsertAcct_Ac_tblKhoroj(Acct_Ac_tblKhoroj acct_Ac_tblKhoroj)
        {
            if ((acct_Ac_tblKhoroj.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblKhoroj, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblKhoroj.AddObject(acct_Ac_tblKhoroj);
            }
        }

        public void UpdateAcct_Ac_tblKhoroj(Acct_Ac_tblKhoroj currentAcct_Ac_tblKhoroj)
        {
            this.ObjectContext.Acct_Ac_tblKhoroj.AttachAsModified(currentAcct_Ac_tblKhoroj, this.ChangeSet.GetOriginal(currentAcct_Ac_tblKhoroj));
        }

        public void DeleteAcct_Ac_tblKhoroj(Acct_Ac_tblKhoroj acct_Ac_tblKhoroj)
        {
            if ((acct_Ac_tblKhoroj.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblKhoroj, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblKhoroj.Attach(acct_Ac_tblKhoroj);
                this.ObjectContext.Acct_Ac_tblKhoroj.DeleteObject(acct_Ac_tblKhoroj);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblLoginSanad' query.
        public IQueryable<Acct_Ac_tblLoginSanad> GetAcct_Ac_tblLoginSanad()
        {
            return this.ObjectContext.Acct_Ac_tblLoginSanad;
        }

        public void InsertAcct_Ac_tblLoginSanad(Acct_Ac_tblLoginSanad acct_Ac_tblLoginSanad)
        {
            if ((acct_Ac_tblLoginSanad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblLoginSanad, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblLoginSanad.AddObject(acct_Ac_tblLoginSanad);
            }
        }

        public void UpdateAcct_Ac_tblLoginSanad(Acct_Ac_tblLoginSanad currentAcct_Ac_tblLoginSanad)
        {
            this.ObjectContext.Acct_Ac_tblLoginSanad.AttachAsModified(currentAcct_Ac_tblLoginSanad, this.ChangeSet.GetOriginal(currentAcct_Ac_tblLoginSanad));
        }

        public void DeleteAcct_Ac_tblLoginSanad(Acct_Ac_tblLoginSanad acct_Ac_tblLoginSanad)
        {
            if ((acct_Ac_tblLoginSanad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblLoginSanad, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblLoginSanad.Attach(acct_Ac_tblLoginSanad);
                this.ObjectContext.Acct_Ac_tblLoginSanad.DeleteObject(acct_Ac_tblLoginSanad);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblManabMasref' query.
        public IQueryable<Acct_Ac_tblManabMasref> GetAcct_Ac_tblManabMasref()
        {
            return this.ObjectContext.Acct_Ac_tblManabMasref;
        }

        public void InsertAcct_Ac_tblManabMasref(Acct_Ac_tblManabMasref acct_Ac_tblManabMasref)
        {
            if ((acct_Ac_tblManabMasref.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblManabMasref, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblManabMasref.AddObject(acct_Ac_tblManabMasref);
            }
        }

        public void UpdateAcct_Ac_tblManabMasref(Acct_Ac_tblManabMasref currentAcct_Ac_tblManabMasref)
        {
            this.ObjectContext.Acct_Ac_tblManabMasref.AttachAsModified(currentAcct_Ac_tblManabMasref, this.ChangeSet.GetOriginal(currentAcct_Ac_tblManabMasref));
        }

        public void DeleteAcct_Ac_tblManabMasref(Acct_Ac_tblManabMasref acct_Ac_tblManabMasref)
        {
            if ((acct_Ac_tblManabMasref.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblManabMasref, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblManabMasref.Attach(acct_Ac_tblManabMasref);
                this.ObjectContext.Acct_Ac_tblManabMasref.DeleteObject(acct_Ac_tblManabMasref);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblMandeHesabSatr' query.
        public IQueryable<Acct_Ac_tblMandeHesabSatr> GetAcct_Ac_tblMandeHesabSatr()
        {
            return this.ObjectContext.Acct_Ac_tblMandeHesabSatr;
        }

        public void InsertAcct_Ac_tblMandeHesabSatr(Acct_Ac_tblMandeHesabSatr acct_Ac_tblMandeHesabSatr)
        {
            if ((acct_Ac_tblMandeHesabSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMandeHesabSatr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMandeHesabSatr.AddObject(acct_Ac_tblMandeHesabSatr);
            }
        }

        public void UpdateAcct_Ac_tblMandeHesabSatr(Acct_Ac_tblMandeHesabSatr currentAcct_Ac_tblMandeHesabSatr)
        {
            this.ObjectContext.Acct_Ac_tblMandeHesabSatr.AttachAsModified(currentAcct_Ac_tblMandeHesabSatr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblMandeHesabSatr));
        }

        public void DeleteAcct_Ac_tblMandeHesabSatr(Acct_Ac_tblMandeHesabSatr acct_Ac_tblMandeHesabSatr)
        {
            if ((acct_Ac_tblMandeHesabSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMandeHesabSatr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMandeHesabSatr.Attach(acct_Ac_tblMandeHesabSatr);
                this.ObjectContext.Acct_Ac_tblMandeHesabSatr.DeleteObject(acct_Ac_tblMandeHesabSatr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblMoghayertBanky' query.
        public IQueryable<Acct_Ac_tblMoghayertBanky> GetAcct_Ac_tblMoghayertBanky()
        {
            return this.ObjectContext.Acct_Ac_tblMoghayertBanky;
        }

        public void InsertAcct_Ac_tblMoghayertBanky(Acct_Ac_tblMoghayertBanky acct_Ac_tblMoghayertBanky)
        {
            if ((acct_Ac_tblMoghayertBanky.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMoghayertBanky, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMoghayertBanky.AddObject(acct_Ac_tblMoghayertBanky);
            }
        }

        public void UpdateAcct_Ac_tblMoghayertBanky(Acct_Ac_tblMoghayertBanky currentAcct_Ac_tblMoghayertBanky)
        {
            this.ObjectContext.Acct_Ac_tblMoghayertBanky.AttachAsModified(currentAcct_Ac_tblMoghayertBanky, this.ChangeSet.GetOriginal(currentAcct_Ac_tblMoghayertBanky));
        }

        public void DeleteAcct_Ac_tblMoghayertBanky(Acct_Ac_tblMoghayertBanky acct_Ac_tblMoghayertBanky)
        {
            if ((acct_Ac_tblMoghayertBanky.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMoghayertBanky, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMoghayertBanky.Attach(acct_Ac_tblMoghayertBanky);
                this.ObjectContext.Acct_Ac_tblMoghayertBanky.DeleteObject(acct_Ac_tblMoghayertBanky);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblMohasebehNesbatHayMaly' query.
        public IQueryable<Acct_Ac_tblMohasebehNesbatHayMaly> GetAcct_Ac_tblMohasebehNesbatHayMaly()
        {
            return this.ObjectContext.Acct_Ac_tblMohasebehNesbatHayMaly;
        }

        public void InsertAcct_Ac_tblMohasebehNesbatHayMaly(Acct_Ac_tblMohasebehNesbatHayMaly acct_Ac_tblMohasebehNesbatHayMaly)
        {
            if ((acct_Ac_tblMohasebehNesbatHayMaly.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMohasebehNesbatHayMaly, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMohasebehNesbatHayMaly.AddObject(acct_Ac_tblMohasebehNesbatHayMaly);
            }
        }

        public void UpdateAcct_Ac_tblMohasebehNesbatHayMaly(Acct_Ac_tblMohasebehNesbatHayMaly currentAcct_Ac_tblMohasebehNesbatHayMaly)
        {
            this.ObjectContext.Acct_Ac_tblMohasebehNesbatHayMaly.AttachAsModified(currentAcct_Ac_tblMohasebehNesbatHayMaly, this.ChangeSet.GetOriginal(currentAcct_Ac_tblMohasebehNesbatHayMaly));
        }

        public void DeleteAcct_Ac_tblMohasebehNesbatHayMaly(Acct_Ac_tblMohasebehNesbatHayMaly acct_Ac_tblMohasebehNesbatHayMaly)
        {
            if ((acct_Ac_tblMohasebehNesbatHayMaly.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMohasebehNesbatHayMaly, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMohasebehNesbatHayMaly.Attach(acct_Ac_tblMohasebehNesbatHayMaly);
                this.ObjectContext.Acct_Ac_tblMohasebehNesbatHayMaly.DeleteObject(acct_Ac_tblMohasebehNesbatHayMaly);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblMohasebehSarmayeSatr' query.
        public IQueryable<Acct_Ac_tblMohasebehSarmayeSatr> GetAcct_Ac_tblMohasebehSarmayeSatr()
        {
            return this.ObjectContext.Acct_Ac_tblMohasebehSarmayeSatr;
        }

        public void InsertAcct_Ac_tblMohasebehSarmayeSatr(Acct_Ac_tblMohasebehSarmayeSatr acct_Ac_tblMohasebehSarmayeSatr)
        {
            if ((acct_Ac_tblMohasebehSarmayeSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMohasebehSarmayeSatr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMohasebehSarmayeSatr.AddObject(acct_Ac_tblMohasebehSarmayeSatr);
            }
        }

        public void UpdateAcct_Ac_tblMohasebehSarmayeSatr(Acct_Ac_tblMohasebehSarmayeSatr currentAcct_Ac_tblMohasebehSarmayeSatr)
        {
            this.ObjectContext.Acct_Ac_tblMohasebehSarmayeSatr.AttachAsModified(currentAcct_Ac_tblMohasebehSarmayeSatr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblMohasebehSarmayeSatr));
        }

        public void DeleteAcct_Ac_tblMohasebehSarmayeSatr(Acct_Ac_tblMohasebehSarmayeSatr acct_Ac_tblMohasebehSarmayeSatr)
        {
            if ((acct_Ac_tblMohasebehSarmayeSatr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMohasebehSarmayeSatr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMohasebehSarmayeSatr.Attach(acct_Ac_tblMohasebehSarmayeSatr);
                this.ObjectContext.Acct_Ac_tblMohasebehSarmayeSatr.DeleteObject(acct_Ac_tblMohasebehSarmayeSatr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblMohasebehSarmayeTitr' query.
        public IQueryable<Acct_Ac_tblMohasebehSarmayeTitr> GetAcct_Ac_tblMohasebehSarmayeTitr()
        {
            return this.ObjectContext.Acct_Ac_tblMohasebehSarmayeTitr;
        }

        public void InsertAcct_Ac_tblMohasebehSarmayeTitr(Acct_Ac_tblMohasebehSarmayeTitr acct_Ac_tblMohasebehSarmayeTitr)
        {
            if ((acct_Ac_tblMohasebehSarmayeTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMohasebehSarmayeTitr, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMohasebehSarmayeTitr.AddObject(acct_Ac_tblMohasebehSarmayeTitr);
            }
        }

        public void UpdateAcct_Ac_tblMohasebehSarmayeTitr(Acct_Ac_tblMohasebehSarmayeTitr currentAcct_Ac_tblMohasebehSarmayeTitr)
        {
            this.ObjectContext.Acct_Ac_tblMohasebehSarmayeTitr.AttachAsModified(currentAcct_Ac_tblMohasebehSarmayeTitr, this.ChangeSet.GetOriginal(currentAcct_Ac_tblMohasebehSarmayeTitr));
        }

        public void DeleteAcct_Ac_tblMohasebehSarmayeTitr(Acct_Ac_tblMohasebehSarmayeTitr acct_Ac_tblMohasebehSarmayeTitr)
        {
            if ((acct_Ac_tblMohasebehSarmayeTitr.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblMohasebehSarmayeTitr, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblMohasebehSarmayeTitr.Attach(acct_Ac_tblMohasebehSarmayeTitr);
                this.ObjectContext.Acct_Ac_tblMohasebehSarmayeTitr.DeleteObject(acct_Ac_tblMohasebehSarmayeTitr);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblNoePardakht' query.
        public IQueryable<Acct_Ac_tblNoePardakht> GetAcct_Ac_tblNoePardakht()
        {
            return this.ObjectContext.Acct_Ac_tblNoePardakht;
        }

        public void InsertAcct_Ac_tblNoePardakht(Acct_Ac_tblNoePardakht acct_Ac_tblNoePardakht)
        {
            if ((acct_Ac_tblNoePardakht.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblNoePardakht, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblNoePardakht.AddObject(acct_Ac_tblNoePardakht);
            }
        }

        public void UpdateAcct_Ac_tblNoePardakht(Acct_Ac_tblNoePardakht currentAcct_Ac_tblNoePardakht)
        {
            this.ObjectContext.Acct_Ac_tblNoePardakht.AttachAsModified(currentAcct_Ac_tblNoePardakht, this.ChangeSet.GetOriginal(currentAcct_Ac_tblNoePardakht));
        }

        public void DeleteAcct_Ac_tblNoePardakht(Acct_Ac_tblNoePardakht acct_Ac_tblNoePardakht)
        {
            if ((acct_Ac_tblNoePardakht.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblNoePardakht, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblNoePardakht.Attach(acct_Ac_tblNoePardakht);
                this.ObjectContext.Acct_Ac_tblNoePardakht.DeleteObject(acct_Ac_tblNoePardakht);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblPardakhtAghsat' query.
        public IQueryable<Acct_Ac_tblPardakhtAghsat> GetAcct_Ac_tblPardakhtAghsat()
        {
            return this.ObjectContext.Acct_Ac_tblPardakhtAghsat;
        }

        public void InsertAcct_Ac_tblPardakhtAghsat(Acct_Ac_tblPardakhtAghsat acct_Ac_tblPardakhtAghsat)
        {
            if ((acct_Ac_tblPardakhtAghsat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblPardakhtAghsat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblPardakhtAghsat.AddObject(acct_Ac_tblPardakhtAghsat);
            }
        }

        public void UpdateAcct_Ac_tblPardakhtAghsat(Acct_Ac_tblPardakhtAghsat currentAcct_Ac_tblPardakhtAghsat)
        {
            this.ObjectContext.Acct_Ac_tblPardakhtAghsat.AttachAsModified(currentAcct_Ac_tblPardakhtAghsat, this.ChangeSet.GetOriginal(currentAcct_Ac_tblPardakhtAghsat));
        }

        public void DeleteAcct_Ac_tblPardakhtAghsat(Acct_Ac_tblPardakhtAghsat acct_Ac_tblPardakhtAghsat)
        {
            if ((acct_Ac_tblPardakhtAghsat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblPardakhtAghsat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblPardakhtAghsat.Attach(acct_Ac_tblPardakhtAghsat);
                this.ObjectContext.Acct_Ac_tblPardakhtAghsat.DeleteObject(acct_Ac_tblPardakhtAghsat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblPardakhtAghsatBeRiz' query.
        public IQueryable<Acct_Ac_tblPardakhtAghsatBeRiz> GetAcct_Ac_tblPardakhtAghsatBeRiz()
        {
            return this.ObjectContext.Acct_Ac_tblPardakhtAghsatBeRiz;
        }

        public void InsertAcct_Ac_tblPardakhtAghsatBeRiz(Acct_Ac_tblPardakhtAghsatBeRiz acct_Ac_tblPardakhtAghsatBeRiz)
        {
            if ((acct_Ac_tblPardakhtAghsatBeRiz.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblPardakhtAghsatBeRiz, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblPardakhtAghsatBeRiz.AddObject(acct_Ac_tblPardakhtAghsatBeRiz);
            }
        }

        public void UpdateAcct_Ac_tblPardakhtAghsatBeRiz(Acct_Ac_tblPardakhtAghsatBeRiz currentAcct_Ac_tblPardakhtAghsatBeRiz)
        {
            this.ObjectContext.Acct_Ac_tblPardakhtAghsatBeRiz.AttachAsModified(currentAcct_Ac_tblPardakhtAghsatBeRiz, this.ChangeSet.GetOriginal(currentAcct_Ac_tblPardakhtAghsatBeRiz));
        }

        public void DeleteAcct_Ac_tblPardakhtAghsatBeRiz(Acct_Ac_tblPardakhtAghsatBeRiz acct_Ac_tblPardakhtAghsatBeRiz)
        {
            if ((acct_Ac_tblPardakhtAghsatBeRiz.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblPardakhtAghsatBeRiz, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblPardakhtAghsatBeRiz.Attach(acct_Ac_tblPardakhtAghsatBeRiz);
                this.ObjectContext.Acct_Ac_tblPardakhtAghsatBeRiz.DeleteObject(acct_Ac_tblPardakhtAghsatBeRiz);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblProject' query.
        public IQueryable<Acct_Ac_tblProject> GetAcct_Ac_tblProject()
        {
            return this.ObjectContext.Acct_Ac_tblProject;
        }

        public void InsertAcct_Ac_tblProject(Acct_Ac_tblProject acct_Ac_tblProject)
        {
            if ((acct_Ac_tblProject.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblProject, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblProject.AddObject(acct_Ac_tblProject);
            }
        }

        public void UpdateAcct_Ac_tblProject(Acct_Ac_tblProject currentAcct_Ac_tblProject)
        {
            this.ObjectContext.Acct_Ac_tblProject.AttachAsModified(currentAcct_Ac_tblProject, this.ChangeSet.GetOriginal(currentAcct_Ac_tblProject));
        }

        public void DeleteAcct_Ac_tblProject(Acct_Ac_tblProject acct_Ac_tblProject)
        {
            if ((acct_Ac_tblProject.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblProject, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblProject.Attach(acct_Ac_tblProject);
                this.ObjectContext.Acct_Ac_tblProject.DeleteObject(acct_Ac_tblProject);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblSandoghha' query.
        public IQueryable<Acct_Ac_tblSandoghha> GetAcct_Ac_tblSandoghha()
        {
            return this.ObjectContext.Acct_Ac_tblSandoghha;
        }

        public void InsertAcct_Ac_tblSandoghha(Acct_Ac_tblSandoghha acct_Ac_tblSandoghha)
        {
            if ((acct_Ac_tblSandoghha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSandoghha, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSandoghha.AddObject(acct_Ac_tblSandoghha);
            }
        }

        public void UpdateAcct_Ac_tblSandoghha(Acct_Ac_tblSandoghha currentAcct_Ac_tblSandoghha)
        {
            this.ObjectContext.Acct_Ac_tblSandoghha.AttachAsModified(currentAcct_Ac_tblSandoghha, this.ChangeSet.GetOriginal(currentAcct_Ac_tblSandoghha));
        }

        public void DeleteAcct_Ac_tblSandoghha(Acct_Ac_tblSandoghha acct_Ac_tblSandoghha)
        {
            if ((acct_Ac_tblSandoghha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSandoghha, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSandoghha.Attach(acct_Ac_tblSandoghha);
                this.ObjectContext.Acct_Ac_tblSandoghha.DeleteObject(acct_Ac_tblSandoghha);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblSecurityTable' query.
        public IQueryable<Acct_Ac_tblSecurityTable> GetAcct_Ac_tblSecurityTable()
        {
            return this.ObjectContext.Acct_Ac_tblSecurityTable;
        }

        public void InsertAcct_Ac_tblSecurityTable(Acct_Ac_tblSecurityTable acct_Ac_tblSecurityTable)
        {
            if ((acct_Ac_tblSecurityTable.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSecurityTable, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSecurityTable.AddObject(acct_Ac_tblSecurityTable);
            }
        }

        public void UpdateAcct_Ac_tblSecurityTable(Acct_Ac_tblSecurityTable currentAcct_Ac_tblSecurityTable)
        {
            this.ObjectContext.Acct_Ac_tblSecurityTable.AttachAsModified(currentAcct_Ac_tblSecurityTable, this.ChangeSet.GetOriginal(currentAcct_Ac_tblSecurityTable));
        }

        public void DeleteAcct_Ac_tblSecurityTable(Acct_Ac_tblSecurityTable acct_Ac_tblSecurityTable)
        {
            if ((acct_Ac_tblSecurityTable.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSecurityTable, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSecurityTable.Attach(acct_Ac_tblSecurityTable);
                this.ObjectContext.Acct_Ac_tblSecurityTable.DeleteObject(acct_Ac_tblSecurityTable);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblSerialChek' query.
        public IQueryable<Acct_Ac_tblSerialChek> GetAcct_Ac_tblSerialChek()
        {
            return this.ObjectContext.Acct_Ac_tblSerialChek;
        }

        public void InsertAcct_Ac_tblSerialChek(Acct_Ac_tblSerialChek acct_Ac_tblSerialChek)
        {
            if ((acct_Ac_tblSerialChek.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSerialChek, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSerialChek.AddObject(acct_Ac_tblSerialChek);
            }
        }

        public void UpdateAcct_Ac_tblSerialChek(Acct_Ac_tblSerialChek currentAcct_Ac_tblSerialChek)
        {
            this.ObjectContext.Acct_Ac_tblSerialChek.AttachAsModified(currentAcct_Ac_tblSerialChek, this.ChangeSet.GetOriginal(currentAcct_Ac_tblSerialChek));
        }

        public void DeleteAcct_Ac_tblSerialChek(Acct_Ac_tblSerialChek acct_Ac_tblSerialChek)
        {
            if ((acct_Ac_tblSerialChek.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSerialChek, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSerialChek.Attach(acct_Ac_tblSerialChek);
                this.ObjectContext.Acct_Ac_tblSerialChek.DeleteObject(acct_Ac_tblSerialChek);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblSerialSandogh' query.
        public IQueryable<Acct_Ac_tblSerialSandogh> GetAcct_Ac_tblSerialSandogh()
        {
            return this.ObjectContext.Acct_Ac_tblSerialSandogh;
        }

        public void InsertAcct_Ac_tblSerialSandogh(Acct_Ac_tblSerialSandogh acct_Ac_tblSerialSandogh)
        {
            if ((acct_Ac_tblSerialSandogh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSerialSandogh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSerialSandogh.AddObject(acct_Ac_tblSerialSandogh);
            }
        }

        public void UpdateAcct_Ac_tblSerialSandogh(Acct_Ac_tblSerialSandogh currentAcct_Ac_tblSerialSandogh)
        {
            this.ObjectContext.Acct_Ac_tblSerialSandogh.AttachAsModified(currentAcct_Ac_tblSerialSandogh, this.ChangeSet.GetOriginal(currentAcct_Ac_tblSerialSandogh));
        }

        public void DeleteAcct_Ac_tblSerialSandogh(Acct_Ac_tblSerialSandogh acct_Ac_tblSerialSandogh)
        {
            if ((acct_Ac_tblSerialSandogh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSerialSandogh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSerialSandogh.Attach(acct_Ac_tblSerialSandogh);
                this.ObjectContext.Acct_Ac_tblSerialSandogh.DeleteObject(acct_Ac_tblSerialSandogh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblSharhKolySanad' query.
        public IQueryable<Acct_Ac_tblSharhKolySanad> GetAcct_Ac_tblSharhKolySanad()
        {
            return this.ObjectContext.Acct_Ac_tblSharhKolySanad;
        }

        public void InsertAcct_Ac_tblSharhKolySanad(Acct_Ac_tblSharhKolySanad acct_Ac_tblSharhKolySanad)
        {
            if ((acct_Ac_tblSharhKolySanad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSharhKolySanad, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSharhKolySanad.AddObject(acct_Ac_tblSharhKolySanad);
            }
        }

        public void UpdateAcct_Ac_tblSharhKolySanad(Acct_Ac_tblSharhKolySanad currentAcct_Ac_tblSharhKolySanad)
        {
            this.ObjectContext.Acct_Ac_tblSharhKolySanad.AttachAsModified(currentAcct_Ac_tblSharhKolySanad, this.ChangeSet.GetOriginal(currentAcct_Ac_tblSharhKolySanad));
        }

        public void DeleteAcct_Ac_tblSharhKolySanad(Acct_Ac_tblSharhKolySanad acct_Ac_tblSharhKolySanad)
        {
            if ((acct_Ac_tblSharhKolySanad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSharhKolySanad, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSharhKolySanad.Attach(acct_Ac_tblSharhKolySanad);
                this.ObjectContext.Acct_Ac_tblSharhKolySanad.DeleteObject(acct_Ac_tblSharhKolySanad);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblSherkatha' query.
        public IQueryable<Acct_Ac_tblSherkatha> GetAcct_Ac_tblSherkatha()
        {
            return this.ObjectContext.Acct_Ac_tblSherkatha;
        }

        public void InsertAcct_Ac_tblSherkatha(Acct_Ac_tblSherkatha acct_Ac_tblSherkatha)
        {
            if ((acct_Ac_tblSherkatha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSherkatha, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSherkatha.AddObject(acct_Ac_tblSherkatha);
            }
        }

        public void UpdateAcct_Ac_tblSherkatha(Acct_Ac_tblSherkatha currentAcct_Ac_tblSherkatha)
        {
            this.ObjectContext.Acct_Ac_tblSherkatha.AttachAsModified(currentAcct_Ac_tblSherkatha, this.ChangeSet.GetOriginal(currentAcct_Ac_tblSherkatha));
        }

        public void DeleteAcct_Ac_tblSherkatha(Acct_Ac_tblSherkatha acct_Ac_tblSherkatha)
        {
            if ((acct_Ac_tblSherkatha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblSherkatha, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblSherkatha.Attach(acct_Ac_tblSherkatha);
                this.ObjectContext.Acct_Ac_tblSherkatha.DeleteObject(acct_Ac_tblSherkatha);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblShoabBank' query.
        public IQueryable<Acct_Ac_tblShoabBank> GetAcct_Ac_tblShoabBank()
        {
            return this.ObjectContext.Acct_Ac_tblShoabBank;
        }

        public void InsertAcct_Ac_tblShoabBank(Acct_Ac_tblShoabBank acct_Ac_tblShoabBank)
        {
            if ((acct_Ac_tblShoabBank.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblShoabBank, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblShoabBank.AddObject(acct_Ac_tblShoabBank);
            }
        }

        public void UpdateAcct_Ac_tblShoabBank(Acct_Ac_tblShoabBank currentAcct_Ac_tblShoabBank)
        {
            this.ObjectContext.Acct_Ac_tblShoabBank.AttachAsModified(currentAcct_Ac_tblShoabBank, this.ChangeSet.GetOriginal(currentAcct_Ac_tblShoabBank));
        }

        public void DeleteAcct_Ac_tblShoabBank(Acct_Ac_tblShoabBank acct_Ac_tblShoabBank)
        {
            if ((acct_Ac_tblShoabBank.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblShoabBank, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblShoabBank.Attach(acct_Ac_tblShoabBank);
                this.ObjectContext.Acct_Ac_tblShoabBank.DeleteObject(acct_Ac_tblShoabBank);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblTafsily' query.
        public IQueryable<Acct_Ac_tblTafsily> GetAcct_Ac_tblTafsily()
        {
            return this.ObjectContext.Acct_Ac_tblTafsily;
        }

        public void InsertAcct_Ac_tblTafsily(Acct_Ac_tblTafsily acct_Ac_tblTafsily)
        {
            if ((acct_Ac_tblTafsily.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblTafsily, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblTafsily.AddObject(acct_Ac_tblTafsily);
            }
        }

        public void UpdateAcct_Ac_tblTafsily(Acct_Ac_tblTafsily currentAcct_Ac_tblTafsily)
        {
            this.ObjectContext.Acct_Ac_tblTafsily.AttachAsModified(currentAcct_Ac_tblTafsily, this.ChangeSet.GetOriginal(currentAcct_Ac_tblTafsily));
        }

        public void DeleteAcct_Ac_tblTafsily(Acct_Ac_tblTafsily acct_Ac_tblTafsily)
        {
            if ((acct_Ac_tblTafsily.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblTafsily, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblTafsily.Attach(acct_Ac_tblTafsily);
                this.ObjectContext.Acct_Ac_tblTafsily.DeleteObject(acct_Ac_tblTafsily);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblTaghirat' query.
        public IQueryable<Acct_Ac_tblTaghirat> GetAcct_Ac_tblTaghirat()
        {
            return this.ObjectContext.Acct_Ac_tblTaghirat;
        }

        public void InsertAcct_Ac_tblTaghirat(Acct_Ac_tblTaghirat acct_Ac_tblTaghirat)
        {
            if ((acct_Ac_tblTaghirat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblTaghirat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblTaghirat.AddObject(acct_Ac_tblTaghirat);
            }
        }

        public void UpdateAcct_Ac_tblTaghirat(Acct_Ac_tblTaghirat currentAcct_Ac_tblTaghirat)
        {
            this.ObjectContext.Acct_Ac_tblTaghirat.AttachAsModified(currentAcct_Ac_tblTaghirat, this.ChangeSet.GetOriginal(currentAcct_Ac_tblTaghirat));
        }

        public void DeleteAcct_Ac_tblTaghirat(Acct_Ac_tblTaghirat acct_Ac_tblTaghirat)
        {
            if ((acct_Ac_tblTaghirat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblTaghirat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblTaghirat.Attach(acct_Ac_tblTaghirat);
                this.ObjectContext.Acct_Ac_tblTaghirat.DeleteObject(acct_Ac_tblTaghirat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblTashilat' query.
        public IQueryable<Acct_Ac_tblTashilat> GetAcct_Ac_tblTashilat()
        {
            return this.ObjectContext.Acct_Ac_tblTashilat;
        }

        public void InsertAcct_Ac_tblTashilat(Acct_Ac_tblTashilat acct_Ac_tblTashilat)
        {
            if ((acct_Ac_tblTashilat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblTashilat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblTashilat.AddObject(acct_Ac_tblTashilat);
            }
        }

        public void UpdateAcct_Ac_tblTashilat(Acct_Ac_tblTashilat currentAcct_Ac_tblTashilat)
        {
            this.ObjectContext.Acct_Ac_tblTashilat.AttachAsModified(currentAcct_Ac_tblTashilat, this.ChangeSet.GetOriginal(currentAcct_Ac_tblTashilat));
        }

        public void DeleteAcct_Ac_tblTashilat(Acct_Ac_tblTashilat acct_Ac_tblTashilat)
        {
            if ((acct_Ac_tblTashilat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblTashilat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblTashilat.Attach(acct_Ac_tblTashilat);
                this.ObjectContext.Acct_Ac_tblTashilat.DeleteObject(acct_Ac_tblTashilat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblUsers' query.
        public IQueryable<Acct_Ac_tblUsers> GetAcct_Ac_tblUsers()
        {
            return this.ObjectContext.Acct_Ac_tblUsers;
        }

        public void InsertAcct_Ac_tblUsers(Acct_Ac_tblUsers acct_Ac_tblUsers)
        {
            if ((acct_Ac_tblUsers.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblUsers, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblUsers.AddObject(acct_Ac_tblUsers);
            }
        }

        public void UpdateAcct_Ac_tblUsers(Acct_Ac_tblUsers currentAcct_Ac_tblUsers)
        {
            this.ObjectContext.Acct_Ac_tblUsers.AttachAsModified(currentAcct_Ac_tblUsers, this.ChangeSet.GetOriginal(currentAcct_Ac_tblUsers));
        }

        public void DeleteAcct_Ac_tblUsers(Acct_Ac_tblUsers acct_Ac_tblUsers)
        {
            if ((acct_Ac_tblUsers.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblUsers, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblUsers.Attach(acct_Ac_tblUsers);
                this.ObjectContext.Acct_Ac_tblUsers.DeleteObject(acct_Ac_tblUsers);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblUsers_Sherkat' query.
        public IQueryable<Acct_Ac_tblUsers_Sherkat> GetAcct_Ac_tblUsers_Sherkat()
        {
            return this.ObjectContext.Acct_Ac_tblUsers_Sherkat;
        }

        public void InsertAcct_Ac_tblUsers_Sherkat(Acct_Ac_tblUsers_Sherkat acct_Ac_tblUsers_Sherkat)
        {
            if ((acct_Ac_tblUsers_Sherkat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblUsers_Sherkat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblUsers_Sherkat.AddObject(acct_Ac_tblUsers_Sherkat);
            }
        }

        public void UpdateAcct_Ac_tblUsers_Sherkat(Acct_Ac_tblUsers_Sherkat currentAcct_Ac_tblUsers_Sherkat)
        {
            this.ObjectContext.Acct_Ac_tblUsers_Sherkat.AttachAsModified(currentAcct_Ac_tblUsers_Sherkat, this.ChangeSet.GetOriginal(currentAcct_Ac_tblUsers_Sherkat));
        }

        public void DeleteAcct_Ac_tblUsers_Sherkat(Acct_Ac_tblUsers_Sherkat acct_Ac_tblUsers_Sherkat)
        {
            if ((acct_Ac_tblUsers_Sherkat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblUsers_Sherkat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblUsers_Sherkat.Attach(acct_Ac_tblUsers_Sherkat);
                this.ObjectContext.Acct_Ac_tblUsers_Sherkat.DeleteObject(acct_Ac_tblUsers_Sherkat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Acct_Ac_tblVasighe' query.
        public IQueryable<Acct_Ac_tblVasighe> GetAcct_Ac_tblVasighe()
        {
            return this.ObjectContext.Acct_Ac_tblVasighe;
        }

        public void InsertAcct_Ac_tblVasighe(Acct_Ac_tblVasighe acct_Ac_tblVasighe)
        {
            if ((acct_Ac_tblVasighe.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblVasighe, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblVasighe.AddObject(acct_Ac_tblVasighe);
            }
        }

        public void UpdateAcct_Ac_tblVasighe(Acct_Ac_tblVasighe currentAcct_Ac_tblVasighe)
        {
            this.ObjectContext.Acct_Ac_tblVasighe.AttachAsModified(currentAcct_Ac_tblVasighe, this.ChangeSet.GetOriginal(currentAcct_Ac_tblVasighe));
        }

        public void DeleteAcct_Ac_tblVasighe(Acct_Ac_tblVasighe acct_Ac_tblVasighe)
        {
            if ((acct_Ac_tblVasighe.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(acct_Ac_tblVasighe, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Acct_Ac_tblVasighe.Attach(acct_Ac_tblVasighe);
                this.ObjectContext.Acct_Ac_tblVasighe.DeleteObject(acct_Ac_tblVasighe);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AD_Client' query.
        public IQueryable<AD_Client> GetAD_Client()
        {
            return this.ObjectContext.AD_Client;
        }

        public void InsertAD_Client(AD_Client aD_Client)
        {
            if ((aD_Client.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Client, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AD_Client.AddObject(aD_Client);
            }
        }

        public void UpdateAD_Client(AD_Client currentAD_Client)
        {
            this.ObjectContext.AD_Client.AttachAsModified(currentAD_Client, this.ChangeSet.GetOriginal(currentAD_Client));
        }

        public void DeleteAD_Client(AD_Client aD_Client)
        {
            if ((aD_Client.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Client, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AD_Client.Attach(aD_Client);
                this.ObjectContext.AD_Client.DeleteObject(aD_Client);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AD_GeneralItems' query.
        //public IQueryable<AD_GeneralItems> GetAD_GeneralItems()
        //{
        //    return this.ObjectContext.AD_GeneralItems;
        //}

        public void InsertAD_GeneralItems(AD_GeneralItems aD_GeneralItems)
        {
            if ((aD_GeneralItems.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_GeneralItems, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AD_GeneralItems.AddObject(aD_GeneralItems);
            }
        }

        public void UpdateAD_GeneralItems(AD_GeneralItems currentAD_GeneralItems)
        {
            this.ObjectContext.AD_GeneralItems.AttachAsModified(currentAD_GeneralItems, this.ChangeSet.GetOriginal(currentAD_GeneralItems));
        }

        public void DeleteAD_GeneralItems(AD_GeneralItems aD_GeneralItems)
        {
            if ((aD_GeneralItems.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_GeneralItems, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AD_GeneralItems.Attach(aD_GeneralItems);
                this.ObjectContext.AD_GeneralItems.DeleteObject(aD_GeneralItems);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AD_Organization' query.
        public IQueryable<AD_Organization> GetAD_Organization()
        {
            return this.ObjectContext.AD_Organization;
        }

        public void InsertAD_Organization(AD_Organization aD_Organization)
        {
            if ((aD_Organization.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Organization, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AD_Organization.AddObject(aD_Organization);
            }
        }

        public void UpdateAD_Organization(AD_Organization currentAD_Organization)
        {
            this.ObjectContext.AD_Organization.AttachAsModified(currentAD_Organization, this.ChangeSet.GetOriginal(currentAD_Organization));
        }

        public void DeleteAD_Organization(AD_Organization aD_Organization)
        {
            if ((aD_Organization.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Organization, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AD_Organization.Attach(aD_Organization);
                this.ObjectContext.AD_Organization.DeleteObject(aD_Organization);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AD_Role' query.
        public IQueryable<AD_Role> GetAD_Role()
        {
            return this.ObjectContext.AD_Role;
        }

        public void InsertAD_Role(AD_Role aD_Role)
        {
            if ((aD_Role.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Role, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AD_Role.AddObject(aD_Role);
            }
        }

        public void UpdateAD_Role(AD_Role currentAD_Role)
        {
            this.ObjectContext.AD_Role.AttachAsModified(currentAD_Role, this.ChangeSet.GetOriginal(currentAD_Role));
        }

        public void DeleteAD_Role(AD_Role aD_Role)
        {
            if ((aD_Role.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Role, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AD_Role.Attach(aD_Role);
                this.ObjectContext.AD_Role.DeleteObject(aD_Role);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AD_Subsystem' query.
        public IQueryable<AD_Subsystem> GetAD_Subsystem()
        {
            return this.ObjectContext.AD_Subsystem;
        }

        public void InsertAD_Subsystem(AD_Subsystem aD_Subsystem)
        {
            if ((aD_Subsystem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Subsystem, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AD_Subsystem.AddObject(aD_Subsystem);
            }
        }

        public void UpdateAD_Subsystem(AD_Subsystem currentAD_Subsystem)
        {
            this.ObjectContext.AD_Subsystem.AttachAsModified(currentAD_Subsystem, this.ChangeSet.GetOriginal(currentAD_Subsystem));
        }

        public void DeleteAD_Subsystem(AD_Subsystem aD_Subsystem)
        {
            if ((aD_Subsystem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_Subsystem, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AD_Subsystem.Attach(aD_Subsystem);
                this.ObjectContext.AD_Subsystem.DeleteObject(aD_Subsystem);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'AD_User' query.
        public IQueryable<AD_User> GetAD_User()
        {
            return this.ObjectContext.AD_User;
        }

        public void InsertAD_User(AD_User aD_User)
        {
            if ((aD_User.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_User, EntityState.Added);
            }
            else
            {
                this.ObjectContext.AD_User.AddObject(aD_User);
            }
        }

        public void UpdateAD_User(AD_User currentAD_User)
        {
            this.ObjectContext.AD_User.AttachAsModified(currentAD_User, this.ChangeSet.GetOriginal(currentAD_User));
        }

        public void DeleteAD_User(AD_User aD_User)
        {
            if ((aD_User.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(aD_User, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.AD_User.Attach(aD_User);
                this.ObjectContext.AD_User.DeleteObject(aD_User);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EntityMetaDatas' query.
        public IQueryable<EntityMetaData> GetEntityMetaDatas()
        {
            return this.ObjectContext.EntityMetaDatas;
        }

        public void InsertEntityMetaData(EntityMetaData entityMetaData)
        {
            if ((entityMetaData.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entityMetaData, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EntityMetaDatas.AddObject(entityMetaData);
            }
        }

        public void UpdateEntityMetaData(EntityMetaData currentEntityMetaData)
        {
            this.ObjectContext.EntityMetaDatas.AttachAsModified(currentEntityMetaData, this.ChangeSet.GetOriginal(currentEntityMetaData));
        }

        public void DeleteEntityMetaData(EntityMetaData entityMetaData)
        {
            if ((entityMetaData.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entityMetaData, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EntityMetaDatas.Attach(entityMetaData);
                this.ObjectContext.EntityMetaDatas.DeleteObject(entityMetaData);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EntitySets' query.
        public IQueryable<EntitySet> GetEntitySets()
        {
            return this.ObjectContext.EntitySets;
        }

        public void InsertEntitySet(EntitySet entitySet)
        {
            if ((entitySet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entitySet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EntitySets.AddObject(entitySet);
            }
        }

        public void UpdateEntitySet(EntitySet currentEntitySet)
        {
            this.ObjectContext.EntitySets.AttachAsModified(currentEntitySet, this.ChangeSet.GetOriginal(currentEntitySet));
        }

        public void DeleteEntitySet(EntitySet entitySet)
        {
            if ((entitySet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entitySet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EntitySets.Attach(entitySet);
                this.ObjectContext.EntitySets.DeleteObject(entitySet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'FooterInfoes' query.
        public IQueryable<FooterInfo> GetFooterInfoes()
        {
            return this.ObjectContext.FooterInfoes;
        }

        public void InsertFooterInfo(FooterInfo footerInfo)
        {
            if ((footerInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(footerInfo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.FooterInfoes.AddObject(footerInfo);
            }
        }

        public void UpdateFooterInfo(FooterInfo currentFooterInfo)
        {
            this.ObjectContext.FooterInfoes.AttachAsModified(currentFooterInfo, this.ChangeSet.GetOriginal(currentFooterInfo));
        }

        public void DeleteFooterInfo(FooterInfo footerInfo)
        {
            if ((footerInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(footerInfo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.FooterInfoes.Attach(footerInfo);
                this.ObjectContext.FooterInfoes.DeleteObject(footerInfo);
            }
        }
    }
}


