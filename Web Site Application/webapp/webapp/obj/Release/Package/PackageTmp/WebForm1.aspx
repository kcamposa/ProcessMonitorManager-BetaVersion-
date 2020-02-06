<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webapp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estado de OneDrive</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <style>
    /* Remove the navbar's default margin-bottom and rounded borders */ 
    .navbar {
      margin-bottom: 0;
      border-radius: 0;    
    }
      
      body{
          background-color: #CFD8DC;
      }
    
    /* Set height of the grid so .sidenav can be 100% (adjust as needed) */
    .row.content {height: 450px}
    
    /* Set gray background color and 100% height */
    .sidenav {
      padding-top: 20px;
      background-color: #CFD8DC;
      height: 100%;
    }
    
    /* Set black background color, white text and some padding */
    footer {
      background-color: #F4D03F;
      color: white;
      padding: 15px;
    }
    
    /* On small screens, set height to 'auto' for sidenav and grid */
    @media screen and (max-width: 767px) {
      .sidenav {
        height: auto;
        padding: 15px;
      }
      .row.content {height:auto;} 
    }
    /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++*/

    .GridPager a,
.GridPager span {
    display: inline-block;
    padding: 0px 9px;
    margin-right: 4px;
    border-radius: 3px;
    border: solid 1px #c0c0c0;
    background: #e9e9e9;
    box-shadow: inset 0px 1px 0px rgba(255,255,255, .8), 0px 1px 3px rgba(0,0,0, .1);
    font-size: .875em;
    font-weight: bold;
    text-decoration: none;
    color: #717171;
    text-shadow: 0px 1px 0px rgba(255,255,255, 1);
}

.GridPager a {
    background-color: #f5f5f5;
    color: #969696;
    border: 1px solid #969696;
}

.GridPager span {

    background: #616161;
    box-shadow: inset 0px 0px 8px rgba(0,0,0, .5), 0px 1px 0px rgba(255,255,255, .8);
    color: #f0f0f0;
    text-shadow: 0px 0px 3px rgba(0,0,0, .5);
    border: 1px solid #3AC0F2;
}
    

  </style>
</head>
<body>
<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>                        
      </button>
      <a class="navbar-brand" href="#">SUR QUIMICA</a>
    </div>
  </div>
</nav>
    <!--<div class="container">-->
   <form id="Form1" runat="server">
<div class="container-fluid text-center">    
  <div class="row content">
    <div class="col-sm-3 sidenav">
      <div class="well">
          <h4>Equipos conectados</h4>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="computerName" DataSourceID="SqlDataSource2" CssClass="table table-bordered bs-table" >
            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                <Columns>
                    <asp:BoundField DataField="computerName" HeaderText="Nombre equipo" ReadOnly="True" SortExpression="computerName" />
                    <asp:CheckBoxField DataField="computerStatus" HeaderText="Estado" SortExpression="computerStatus" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OneDriveProccessesConnectionString2 %>" SelectCommand="SELECT * FROM [Computers] WHERE [computerStatus] &lt;&gt; '0';"></asp:SqlDataSource>
      </div>
    </div>
    <div class="col-sm-6 text-text"> 
      <h1 style="text-align: left">Estado de los procesos de OneDrive</h1>
        <hr />         
        <div class="col-sm-12 sidenav">          
      <div class="well">
          <h4>Todos los equipos</h4> 
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="computerName" DataSourceID="SqlDataSource1" CssClass="table table-bordered bs-table">
            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                <Columns>
                    <asp:BoundField DataField="computerName" HeaderText="Nombre equipo" ReadOnly="True" SortExpression="computerName" />
                    <asp:CheckBoxField DataField="computerStatus" HeaderText="Estado" SortExpression="computerStatus" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OneDriveProccessesConnectionString %>" SelectCommand="SELECT [computerName], [computerStatus] FROM [Computers]"></asp:SqlDataSource>
      </div>
    </div>
    </div>    
    <div class="col-sm-3 sidenav">
      <div class="well">
          <h4>Equipos no conectados</h4>
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="computerName" DataSourceID="SqlDataSource3" CssClass="table table-bordered bs-table">
            <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />
                <Columns>
                    <asp:BoundField DataField="computerName" HeaderText="Nombre equipo" ReadOnly="True" SortExpression="computerName" />
                    <asp:CheckBoxField DataField="computerStatus" HeaderText="Estado" SortExpression="computerStatus" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:OneDriveProccessesConnectionString3 %>" SelectCommand="SELECT * FROM [Computers] WHERE [computerStatus] &lt;&gt; '1';"></asp:SqlDataSource>
      </div>
    </div>      
  </div>
    </div>
        </form>
    <!--</div>-->
</body>
</html>
