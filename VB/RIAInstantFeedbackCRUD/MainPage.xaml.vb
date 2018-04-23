Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.ServiceModel.DomainServices.Client
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Threading
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports RIAInstantFeedbackCRUD.Web

Namespace RIAInstantFeedbackCRUD
	Partial Public Class MainPage
		Inherits UserControl
		Private context As NorthwindContext
		Private control As Control
		Private newCustomer As Customers
		Private customerToEdit As Customers
		Private uiDispatcher As Dispatcher

		Public Sub New()
			InitializeComponent()
			uiDispatcher = grid.Dispatcher
			context = New NorthwindContext()
			riaInstantSource.DomainContext = context
		End Sub

		Private Sub Add_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			newCustomer = CreateNewCustomer()
			EditCustomer(newCustomer, "Add new customer", AddressOf CloseAddNewCustomerHandler)
		End Sub
		Private Sub Remove_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			DeleteSelectedCustomer(view.FocusedRowHandle)
		End Sub
		Private Sub Edit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			EditSelectedCustomer(view.FocusedRowHandle)
		End Sub
		Private Sub view_RowDoubleClick(ByVal sender As Object, ByVal e As RowDoubleClickEventArgs)
			EditSelectedCustomer(e.HitInfo.RowHandle)
		End Sub
		Private Sub view_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs)
			If e.Key = System.Windows.Input.Key.Delete Then
				DeleteSelectedCustomer(view.FocusedRowHandle)
			End If
			If e.Key = System.Windows.Input.Key.Enter Then
				EditSelectedCustomer(view.FocusedRowHandle)
			End If
		End Sub

		Private Function GetCustomerIDByRowHandle(ByVal rowHandle As Integer) As String
			Return CStr(grid.GetCellValue(rowHandle, colCustomerID))
		End Function
		Private Sub FindCustomerByIDAndProcess(ByVal customerID As String, ByVal action As Action(Of Customers))
			Try
				context.Load(Of Customers)(context.GetCustomerByIDQuery(customerID), AddressOf FindCustomerByIDCallback, action)
			Catch ex As Exception
				HandleException(ex)
			End Try
		End Sub
		Private Sub FindCustomerByIDCallback(ByVal loadOperation As LoadOperation(Of Customers))
			If loadOperation.HasError Then
				If loadOperation.CanCancel Then
					loadOperation.Cancel()
				End If
				HandleException(loadOperation.Error)
				loadOperation.MarkErrorAsHandled()
				Return
			End If
			Dim action As Action(Of Customers) = CType(loadOperation.UserState, Action(Of Customers))
			For Each customer As Customers In loadOperation.Entities
				Try
                    uiDispatcher.BeginInvoke(action, customer)
				Catch ex As Exception
					HandleException(ex)
				End Try
			Next customer
		End Sub

		Private Function CreateNewCustomer() As Customers
			Dim newCustomer As New Customers()
			newCustomer.CustomerID = GenerateCustomerID()
			Return newCustomer
		End Function
		Private Function GenerateCustomerID() As String
			Const IDLength As Integer = 5
			Dim result As String = String.Empty
			Dim rnd As New Random()
			For i As Integer = 0 To IDLength - 1
				result &= Convert.ToChar(rnd.Next(65, 90))
			Next i
			Return result
		End Function
		Private Sub DeleteSelectedCustomer(ByVal rowHandle As Integer)
			If rowHandle < 0 Then
				Return
			End If
			If MessageBox.Show("Do you really want to delete the selected customer?", "Delete Customer", MessageBoxButton.OKCancel) <> MessageBoxResult.OK Then
				Return
			End If
			FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), Function(customer) AnonymousMethod1(customer))
		End Sub
		
		Private Function AnonymousMethod1(ByVal customer As Object) As Boolean
			context.Customers.Remove(customer)
			SaveChandes()
			Return True
		End Function
		Private Sub EditSelectedCustomer(ByVal rowHandle As Integer)
			If rowHandle < 0 Then
				Return
			End If
			FindCustomerByIDAndProcess(GetCustomerIDByRowHandle(rowHandle), Function(customer) AnonymousMethod2(customer))
		End Sub
		
		Private Function AnonymousMethod2(ByVal customer As Object) As Boolean
			customerToEdit = customer
			EditCustomer(customerToEdit, "Edit customer", AddressOf CloseEditCustomerHandler)
			Return True
		End Function
		Private Sub EditCustomer(ByVal customer As Customers, ByVal windowTitle As String, ByVal closedDelegate As EventHandler)
			control = New ContentControl With {.Template = CType(Resources("EditRecordTemplate"), ControlTemplate)}
			control.DataContext = customer

			Dim dialog As New DXDialog(windowTitle, DialogButtons.OkCancel)
			dialog.Content = control
			AddHandler dialog.Closed, closedDelegate
			dialog.ShowDialog()
		End Sub
		Private Sub CloseAddNewCustomerHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (CType(sender, DXDialog)).DialogResult = DialogResult.OK Then
				context.Customers.Add(newCustomer)
				SaveChandes()
			End If
			control = Nothing
			newCustomer = Nothing
		End Sub
		Private Sub CloseEditCustomerHandler(ByVal sender As Object, ByVal e As EventArgs)
			If (CType(sender, DXDialog)).DialogResult = DialogResult.OK Then
				SaveChandes()
			End If
			control = Nothing
			customerToEdit = Nothing
		End Sub

		Private Sub SaveChandes()
			Try
				context.SubmitChanges(AddressOf SubmitChangesCallback, Nothing)
			Catch ex As Exception
				context.RejectChanges()
				HandleException(ex)
			End Try
		End Sub
		Private Sub SubmitChangesCallback(ByVal submitOperation As SubmitOperation)
			If submitOperation.HasError Then
				If submitOperation.CanCancel Then
					submitOperation.Cancel()
				End If
				context.RejectChanges()
				HandleException(submitOperation.Error)
				submitOperation.MarkErrorAsHandled()
			End If
            uiDispatcher.BeginInvoke(AddressOf riaInstantSource.Refresh)
		End Sub
		Private Sub HandleException(ByVal ex As Exception)
			uiDispatcher.BeginInvoke(Function() MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK))
		End Sub
	End Class
End Namespace
