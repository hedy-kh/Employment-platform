using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineJobPortal.User
{
    public partial class Company : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        String str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("Default.aspx");
            }
            
        }


        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                string type, concatQuery, imagePath = string.Empty;
                bool isValidToExecute = false;
                con = new SqlConnection(str);
                if (Request.QueryString["id"] != null)
                {
                    if (fCompanyLogo.HasFile)
                    {
                        if (Utils.IsValidExtension(fCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyImage= @CompanyImage,";
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }
                    query = @"Update Jobs set Title= @Title,NoOfPost=@NoOfPost,Description=@Description,Qualification=@Qualification,
                             Experience=@Experience,Specialization=@Specialization,LastDateToApply=@LastDateToApply,
                             Salary=@Salary,JobType=@JobType,CompanyName=@CompanyName," + concatQuery + @" Website=@Website,
                             Email=@Email,Address=@Address,Country=@Country,State=@State where JobId = @id ";
                    type = "updated";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", tJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", tNoOfPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", tDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", tQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", tExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", tSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", tLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", tSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", dlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", tCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", tWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", tEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", tAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", dlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", tState.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    if (fCompanyLogo.HasFile)
                    {
                        if (Utils.IsValidExtension(fCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fCompanyLogo.FileName;
                            fCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fCompanyLogo.FileName);
                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Plese select .jpg, .jpeg, .png file for Logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {

                        isValidToExecute = true;
                    }
                }
                else
                {
                    query = @"Insert into Jobs values(@Title,@NoOfPost,@Description,@Qualification,@Experience,@Specialization,@LastDateToApply,
                          @Salary,@JobType,@CompanyName,@CompanyImage,@Website,@Email,@Address,@Country,@State,@CreateDate ) ";
                    type = "Saved";
                    DateTime time = DateTime.Now;
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Title", tJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NoOfPost", tNoOfPost.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", tDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", tQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", tExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", tSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDateToApply", tLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", tSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", dlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", tCompany.Text.Trim());
                    cmd.Parameters.AddWithValue("@Website", tWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", tEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", tAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", dlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@State", tState.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", time.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (fCompanyLogo.HasFile)
                    {
                        if (Utils.IsValidExtension(fCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imagePath = "Images/" + obj.ToString() + fCompanyLogo.FileName;
                            fCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fCompanyLogo.FileName);
                            cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                            isValidToExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Plese select .jpg, .jpeg, .png file for Logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompanyImage", imagePath);
                        isValidToExecute = true;
                    }


                }
                if (isValidToExecute)
                {
                    con.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = "Job " + type + " and  sent to the admin ..!";
                        lblMsg.CssClass = "alert alert-success";
                        empty();
                    }
                    else
                    {
                        lblMsg.Text = "Cannot " + type + " the records, Please try again";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

        private void empty()
        {
            tJobTitle.Text = string.Empty;
            tNoOfPost.Text = string.Empty;
            tDescription.Text = string.Empty;
            tQualification.Text = string.Empty;
            tExperience.Text = string.Empty;
            tSpecialization.Text = string.Empty;
            tLastDate.Text = string.Empty;
            tSalary.Text = string.Empty;
            tCompany.Text = string.Empty;
            tWebsite.Text = string.Empty;
            tEmail.Text = string.Empty;
            tAddress.Text = string.Empty;
            tState.Text = string.Empty;
            dlJobType.ClearSelection();
            dlCountry.ClearSelection();
        }
    }
    
}