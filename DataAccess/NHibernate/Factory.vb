Imports NHibernate
Imports FluentNHibernate.Cfg
Imports FluentNHibernate.Cfg.Db
Imports System.Configuration

Namespace SessionManager
    Public Class Factory
        Private Sub New()
        End Sub

        Private Shared SessionFactory As ISessionFactory
        Private Shared ReadOnly MilStoneLoggerDbConnectionString As String = _
            "Server=tcp:irktykc7ce.database.windows.net,1433;Database=MilestoneLoggerDb;User ID=Ed@irktykc7ce;Password=pluto.1352;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;"

        Public Shared Function OpenSession() As ISession
            If SessionFactory Is Nothing Then
                Dim DatabaseConfiguration = MsSqlConfiguration.MsSql2008.ConnectionString(MilStoneLoggerDbConnectionString).ShowSql()
                Dim Configuration = Fluently.Configure().Database(DatabaseConfiguration).Mappings(Sub(m) m.FluentMappings.AddFromAssemblyOf(Of ModelEntity)())
                SessionFactory = Configuration.BuildSessionFactory()
            End If
            Return SessionFactory.OpenSession()
        End Function

    End Class
End Namespace
