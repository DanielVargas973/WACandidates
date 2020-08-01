using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WACandidates.Classes.APIConsummer;
using WACandidates.Classes.Model;

namespace WACandidates
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CLFramework.DataSource = CreateData(3);
                CLCandidates.DataSource = CreateData(3);
                CLFramework.Enabled = false;
                CLCandidates.Enabled = false;
            }
        }

        protected void DDLOptionsLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLOptionsLanguage.SelectedValue == "1") //JAVA
            {
                CLFramework.DataSource = CreateData(1);
                CLFramework.DataBind();
                CLFramework.Enabled = true;
            }
            else if (DDLOptionsLanguage.SelectedValue == "2") // .NET 
            {
                CLFramework.DataSource = CreateData(2);
                CLFramework.DataBind();
                CLFramework.Enabled = true;
            }
            else
            {
                CLFramework.DataSource = CreateData(3);
                CLFramework.DataBind();
                CLFramework.Enabled = false;
            }
        }
        protected string[] CreateData(int language)
        {
            string[] lista1 = new string[5];
            switch (language)
            {
                case 1:
                    lista1[0] = " 1 - Java Server Pages";
                    lista1[1] = " 2 - Java Serevr Faces";
                    lista1[2] = " 3 - Enterprise Java Beans";
                    lista1[3] = " 4 - Java Persistence API";
                    lista1[4] = " 5 - Java Messaging Services";
                    break;
                case 2:
                    lista1[0] = " 1 - ASP.NET";
                    lista1[1] = " 2 - MVVM";
                    lista1[2] = " 3 - ADO.NET";
                    lista1[3] = " 4 - Entity Framework";
                    lista1[4] = " 5 - LinQ";
                    break;
                case 3:
                    lista1[0] = "Selecciona un lenguaje";
                    break;
            }
            return lista1;

        }

        protected void BTNCadidates_Click(object sender, EventArgs e)
        {
            CandidateConsummerService candidateConsummerService = new CandidateConsummerService();
            CandidateModel[] candidateModel = candidateConsummerService.GetCandidatesAsync().Result;
            string[] candidates = new string[20];
            bool snData = false;
            for (int count = 0; count < CLFramework.Items.Count; count++)
            {
                if (CLFramework.Items[count].Selected && snData == false)
                {
                    if (CLFramework.Items[count].Text.Contains("1") || CLFramework.Items[count].Text.Contains("3")
                        || CLFramework.Items[count].Text.Contains("5"))
                    {
                        candidates = ShowCandidateModel(1, candidateModel);
                        snData = true;
                    }
                    else
                    {
                        //Tecnologias pares
                        candidates = ShowCandidateModel(2, candidateModel);
                        snData = true;
                    }
                }
            }
            CLCandidates.DataSource = candidates;
            CLCandidates.DataBind();
            CLCandidates.Enabled = true;
        }
        protected string[] ShowCandidateModel(int number, CandidateModel[] candidateModel)
        {
            try
            {
                string[] newCandidateModel = new string[6];
                int countString = 0;
                for (int count = 0; count < candidateModel.Length; count++)
                {
                    if (candidateModel[count] != null)
                    {
                        if (number % 2 == 0 && candidateModel[count].id % 2 == 0)
                        {
                            newCandidateModel[countString] = candidateModel[count].name + " " +
                               candidateModel[count].email + " - " + candidateModel[count].address.street;
                            countString++;
                        }
                        else if (number % 2 != 0 && candidateModel[count].id % 2 != 0)
                        {
                            newCandidateModel[countString] = candidateModel[count].name + " " +
                               candidateModel[count].email + " - " + candidateModel[count].address.street;
                            countString++;
                        }
                    }
                }
                for (int i = 0; i < newCandidateModel.Length; i++)
                {
                    if (newCandidateModel[i] == null)
                    {
                        newCandidateModel[i] = "";
                    }
                }
                return newCandidateModel;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}