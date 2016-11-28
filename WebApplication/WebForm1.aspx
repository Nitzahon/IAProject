<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

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
                    var obj, img,lab1,lab2,lab1B,lab2B,orl,orr;
                    var Testing=false;
                    var answered=0;
                    var topleft,topright,btmleft,btmright;
                    var Stage=0;
                    var Start=true;
                    var firstTestMis=[],secondTestMis=[];
                    var firstTestTime=[], secondTestTime=[];
                    var start,end,time;
                    var miss=0;
                    $(document).ready(function () {
                        obj = <%=data%>;
                        img=document.getElementById("Image1");
                        lab1=document.getElementById("Label1");
                        lab2=document.getElementById("Label2");
                        lab1B=document.getElementById("Label1B");
                        lab2B=document.getElementById("Label2B");
                        orl=document.getElementById("orLeft");
                        orr=document.getElementById("orRight");
                        lab1.style.visibility="hidden";
                        lab2.style.visibility="hidden";
                        img.style.visibility = "hidden";
                        lab1B.style.visibility = "hidden";
                        lab2B.style.visibility = "hidden";
                        orl.style.visibility = "hidden";
                        orr.style.visibility = "hidden";
                        element = document.getElementById("TestEntry");

                        TheResponseHasArrived(obj)
                    });
                    function EnterEvent(e)
                    {
                        var x = e.keyCode;                // Get the Unicode value
                        var y = String.fromCharCode(x);       // Convert the value into a character
                        if(Start==true)
                        {
                            if(x== 32)
                            {
                                updateTestEntry(e)
                            }
                        }
                        else
                        {
                            if (x == 73 || x == 105 || x == 69 || x == 101)
                            {
                                checkAnswer(x)
                            }
                        }
                        
                    }
                    function checkAnswer(e)
                    {
                        var btl,btr;
                        if(btmright != null &&btmleft != null)
                        {
                            btl=btmleft.data;
                            btr=btmright.data;
                        }
                        else
                        {
                            btl=null;
                            btr=null;
                        }
                        if (e == 73 || e == 105)
                        {
                            checkright(topright.data, btr)
                        }
                        else
                        {
                            checkright(topleft.data,btl)
                        }
                    }
                    function checkright(data, data2)
                    {
                        if(data.indexOf(obj.curr)>-1)
                        {
                            img=document.getElementById("Image1").style.visibility = "hidden"; 
                            updateTestEntry(obj);

                        }
                        else if(data2!=null && data2.indexOf(obj.curr)>-1)
                        {
                            img=document.getElementById("Image1").style.visibility = "hidden"; 
                            updateTestEntry(obj);
                        }
                        else
                        {
                            img=document.getElementById("Image1").style.visibility = "visible";
                            miss++;
                        }
                    }
                    function TheResponseHasArrived(e)
                    {
                        try
                        {
                            
                            startStage(e);
                        }
                        catch (e)
                        {
                            alert('ERROR:' + e.description);
                        }                        

                    }
                    function startStage(e)
                    {
                        topleft=null;
                        topright=null;
                        btmleft=null;
                        btmright=null;
                        lab1.innerHTML=e.g1.Pair1.name;
                        lab1.style.visibility="visible";
                        lab2.innerHTML=e.g1.Pair2.name;
                        lab2.style.visibility="visible";
                        topleft= e.g1.Pair1;
                        topright=e.g1.Pair2;
                        element.innerHTML="Stage 1";
                    }
                    function updateTestEntry(test)
                    {

                        
                        if(Start==true)
                        {
                            
                            Start=false
                            if(Stage==3 || Stage==6)
                                start=new Date().getTime();

                        }
                        else
                        {
                        if(Testing==true)
                        {
                            end= new Date().getTime();
                            time = end-start;
                            if(Stage==3)
                            {
                                firstTestTime.push(time);
                                firstTestMis.push(miss);                                
                            }
                            else
                            {
                                secondTestTime.push(time);
                                secondTestMis.push(miss);  
                            }
                            start=new Date().getTime();
                            miss=0;
                        }
                        answered++;
                        if(answered == 20)
                        {
                            Stage++;
                            answered=0;
                            Start=true;
                            switch(Stage)
                            {
                                

                                case 1:
                                    lab1.innerHTML=test.g2.Pair1.name;
                                    lab2.innerHTML=test.g2.Pair2.name;
                                    topleft=test.g2.Pair1;
                                    topright=test.g2.Pair2;
                                    element.innerHTML="Stage 2";
                                    break;
                                case 2:
                                    orl.style.visibility="visible";
                                    orr.style.visibility="visible";
                                    lab1B.innerHTML=test.g1.Pair1.name;
                                    lab1B.style.visibility="visible";
                                    lab2B.innerHTML=test.g1.Pair2.name;
                                    lab2B.style.visibility="visible";
                                    btmleft= test.g1.Pair1;
                                    btmright=test.g1.Pair2;
                                    element.innerHTML="Stage 3";

                                    break;
                                case 3:
                                    Testing=true;
                                    element.innerHTML="Stage 4 Time to Test";

                                    break;
                                case 4:
                                    Testing=false;
                                    orl.style.visibility="hidden";
                                    orr.style.visibility="hidden";
                                    lab1.innerHTML=test.g1.Pair2.name;
                                    lab1B.style.visibility="hidden";
                                    lab2.innerHTML=test.g1.Pair1.name;
                                    lab2B.style.visibility="hidden";
                                    topleft= test.g1.Pair2;
                                    topright=test.g1.Pair1;
                                    btmleft=null;
                                    btmright=null;
                                    element.innerHTML="Stage 5";

                                    break;
                                case 5:
                                    orl.style.visibility="visible";
                                    orr.style.visibility="visible";
                                    lab1B.innerHTML=test.g2.Pair1.name;
                                    lab1B.style.visibility="visible";
                                    lab2B.innerHTML=test.g2.Pair2.name;
                                    lab2B.style.visibility="visible";
                                    btmleft= test.g2.Pair1;
                                    btmright=test.g2.Pair2;
                                    element.innerHTML="Stage 6";

                                    break;
                                case 6:
                                    Testing=true;
                                    element.innerHTML="Stage 7 Time to Test";

                                    break;
                                case 7:

                                    endTest();
                                    break;
                                default:
                                    topleft=null;
                                    topright=null;
                                    btmleft=null;
                                    btmright=null;
                                    lab1.innerHTML=test.g1.Pair1.name;
                                    lab1.style.visibility="visible";
                                    lab2.innerHTML=test.g1.Pair2.name;
                                    lab2.style.visibility="visible";
                                    topleft= test.g1.Pair1;
                                    topright=test.g1.Pair2;

                            }
                        }
                        
                        }
                        if(Stage!=7 && Start!=true)
                            updateLabel()
                    }

                    function updateLabel()
                    {
                        {
                            var t = Math.floor(Math.random() * 2)+1;
                            var tt = Math.floor(Math.random() * 2)+1;
                            var t1;
                            if(t==1)
                            {     
                                if(btmleft ==null || tt==1)
                                {
                                    t1= Math.floor(Math.random() * topleft.data.length);
                                    addTextOrImage(topleft.data[t1], topleft.isImage[t1]);
                                    element.style.color="Yellow";
                                }
                                else
                                {
                                    t1= Math.floor(Math.random() * btmleft.data.length);
                                    addTextOrImage(btmleft.data[t1], btmleft.isImage[t1]);
                                    element.style.color="#66FF33";

                                }

                            }
                            else if (t==2)
                            {
                                if(btmright ==null || tt==1)
                                {
                                    t1= Math.floor(Math.random() * topright.data.length);
                                    addTextOrImage(topright.data[t1], topright.isImage[t1]);
                                    element.style.color="Yellow";

                                }
                                else
                                {
                                    t1= Math.floor(Math.random() * btmright.data.length);
                                    addTextOrImage(btmright.data[t1], btmright.isImage[t1]);
                                    element.style.color="#66FF33";

                                }
                            }
                        }
                    }
                    function endTest()
                    {
                        var element = document.getElementById("TestEntry")
                        element.style.color="red";
                        element.style.fontSize="Largest";
                        element.innerHTML = "Completed"

                        var ftm = JSON.stringify(firstTestMis);
                        var stm = JSON.stringify(secondTestMis);
                        var ftt = JSON.stringify(firstTestTime);
                        var stt = JSON.stringify(secondTestTime);

                        // Make the ajax call
                        $.ajax({
                            type: "POST",
                            url: "WebForm1.aspx/Done", // the method we are calling
                            contentType: "application/json; charset=utf-8",
                            data: {ids: ftm, stm, ftt, stt },
                            dataType: "json",
                            success: function (result) {
                                alert('Yay! It worked!');               
                            },
                            error: function (result) {
                                alert('Oh no :(');
                            }
                        });
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
        <div class="house" style="z-index: 1; left: 30px; top: 30px; position: absolute; height: 64px; width: 100px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Yellow"></asp:Label>
            <br />
            <asp:Label ID="orLeft" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="White" Text="or"></asp:Label>
            <br />
            <asp:Label ID="Label1B" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#66FF33"></asp:Label>
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
        <div class="house" style="z-index: 1; right: 30px; top: 30px; position: absolute; height: 64px; width: 100px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Yellow"></asp:Label>
            <br />
            <asp:Label ID="orRight" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="White">or</asp:Label>
            <br />
            <asp:Label ID="Label2B" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="#66FF33"></asp:Label>   
        </div>


    </form>


</body>
</html>
