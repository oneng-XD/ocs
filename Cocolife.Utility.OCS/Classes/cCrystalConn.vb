#Region "Description"
' PAGE NAME     : CRYSTAL REPORT CONNECTIONS CLASS
' CREATED BY    : MPRO
' CREATED DATE  : 01/24/2014
' UPDATE LOGS [modified by | modified date | updates]
' ------------------------------------------------------------------------------- 
' 
' ------------------------------------------------------------------------------- 
#End Region

#Region "Imports"
Imports bllSecurity = Cocolife.BLL.Common.Security
Imports bllConn = Cocolife.BLL.Common.Database.BCollectionWeb
#End Region

Namespace Classes

    Public Class cCrystalConn
        Public Shared ReadOnly Property CRServerName As String
            Get
                Return Trim(bllSecurity.BMatrixEncrypt.DecryptCode(bllConn.Instance.DataSource))
            End Get
        End Property

        Public Shared ReadOnly Property CRUserID As String
            Get
                Return Trim(bllSecurity.BMatrixEncrypt.DecryptCode(bllConn.Instance.UserCode))
            End Get

        End Property
        Public Shared ReadOnly Property CRPassword As String
            Get
                Return Trim(bllSecurity.BMatrixEncrypt.DecryptCode(bllConn.Instance.UserPass))
            End Get
        End Property
    End Class

End Namespace


