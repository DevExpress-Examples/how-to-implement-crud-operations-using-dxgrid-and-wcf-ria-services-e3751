Imports Microsoft.VisualBasic
	Imports System
	Imports System.Collections.Generic
	Imports System.ComponentModel
	Imports System.ComponentModel.DataAnnotations
	Imports System.Data
	Imports System.Linq
	Imports System.ServiceModel.DomainServices.EntityFramework
	Imports System.ServiceModel.DomainServices.Hosting
	Imports System.ServiceModel.DomainServices.Server
Namespace RIAInstantFeedbackCRUD.Web


	' Implements application logic using the NorthwindEntities context.
	' TODO: Add your application logic to these methods or in additional methods.
	' TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
	' Also consider adding roles to restrict access as appropriate.
	' [RequiresAuthentication]
	<EnableClientAccess()> _
	Public Class NorthwindService
		Inherits LinqToEntitiesDomainService(Of NorthwindEntities)

		' TODO:
		' Consider constraining the results of your query method.  If you need additional input you can
		' add parameters to this method or create additional query methods with different names.
		' To support paging you will need to add ordering to the 'Customers' query.
		Public Function GetCustomers() As IQueryable(Of Customers)
			Return Me.ObjectContext.Customers
		End Function
		Public Function GetCustomersExtendedData(ByVal extendedDataInfo As String) As String
			Return DevExpress.Xpf.Core.ServerMode.ExtendedDataHelper.GetExtendedData(GetCustomers(), extendedDataInfo)
		End Function
		<Query(IsComposable := False)> _
		Public Function GetCustomerByID(ByVal customerID As String) As Customers
			Return Me.ObjectContext.Customers.SingleOrDefault(Function(customer) customer.CustomerID = customerID)
		End Function

		Public Sub InsertCustomers(ByVal customers As Customers)
			If (customers.EntityState <> EntityState.Detached) Then
				Me.ObjectContext.ObjectStateManager.ChangeObjectState(customers, EntityState.Added)
			Else
				Me.ObjectContext.Customers.AddObject(customers)
			End If
		End Sub

		Public Sub UpdateCustomers(ByVal currentCustomers As Customers)
			Me.ObjectContext.Customers.AttachAsModified(currentCustomers, Me.ChangeSet.GetOriginal(currentCustomers))
		End Sub

		Public Sub DeleteCustomers(ByVal customers As Customers)
			If (customers.EntityState <> EntityState.Detached) Then
				Me.ObjectContext.ObjectStateManager.ChangeObjectState(customers, EntityState.Deleted)
			Else
				Me.ObjectContext.Customers.Attach(customers)
				Me.ObjectContext.Customers.DeleteObject(customers)
			End If
		End Sub
	End Class
End Namespace


