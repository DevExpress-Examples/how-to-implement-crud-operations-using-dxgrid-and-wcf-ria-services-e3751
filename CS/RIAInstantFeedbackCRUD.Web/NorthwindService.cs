
namespace RIAInstantFeedbackCRUD.Web {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the NorthwindEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class NorthwindService : LinqToEntitiesDomainService<NorthwindEntities> {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Customers' query.
        public IQueryable<Customers> GetCustomers() {
            return this.ObjectContext.Customers;
        }
        public string GetCustomersExtendedData(string extendedDataInfo) {
            return DevExpress.Xpf.Core.ServerMode.ExtendedDataHelper.GetExtendedData(GetCustomers(), extendedDataInfo);
        }
        [Query(IsComposable = false)]
        public Customers GetCustomerByID(string customerID) {
            return this.ObjectContext.Customers.SingleOrDefault(customer => customer.CustomerID == customerID);
        }

        public void InsertCustomers(Customers customers) {
            if((customers.EntityState != EntityState.Detached)) {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(customers, EntityState.Added);
            } else {
                this.ObjectContext.Customers.AddObject(customers);
            }
        }

        public void UpdateCustomers(Customers currentCustomers) {
            this.ObjectContext.Customers.AttachAsModified(currentCustomers, this.ChangeSet.GetOriginal(currentCustomers));
        }

        public void DeleteCustomers(Customers customers) {
            if((customers.EntityState != EntityState.Detached)) {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(customers, EntityState.Deleted);
            } else {
                this.ObjectContext.Customers.Attach(customers);
                this.ObjectContext.Customers.DeleteObject(customers);
            }
        }
    }
}


