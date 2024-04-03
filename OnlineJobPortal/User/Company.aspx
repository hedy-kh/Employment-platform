<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="OnlineJobPortal.User.Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
         <asp:Label ID="lblMsg" runat="server"></asp:Label>   
            <h3 class="text-center"> <% Response.Write(Session["title"]); %> </h3>
            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="tJobTitle" style="font-weight: 600"> Job Title</label>
                    <asp:TextBox ID="tJobTitle" runat="server" CssClass="form-control"  placeholder=" Ex.Web Developer , App Developer" required >
                    </asp:TextBox>

                </div>

                <div class="col-md-6 pt-3">
                    <label for="tNoOfPost" style="font-weight: 600"> Number Of Post</label>
                    <asp:TextBox ID="tNoOfPost" runat="server" CssClass="form-control"  placeholder=" Enter Number Of Position"  
                         TextMode="Number" required>
                    </asp:TextBox>

                </div>

            </div>
             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="tDescription" style="font-weight: 600"> Description</label>
                    <asp:TextBox ID="tDescription" runat="server" CssClass="form-control"  placeholder=" Enter Job Description"  
                        TextMode="MultiLine" required >
                    </asp:TextBox>

                </div>

                 </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="tQualification" style="font-weight: 600"> Qualification/Education Required</label>
                    <asp:TextBox ID="tQualification" runat="server" CssClass="form-control"  placeholder=" Ex. Licence degree"  required >
                    </asp:TextBox>

                </div>

                <div class="col-md-6 pt-3">
                    <label for="tExperience" style="font-weight: 600"> Experience Required</label>
                    <asp:TextBox ID="tExperience" runat="server" CssClass="form-control"  placeholder=" Ex. 2 Years "  
                          required>
                    </asp:TextBox>

                </div>

            </div>

             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="tSpecialization" style="font-weight: 600"> Specialization Required</label>
                    <asp:TextBox ID="tSpecialization" runat="server" CssClass="form-control"  placeholder=" Enter Specialization" 
                         TextMode="MultiLine" required >
                    </asp:TextBox>

                </div>

                <div class="col-md-6 pt-3">
                    <label for="tLastDate" style="font-weight: 600"> Last Date To Apply</label>
                    <asp:TextBox ID="tLastDate" runat="server" CssClass="form-control"  placeholder=" Enter Last Date To Apply "  
                          TextMode="Date" required>
                    </asp:TextBox>

                </div>

            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="tSalary" style="font-weight: 600"> Salary</label>
                    <asp:TextBox ID="tSalary" runat="server" CssClass="form-control"  placeholder=" Ex . 2000$ Per Month"  TextMode="Number" required >
                    </asp:TextBox>

                </div>

                <div class="col-md-6 pt-3">
                    <label for="dlJobType" style="font-weight: 600"> Job Type </label>
                    <asp:DropDownList ID="dlJobType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0"> Select Job Type</asp:ListItem>
                        <asp:ListItem>Full Time</asp:ListItem>
                        <asp:ListItem>Part Time</asp:ListItem>
                        <asp:ListItem>Remote</asp:ListItem>
                        <asp:ListItem>Freelance</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Job Type Is Required" ForeColor="Red"
                         ControlToValidate="dlJobType" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                </div>

            </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="tCompany" style="font-weight: 600"> Company</label>
                    <asp:TextBox ID="tCompany" runat="server" CssClass="form-control"  placeholder=" Enter Company Name"  required >
                    </asp:TextBox>

                </div>

                <div class="col-md-6 pt-3">
                    <label for="fCompanyLogo" style="font-weight: 600" > Company Logo   </label>
                     <asp:FileUpload ID="fCompanyLogo" runat="server" CssClass="form-control"  ToolTip=".jpg, .jpeg, .png extension only"/>
                    

                </div>

            </div>

               <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-6 pt-3">
                    <label for="tWebsite" style="font-weight: 600"> Website</label>
                    <asp:TextBox ID="tWebsite" runat="server" CssClass="form-control"  placeholder=" Enter Website" 
                         TextMode="Url" >
                    </asp:TextBox>

                </div>

                <div class="col-md-6 pt-3">
                    <label for="tEmail" style="font-weight: 600"> Email</label>
                    <asp:TextBox ID="tEmail" runat="server" CssClass="form-control"  placeholder=" Enter Email "  
                          TextMode="Email" >
                    </asp:TextBox>

                </div>

            </div>

             <div class="row mr-lg-5 ml-lg-5 mb-3">
                <div class="col-md-12 pt-3">
                    <label for="tAddress" style="font-weight: 600"> Address</label>
                    <asp:TextBox ID="tAddress" runat="server" CssClass="form-control"  placeholder=" Enter Job Address"  
                        TextMode="MultiLine" required >
                    </asp:TextBox>

                </div>

                 </div>

               <div class="row mr-lg-5 ml-lg-5 mb-0">
                <div class="col-md-6 pt-3">
                    <label for="tWebsite" style="font-weight: 600"> Country</label>
                    <asp:DropDownList ID="dlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-contact w-100"
                         AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                           <asp:ListItem Value="0">Select Country</asp:ListItem>
                        </asp:DropDownList>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Country is required"
                           ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" 
                            ControlToValidate="dlCountry"></asp:RequiredFieldValidator>
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" 
                            SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>

                

                <div class="col-md-6 pt-3">
                    <label for="tState" style="font-weight: 600"> State</label>
                    <asp:TextBox ID="tState" runat="server" CssClass="form-control"  placeholder=" Enter State " required>
                    </asp:TextBox>

                </div>

            </div>
           </div>

            <div class="row mr-lg-5 ml-lg-5 mb-3 pt-4">

               <div class="col-md-3 col-md-offset-2 mb-3">

                   
                           
                   <asp:Button ID="ButtonSend" runat="server" CssClass="btn btn-primary btn-block" BackColor="#7200cf" Text=" Send Job request"
                        OnClick="ButtonSend_Click"    />

               </div>

           </div>
      
           </div>
</asp:Content>
