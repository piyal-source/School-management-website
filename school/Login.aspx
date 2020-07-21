<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="school.Slider" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>school
    </title>
    <style>
        * {
            box-sizing: padding-box;
        }

        body {
            font-family: Verdana, sans-serif;
            background-color:wheat;
            padding:10px;
        }

        .mySlides {
            display: none;
        }

        img {
            vertical-align: middle;
        }

        /* Slideshow container */
        .slideshow-container {
            max-height: 300px;
            position: relative;
            margin: auto;
        }

        /* Next & previous buttons */
        .prev, .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            width: auto;
            padding: 16px;
            margin-top: -22px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            transition: 0.6s ease;
            border-radius: 0 3px 3px 0;
            user-select: none;
        }

        /* Position the "next button" to the right */
        .next {
            right: 0;
            border-radius: 3px 0 0 3px;
        }

            /* On hover, add a black background color with a little bit see-through */
            .prev:hover, .next:hover {
                background-color: rgba(0,0,0,0.8);
            }

        /* Caption text */
        .text {
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        /* Number text (1/3 etc) */
        .numbertext {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        /* The dots/bullets/indicators */
        .dot {
            cursor: pointer;
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

            .active, .dot:hover {
                background-color: #717171;
            }

        /* Fading animation */
        .fade {
            -webkit-animation-name: fade;
            -webkit-animation-duration: 1.5s;
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @-webkit-keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes fade {
            from {
                opacity: .4;
            }

            to {
                opacity: 1;
            }
        }

        /* On smaller screens, decrease text size */
        @media only screen and (max-width: 300px) {
            .prev, .next, .text {
                font-size: 11px;
            }
        }

        .auto-style1 {
            width: 567px;
        }

        .hb {
            height: 25px;
            width: 200px;
        }

        .auto-style2 {
            width: 65px;
        }

        .auto-style3 {
            width: 31px;
        }

    </style>

</head>

<body>

    <form id="form1" runat="server">

        <div>           
            <table>
                <tr>
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/school logo.png" Height="50px" Width="50px" />
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="SCHOOL MANAGEMENT SYSTEM" style="font-size: 50px; font-family: Algerian"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" BackColor="LightGray" Font-Size="25px" StaticHoverStyle-BackColor="White" Width="100%" StaticMenuItemStyle-HorizontalPadding="30px" StaticMenuItemStyle-ForeColor="Black" DynamicMenuItemStyle-BackColor="LightGray" DynamicHoverStyle-BackColor="White" DynamicMenuItemStyle-ForeColor="Black">
            <Items>
                <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/Login.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Records" Value="Records">
                    <asp:MenuItem Text="District wise Schools" Value="MIS_School" NavigateUrl="~/MIS_School_public.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Subject wise Schools" Value="MIS_Subject" NavigateUrl="~/MIS_Subject_public.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="Search Teacher" Value="MIS_Teacher" NavigateUrl="~/MIS_Teacher_public.aspx"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Schools" Value="Schools" NavigateUrl="~/Schools_public.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Contact us" Value="Contact_us" NavigateUrl="~/Contact_us.aspx"></asp:MenuItem>
            </Items>
        </asp:Menu>
        </div>
        <br />
        <div class="slideshow-container">

            <div class="mySlides fade">
                <div class="numbertext">1 / 3</div>
                <img src="img/banner1.jpg" style="width: 100%; max-height: 250px;" />
                <div class="text">1</div>
            </div>

            <div class="mySlides fade">
                <div class="numbertext">2 / 3</div>
                <img src="img/banner2.jpg" style="width: 100%; max-height: 250px;" />
                <div class="text">2</div>
            </div>

            <div class="mySlides fade">
                <div class="numbertext">3 / 3</div>
                <img src="img/banner3.jpg" style="width: 100%; max-height: 250px;" />
                <div class="text">3</div>
            </div>

            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
            <a class="next" onclick="plusSlides(1)">&#10095;</a>

        </div>
        <br />

        <div style="text-align: center">
            <span class="dot" onclick="currentSlide(1)"></span>
            <span class="dot" onclick="currentSlide(2)"></span>
            <span class="dot" onclick="currentSlide(3)">&nbsp;<br />
            </span>
        </div>

        <br />
     
        <div>
            <asp:ScriptManager ID="SM1" runat="server">
        </asp:ScriptManager>
            <table style="width: 100%">
                <tr>
                    <td class="auto-style1">
                        <fieldset style="height:420px">
                            <legend><strong style="font-size:20px; color:#5d366f">Administration Login</strong></legend>
                        <div>
                            <br />
                            <asp:TextBox ID="txt1" runat="server" placeholder="User Id" class="hb"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox ID="txt2" runat="server" placeholder="Password" TextMode="Password" class="hb"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox ID="txtcap" runat="server" placeholder="Captcha" class="hb"></asp:TextBox>
                            <br />
                            <br />
                            <br />
                            <asp:UpdatePanel ID="UP1" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <%--<asp:TextBox ID="captchatext" runat="server"></asp:TextBox>--%>
                                               <asp:Image ID="imgcaptcha" runat="server" Height="62px" Width="169px" />
                                            </td>
                                            <td class="auto-style3">
                                                <asp:ImageButton ID="refreshbtn" runat="server" ImageUrl="~/img/refresh.png" Height="25px" Width="32px" OnClick="refreshbtn_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" Width="65px" />
                                    </td>
                                    <td>
                                        <input id="Reset1" type="reset" value="Reset" class="auto-style2" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Forgot_Password.aspx">Forgot Password?</asp:LinkButton> <br />
                            <br />
                            <asp:Label ID="label2" runat="server" Text=""></asp:Label>
                        <br />
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="New user?"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                            </div>
                            </fieldset>
                    </td>
                    
                    <td>
                        <div>
                              <fieldset style="height:420px">
                            <legend>
                                <strong style="font-size:20px; color:#5d366f">Recent News</strong>
                            </legend>
                            
                                  <marquee width="60%" direction="up" height="70%" scrollamount="4">
This is Apple's reply to Sundar Pichai's 'criticism' <br /> <br />

                                      India vs Ban Live: Bangladesh opt to bowl first
After losing their first practice game to New Zealand, Virat Kohli & Co will seek a perfect warm-up ahead of their World Cup opener against South Africa<br /> <br />
                                      NDA likely to get majority in RS by Nov 2020
                                      <br /> <br />
                                      21:54 | ED waiting for lenders' complaint to act against Jet, founder Naresh Goyal
                                      <br /> <br />
21:26 | GMR Warora Energy on verge of defaulting on over Rs 3,000-crore loans
                                      <br /> <br />
21:17 | Conclude probe into complaints against Hotel Leela by July 8: NCLT to Sebi 
                                      <br /><br />
21:12 | Airtel Africa plans to list on LSE, may use proceeds to cut $ 2-bn debt
                                       <br /><br />
21:08 | Oppo leads Apple, Samsung in race to win over youngsters in India
                                       <br /><br />
</marquee>
                        </fieldset>
                        </div>
                       

                    </td>

                </tr>

            </table>

        </div>


        <script>
            var slideIndex = 1;
            showSlides(slideIndex);

            function plusSlides(n) {
                showSlides(slideIndex += n);
            }

            function currentSlide(n) {
                showSlides(slideIndex = n);
            }

            function showSlides(n) {
                var i;
                var slides = document.getElementsByClassName("mySlides");
                var dots = document.getElementsByClassName("dot");
                if (n > slides.length) { slideIndex = 1 }
                if (n < 1) { slideIndex = slides.length }
                for (i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }
                for (i = 0; i < dots.length; i++) {
                    dots[i].className = dots[i].className.replace(" active", "");
                }
                slides[slideIndex - 1].style.display = "block";
                dots[slideIndex - 1].className += " active";
            }

            var slideIndex = 0;
            showSlides();

            function showSlides() {
                var i;
                var slides = document.getElementsByClassName("mySlides");
                for (i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }
                slideIndex++;
                if (slideIndex > slides.length) { slideIndex = 1 }
                slides[slideIndex - 1].style.display = "block";
                setTimeout(showSlides, 2000); // Change image every 2 seconds
            }

        </script>

        

    </form>

</body>
</html>
