Imports Microsoft.VisualBasic
	Imports System
	Imports System.Collections.Generic
	Imports System.ComponentModel
	Imports System.ComponentModel.DataAnnotations
	Imports System.Linq
	Imports System.ServiceModel.DomainServices.Hosting
	Imports System.ServiceModel.DomainServices.Server
Namespace RIAInstantFeedbackCRUD.Web


	' The MetadataTypeAttribute identifies CustomersMetadata as the class
	' that carries additional metadata for the Customers class.
	<MetadataTypeAttribute(GetType(Customers.CustomersMetadata))> _
	Partial Public Class Customers

		' This class allows you to attach custom attributes to properties
		' of the Customers class.
		'
		' For example, the following marks the Xyz property as a
		' required property and specifies the format for valid values:
		'    [Required]
		'    [RegularExpression("[A-Z][A-Za-z0-9]*")]
		'    [StringLength(32)]
		'    public string Xyz { get; set; }
		Friend NotInheritable Class CustomersMetadata

			' Metadata classes are not meant to be instantiated.
			Private Sub New()
			End Sub

			Private privateAddress As String
			Public Property Address() As String
				Get
					Return privateAddress
				End Get
				Set(ByVal value As String)
					privateAddress = value
				End Set
			End Property

			Private privateCity As String
			Public Property City() As String
				Get
					Return privateCity
				End Get
				Set(ByVal value As String)
					privateCity = value
				End Set
			End Property

			Private privateCompanyName As String
			Public Property CompanyName() As String
				Get
					Return privateCompanyName
				End Get
				Set(ByVal value As String)
					privateCompanyName = value
				End Set
			End Property

			Private privateContactName As String
			Public Property ContactName() As String
				Get
					Return privateContactName
				End Get
				Set(ByVal value As String)
					privateContactName = value
				End Set
			End Property

			Private privateContactTitle As String
			Public Property ContactTitle() As String
				Get
					Return privateContactTitle
				End Get
				Set(ByVal value As String)
					privateContactTitle = value
				End Set
			End Property

			Private privateCountry As String
			Public Property Country() As String
				Get
					Return privateCountry
				End Get
				Set(ByVal value As String)
					privateCountry = value
				End Set
			End Property

			Private privateCustomerID As String
			Public Property CustomerID() As String
				Get
					Return privateCustomerID
				End Get
				Set(ByVal value As String)
					privateCustomerID = value
				End Set
			End Property

			Private privateFax As String
			Public Property Fax() As String
				Get
					Return privateFax
				End Get
				Set(ByVal value As String)
					privateFax = value
				End Set
			End Property

			Private privatePhone As String
			Public Property Phone() As String
				Get
					Return privatePhone
				End Get
				Set(ByVal value As String)
					privatePhone = value
				End Set
			End Property

			Private privatePostalCode As String
			Public Property PostalCode() As String
				Get
					Return privatePostalCode
				End Get
				Set(ByVal value As String)
					privatePostalCode = value
				End Set
			End Property

			Private privateRegion As String
			Public Property Region() As String
				Get
					Return privateRegion
				End Get
				Set(ByVal value As String)
					privateRegion = value
				End Set
			End Property
		End Class
	End Class
End Namespace
