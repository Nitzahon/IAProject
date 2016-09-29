<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication.WebForm1" %>

<%@ Register assembly="Paragraph" namespace="Paragraph" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IATest</title>


    <style>
        .house {
            text-align: center;
        }
    </style>
</head>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
                <script type="text/javascript">                     
                    var obj, img,lab1,lab2;
                    var Testing=0;                    
                    $(document).ready(function () {
                        obj = <%=data%>;
                        img=document.getElementById("Image1");
                        lab1=document.getElementById("Label1");
                        lab2=document.getElementById("Label2");
                        lab1.style.visibility="hidden";
                        lab2.style.visibility="hidden";
                        img.style.visibility = "hidden";
                        TheResponseHasArrived(obj)
                    });
                    function EnterEvent(e)
                    {
                        var x = e.keyCode;                // Get the Unicode value
                        var y = String.fromCharCode(x);       // Convert the value into a character
                        if (x == 73 || x == 105 || x == 69 || x == 101)
                        {
                            checkAnswer(x)
                        }
                        
                    }
                    function checkAnswer(e)
                    {
                        if (e == 73 || e == 105)
                        {
                            checkright(obj.g1.Pair2.data)
                        }
                        else
                        {
                            checkright(obj.g1.Pair1.data)
                        }
                    }
                    function checkright(data)
                    {
                        if(data.indexOf(obj.curr)>-1)
                        {
                            img=document.getElementById("Image1").style.visibility = "hidden"; 
                            updateTestEntry(obj);
                           
                        }
                        else
                        {
                            img=document.getElementById("Image1").style.visibility = "visible"; 
                        }
                    }
                    function TheResponseHasArrived(e)
                    {
                        try
                        {
                            lab1.innerHTML=e.g1.Pair1.name;
                            lab1.style.visibility="visible";
                            lab2.innerHTML=e.g1.Pair2.name;
                            lab2.style.visibility="visible";
                            updateTestEntry(e);
                        }
                        catch (e)
                        {
                            alert('ERROR:' + e.description);
                        }                        

                    }
                    function updateTestEntry(test)
                    {
                        var t = Math.floor(Math.random() * 2)+1;
                        var t1;
                        if(t==1)
                        {                            
                            t1 = Math.floor(Math.random() * test.g1.Pair1.data.length);
                            addTextOrImage(test.g1.Pair1.data[t1], test.g1.Pair1.isImage[t1]);

                        }
                        else if (t==2)
                        {
                            t1 = Math.floor(Math.random() * test.g1.Pair2.data.length);
                            addTextOrImage(test.g1.Pair2.data[t1], test.g1.Pair2.isImage[t1]);
                        }
                    }
                    function addTextOrImage(entry, bool)
                    {
                        var element = document.getElementById("TestEntry");
                        if(bool==true)
                        {
                            element.innerHTML = "<img src='"+entry+"' />";
                        }
                        else
                        {
                            element.innerHTML = entry; 
                        }
                        obj.curr=entry;
                    }
                    
                    
    </script>
<body runat="server" onkeyup="EnterEvent(event)" style="background-color: #000066">

    <form id="form1" runat="server">
        <div class="house" style="z-index: 1; left: 30px; top: 30px; position: absolute; height: 30px; width: 100px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Yellow"></asp:Label>
        </div>            
        <div class="house" style="z-index: 1; left: 30px; bottom: 10px; position: absolute; height: 30px; width: 100px">
            <asp:HiddenField ID="HiddenField1" runat="server" Value="0"/>
            <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="True" Font-Size="Larger" ForeColor="Yellow" Visible="False"></asp:Label>
            </div>
        <div class="house" style="z-index: 1; margin-left: auto; margin-right: auto; margin-top: 100px; margin-bottom: 10px; width: 100px">
            
            

            <cc1:P ID="TestEntry" runat="server" Font-Size="Larger" ForeColor="Yellow"></cc1:P>
            
            

            <br />
            <asp:Image ID="Image1" runat="server" Height="100px" ImageAlign="Middle" ImageUrl="~/close.png" Width="100px" />

        </div>
        <div class="house" style="z-index: 1; right: 30px; top: 30px; position: absolute; height: 30px; width: 100px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Yellow"></asp:Label>
        </div>


    </form>


</body>
</html>
