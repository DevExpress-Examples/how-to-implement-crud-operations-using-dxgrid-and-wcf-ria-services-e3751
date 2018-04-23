﻿'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------


Imports Microsoft.VisualBasic
Imports System
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

<Assembly: EdmSchemaAttribute()>

Namespace RIAInstantFeedbackCRUD.Web
	#Region "Contexts"

	''' <summary>
	''' No Metadata Documentation available.
	''' </summary>
	Partial Public Class NorthwindEntities
		Inherits ObjectContext
		#Region "Constructors"

		''' <summary>
		''' Initializes a new NorthwindEntities object using the connection string found in the 'NorthwindEntities' section of the application configuration file.
		''' </summary>
		Public Sub New()
			MyBase.New("name=NorthwindEntities", "NorthwindEntities")
			Me.ContextOptions.LazyLoadingEnabled = True
			OnContextCreated()
		End Sub

		''' <summary>
		''' Initialize a new NorthwindEntities object.
		''' </summary>
		Public Sub New(ByVal connectionString As String)
			MyBase.New(connectionString, "NorthwindEntities")
			Me.ContextOptions.LazyLoadingEnabled = True
			OnContextCreated()
		End Sub

		''' <summary>
		''' Initialize a new NorthwindEntities object.
		''' </summary>
		Public Sub New(ByVal connection As EntityConnection)
			MyBase.New(connection, "NorthwindEntities")
			Me.ContextOptions.LazyLoadingEnabled = True
			OnContextCreated()
		End Sub

		#End Region

		#Region "Partial Methods"

		Partial Private Sub OnContextCreated()
		End Sub

		#End Region

		#Region "ObjectSet Properties"

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		Public ReadOnly Property Customers() As ObjectSet(Of Customers)
			Get
				If (_Customers Is Nothing) Then
					_Customers = MyBase.CreateObjectSet(Of Customers)("Customers")
				End If
				Return _Customers
			End Get
		End Property
		Private _Customers As ObjectSet(Of Customers)

		#End Region
		#Region "AddTo Methods"

		''' <summary>
		''' Deprecated Method for adding a new object to the Customers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
		''' </summary>
		Public Sub AddToCustomers(ByVal customers As Customers)
			MyBase.AddObject("Customers", customers)
		End Sub

		#End Region
	End Class


	#End Region

	#Region "Entities"

	''' <summary>
	''' No Metadata Documentation available.
	''' </summary>
	<EdmEntityTypeAttribute(NamespaceName:="NorthwindModel", Name:="Customers"), Serializable(), DataContractAttribute(IsReference:=True)> _
	Partial Public Class Customers
		Inherits EntityObject
		#Region "Factory Method"

		''' <summary>
		''' Create a new Customers object.
		''' </summary>
		''' <param name="customerID">Initial value of the CustomerID property.</param>
		''' <param name="companyName">Initial value of the CompanyName property.</param>
		Public Shared Function CreateCustomers(ByVal customerID As Global.System.String, ByVal companyName As Global.System.String) As Customers
			Dim customers As New Customers()
			customers.CustomerID = customerID
			customers.CompanyName = companyName
			Return customers
		End Function

		#End Region
		#Region "Primitive Properties"

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False), DataMemberAttribute()> _
		Public Property CustomerID() As Global.System.String
			Get
				Return _CustomerID
			End Get
			Set(ByVal value As System.String)
				If _CustomerID <> value Then
					OnCustomerIDChanging(value)
					ReportPropertyChanging("CustomerID")
					_CustomerID = StructuralObject.SetValidValue(value, False)
					ReportPropertyChanged("CustomerID")
					OnCustomerIDChanged()
				End If
			End Set
		End Property
		Private _CustomerID As Global.System.String
		Partial Private Sub OnCustomerIDChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnCustomerIDChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False), DataMemberAttribute()> _
		Public Property CompanyName() As Global.System.String
			Get
				Return _CompanyName
			End Get
			Set(ByVal value As System.String)
				OnCompanyNameChanging(value)
				ReportPropertyChanging("CompanyName")
				_CompanyName = StructuralObject.SetValidValue(value, False)
				ReportPropertyChanged("CompanyName")
				OnCompanyNameChanged()
			End Set
		End Property
		Private _CompanyName As Global.System.String
		Partial Private Sub OnCompanyNameChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnCompanyNameChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property ContactName() As Global.System.String
			Get
				Return _ContactName
			End Get
			Set(ByVal value As System.String)
				OnContactNameChanging(value)
				ReportPropertyChanging("ContactName")
				_ContactName = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("ContactName")
				OnContactNameChanged()
			End Set
		End Property
		Private _ContactName As Global.System.String
		Partial Private Sub OnContactNameChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnContactNameChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property ContactTitle() As Global.System.String
			Get
				Return _ContactTitle
			End Get
			Set(ByVal value As System.String)
				OnContactTitleChanging(value)
				ReportPropertyChanging("ContactTitle")
				_ContactTitle = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("ContactTitle")
				OnContactTitleChanged()
			End Set
		End Property
		Private _ContactTitle As Global.System.String
		Partial Private Sub OnContactTitleChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnContactTitleChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property Address() As Global.System.String
			Get
				Return _Address
			End Get
			Set(ByVal value As System.String)
				OnAddressChanging(value)
				ReportPropertyChanging("Address")
				_Address = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("Address")
				OnAddressChanged()
			End Set
		End Property
		Private _Address As Global.System.String
		Partial Private Sub OnAddressChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnAddressChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property City() As Global.System.String
			Get
				Return _City
			End Get
			Set(ByVal value As System.String)
				OnCityChanging(value)
				ReportPropertyChanging("City")
				_City = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("City")
				OnCityChanged()
			End Set
		End Property
		Private _City As Global.System.String
		Partial Private Sub OnCityChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnCityChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property Region() As Global.System.String
			Get
				Return _Region
			End Get
			Set(ByVal value As System.String)
				OnRegionChanging(value)
				ReportPropertyChanging("Region")
				_Region = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("Region")
				OnRegionChanged()
			End Set
		End Property
		Private _Region As Global.System.String
		Partial Private Sub OnRegionChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnRegionChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property PostalCode() As Global.System.String
			Get
				Return _PostalCode
			End Get
			Set(ByVal value As System.String)
				OnPostalCodeChanging(value)
				ReportPropertyChanging("PostalCode")
				_PostalCode = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("PostalCode")
				OnPostalCodeChanged()
			End Set
		End Property
		Private _PostalCode As Global.System.String
		Partial Private Sub OnPostalCodeChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnPostalCodeChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property Country() As Global.System.String
			Get
				Return _Country
			End Get
			Set(ByVal value As System.String)
				OnCountryChanging(value)
				ReportPropertyChanging("Country")
				_Country = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("Country")
				OnCountryChanged()
			End Set
		End Property
		Private _Country As Global.System.String
		Partial Private Sub OnCountryChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnCountryChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property Phone() As Global.System.String
			Get
				Return _Phone
			End Get
			Set(ByVal value As System.String)
				OnPhoneChanging(value)
				ReportPropertyChanging("Phone")
				_Phone = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("Phone")
				OnPhoneChanged()
			End Set
		End Property
		Private _Phone As Global.System.String
		Partial Private Sub OnPhoneChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnPhoneChanged()
		End Sub

		''' <summary>
		''' No Metadata Documentation available.
		''' </summary>
		<EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True), DataMemberAttribute()> _
		Public Property Fax() As Global.System.String
			Get
				Return _Fax
			End Get
			Set(ByVal value As System.String)
				OnFaxChanging(value)
				ReportPropertyChanging("Fax")
				_Fax = StructuralObject.SetValidValue(value, True)
				ReportPropertyChanged("Fax")
				OnFaxChanged()
			End Set
		End Property
		Private _Fax As Global.System.String
		Partial Private Sub OnFaxChanging(ByVal value As Global.System.String)
		End Sub
		Partial Private Sub OnFaxChanged()
		End Sub

		#End Region

	End Class

	#End Region

End Namespace
