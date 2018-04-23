using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using RIAInstantFeedbackCRUD.Web;

namespace RIAInstantFeedbackCRUD {
    public partial class MainPage : UserControl {
        NorthwindContext context;
        Control control;
        Customers newCustomer;
        Customers customerToEdit;
        Dispatcher uiDispatcher;

        public MainPage() {
            InitializeComponent();
            uiDispatcher = grid.Dispatcher;
            context = new NorthwindContext();
            riaInstantSource.DomainContext = context;
        }

        private void Add_Click(object sender, RoutedEventArgs e) {
            newCustomer = CreateNewCustomer();
            EditCustomer(newCustomer, "Add new customer", CloseAddNewCustomerHandler);
        }
        private void Remove_Click(object sender, RoutedEventArgs e) {
            DeleteSelectedCustomer(view.FocusedRowHandle);
        }
        private void Edit_Click(object sender, RoutedEventArgs e) {
            EditSelectedCustomer(view.FocusedRowHandle);
        }
        private void view_RowDoubleClick(object sender, RowDoubleClickEventArgs e) {
            EditSelectedCustomer(e.HitInfo.RowHandle);
        }
        private void view_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) {
            if(e.Key == System.Windows.Input.Key.Delete) {
                DeleteSelectedCustomer(view.FocusedRowHandle);
            }
            if(e.Key == System.Windows.Input.Key.Enter) {
                EditSelectedCustomer(view.FocusedRowHandle);
            }
        }

        string GetCustomerIDByRowHandle(int rowHandle) {
            return (string)grid.GetCellValue(rowHandle, colCustomerID);
        }
        void FindCustomerByIDAndProcess(string customerID, Action<Customers> action) {
            try {
                context.Load<Customers>(context.GetCustomerByIDQuery(customerID), FindCustomerByIDCallback, action);
            } catch(Exception ex) {
                HandleException(ex);
            }
        }
        void FindCustomerByIDCallback(LoadOperation<Customers> loadOperation) {
            if(loadOperation.HasError) {
                if(loadOperation.CanCancel) loadOperation.Cancel();
                HandleException(loadOperation.Error);
                loadOperation.MarkErrorAsHandled();
                return;
            }
            Action<Customers> action = (Action<Customers>)loadOperation.UserState;
            foreach(Customers customer in loadOperation.Entities) {
                try {
                    uiDispatcher.BeginInvoke(() => action(customer));
                } catch(Exception ex) {
                    HandleException(ex);
                }
            }
        }

        Customers CreateNewCustomer() {
            Customers newCustomer = new Customers();
            newCustomer.CustomerID = GenerateCustomerID();
            return newCustomer;
        }
        string GenerateCustomerID() {
            const int IDLength = 5;
            string result = String.Empty;
            Random rnd = new Random();
            for(int i = 0; i < IDLength; i++) {
                result += Convert.ToChar(rnd.Next(65, 90));
            }
            return result;
        }
        void DeleteSelectedCustomer(int rowHandle) {
            if(rowHandle < 0) return;
            if(MessageBox.Show("Do you really want to delete the selected customer?", "Delete Customer", MessageBoxButton.OKCancel) != MessageBoxResult.OK) return;
            FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), customer => { context.Customers.Remove(customer); SaveChandes(); });
        }
        void EditSelectedCustomer(int rowHandle) {
            if(rowHandle < 0) return;
            FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), customer => {
                customerToEdit = customer; EditCustomer(customerToEdit, "Edit customer", CloseEditCustomerHandler);
            });
        }
        void EditCustomer(Customers customer, string windowTitle, EventHandler closedDelegate) {
            control = new ContentControl { Template = (ControlTemplate)Resources["EditRecordTemplate"] };
            control.DataContext = customer;

            DXDialog dialog = new DXDialog(windowTitle, DialogButtons.OkCancel);
            dialog.Content = control;
            dialog.Closed += closedDelegate;
            dialog.ShowDialog();
        }
        void CloseAddNewCustomerHandler(object sender, EventArgs e) {
            if(((DXDialog)sender).DialogResult == DialogResult.OK) {
                context.Customers.Add(newCustomer);
                SaveChandes();
            }
            control = null;
            newCustomer = null;
        }
        void CloseEditCustomerHandler(object sender, EventArgs e) {
            if(((DXDialog)sender).DialogResult == DialogResult.OK) {
                SaveChandes();
            }
            control = null;
            customerToEdit = null;
        }

        void SaveChandes() {
            try {
                context.SubmitChanges(SubmitChangesCallback, null);
            } catch(Exception ex) {
                context.RejectChanges();
                HandleException(ex);
            }
        }
        void SubmitChangesCallback(SubmitOperation submitOperation) {
            if(submitOperation.HasError) {
                if(submitOperation.CanCancel) submitOperation.Cancel();
                context.RejectChanges();
                HandleException(submitOperation.Error);
                submitOperation.MarkErrorAsHandled();
            }
            uiDispatcher.BeginInvoke(() => riaInstantSource.Refresh());
        }
        void HandleException(Exception ex) {
            uiDispatcher.BeginInvoke(() => MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK));
        }
    }
}
