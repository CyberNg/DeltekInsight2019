' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.vb at the Solution Explorer and start debugging.
Public Class Service1
    Implements IService1

    Public Sub New()
    End Sub

    'Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
    '    Return String.Format("You entered: {0}", value)
    'End Function

    'Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
    '    If composite Is Nothing Then
    '        Throw New ArgumentNullException("composite")
    '    End If
    '    If composite.BoolValue Then
    '        composite.StringValue &= "Suffix"
    '    End If
    '    Return composite
    'End Function

    Private errorString As String = ""

    Private Sub AddErrorToErrorString(ByVal errorMessage As String)
        errorString &= Chr(13) & Chr(10) & errorMessage
    End Sub

    Public Function timesheetVal(ByVal inData As String) As String Implements IService1.timesheetVal
        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter("C:\TSXMLData.txt", False)
        'file.WriteLine(inData)
        'file.Close()

        'Misc return strings tests
        timesheetVal = "<errors warning=""y""><error>This is my first timesheet error</error></errors>"
        timesheetVal = "<errors></errors>"
        timesheetVal = "<errors><error>Overtime Is Not allowed</error></errors>"
        timesheetVal = "<errors><error>Overtime is not allowed</error><error>Special overtime is not allowed</error></errors>"
        timesheetVal = "<errors><error>” & Chr(13) & Chr(10) & “- Overtime is not allowed </error><error>” & Chr(13) & Chr(10) & “- Special overtime is not allowed</error></errors>"

        'AddErrorToErrorString calls
        AddErrorToErrorString("Error 1")
        AddErrorToErrorString("Error 2")
        timesheetVal = "<errors><error>" & errorString & "</error></errors>"

        ''''''Parsing inData XML tests
        '''''Dim timesheetDom As New XmlDocument
        '''''timesheetDom.LoadXml(inData)

        ''''''   tkMaster
        '''''Dim tkMasterNode As XmlNode
        '''''tkMasterNode = timesheetDom.DocumentElement.SelectSingleNode("descendant::ROW")

        '''''Dim tkMasterData As String
        '''''tkMasterData = tkMasterNode.Item("EndDate").InnerText
        '''''tkMasterData = tkMasterNode.Item("Submitted").InnerText
        '''''tkMasterData = tkMasterNode.Item("Selected").InnerText
        '''''tkMasterData = tkMasterNode.Item("SubmittedBy").InnerText
        '''''tkMasterData = tkMasterNode.Item("ApprovedBy").InnerText
        '''''tkMasterData = tkMasterNode.Item("Employee").InnerText

        ''''''   tkDetail
        '''''Dim tkDetailNode As XmlNode
        '''''tkDetailNode = timesheetDom.DocumentElement.SelectSingleNode("descendant::tkDetail")

        '''''Dim totalRegHours As Decimal = 0.00
        '''''Dim tkDetailNodeData As String
        '''''While Not (tkDetailNode Is Nothing)
        '''''    If tkDetailNode.Name = "tkDetail" Then
        '''''        tkDetailNodeData = tkDetailNode.Item("EndDate").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("Employee").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("Seq").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("TransDate").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("Category").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("WBS1").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("WBS2").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("WBS3").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("LaborCode").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("RegHrs").InnerText
        '''''        totalRegHours += CDec(tkDetailNodeData)
        '''''        tkDetailNodeData = tkDetailNode.Item("OvtHrs").InnerText
        '''''        tkDetailNodeData = tkDetailNode.Item("SpecialOvtHrs").InnerText
        '''''    End If
        '''''    tkDetailNode = tkDetailNode.NextSibling
        '''''End While

        ''''''   Add a couple of messages to the error string
        '''''AddErrorToErrorString("Employee: " & tkMasterData)
        '''''AddErrorToErrorString("Total Reg Hours: " & CStr(totalRegHours))

        '   Send error string back as a warning, just to display obtained data from inData XML tests
        'timesheetVal = "<errors warning=""y""><error>" & errorString & "</error></errors>"

    End Function
End Class
