Imports Microsoft.VisualBasic.CompilerServices
Imports System
Public Class objCapNhatKhamChuaBenh

    Public m_sMaNV As String
    Public m_sMaKCB As String
    Public m_sNgTao As String
    Public m_sNgCapNhat As String
    Public m_dNgayTao As String
    Public m_dNgayCapNhat As String
    Public m_iChonBang As Integer
    Public m_sMaDV As String
    Public m_sNGAY As String
    Public m_sChonKhu As String

    Public Property MaNV() As String
        Get
            Return Me.m_sMaNV
        End Get
        Set(ByVal value As String)
            Me.m_sMaNV = value
        End Set
    End Property

    Public Property MaKCB() As String
        Get
            Return Me.m_sMaKCB
        End Get
        Set(ByVal value As String)
            Me.m_sMaKCB = value
        End Set
    End Property

    Public Property NguoiTao() As String
        Get
            Return Me.m_sNgTao
        End Get
        Set(ByVal value As String)
            Me.m_sNgTao = value
        End Set
    End Property

    Public Property NguoiCapNhat() As String
        Get
            Return Me.m_sNgCapNhat
        End Get
        Set(ByVal value As String)
            Me.m_sNgCapNhat = value
        End Set
    End Property

    Public Property NgayTao() As String
        Get
            Return Me.m_dNgayTao
        End Get
        Set(ByVal value As String)
            Me.m_dNgayTao = value
        End Set
    End Property

    Public Property NgayCapNhat() As String
        Get
            Return Me.m_dNgayCapNhat
        End Get
        Set(ByVal value As String)
            Me.m_dNgayCapNhat = value
        End Set
    End Property

    Public Property ChonBang() As Integer
        Get
            Return Me.m_iChonBang
        End Get
        Set(ByVal value As Integer)
            Me.m_iChonBang = value
        End Set
    End Property

    Public Property MaDV() As String
        Get
            Return Me.m_sMaDV
        End Get
        Set(ByVal value As String)
            Me.m_sMaDV = value
        End Set
    End Property

    Public Property NGAY() As String
        Get
            Return Me.m_sNGAY
        End Get
        Set(ByVal value As String)
            Me.m_sNGAY = value
        End Set
    End Property

    Public Property ChonKhu() As String
        Get
            Return Me.m_sChonKhu
        End Get
        Set(ByVal value As String)
            Me.m_sChonKhu = value
        End Set
    End Property

    Public Function setnull() As Boolean
        Me.ChonBang = 0
    End Function

    Public Function setvalue(ByVal manv As String, ByVal makcb As String, ByVal ngaytao As String, ByVal ngtao As String, ByVal ngaycapnhat As String, ByVal ngcapnhat As String, ByVal chontabe As Integer, ByVal madv As String, ByVal ngay As String) As Boolean
        Me.MaNV = manv
        Me.MaKCB = makcb
        Me.NgayTao = ngaytao
        Me.NguoiTao = ngtao
        Me.NgayCapNhat = ngaycapnhat
        Me.NguoiCapNhat = ngcapnhat
        Me.ChonBang = chontabe
        Me.MaDV = madv
        Me.NGAY = ngay
    End Function

End Class
