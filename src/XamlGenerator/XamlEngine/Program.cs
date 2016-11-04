using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamlGenerator.Form;
using System.IO;

namespace XamlGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
         //     MasterDetailsForm2 form = new MasterDetailsForm2();
    GridDataFormTelerik form = new GridDataFormTelerik();
    //     MasterDetailGridForm form = new MasterDetailGridForm();
           form.Save();
            //for (int i = 1300; i < 1451; i++)
            //{
            //    Console.WriteLine(i);
            //}


        }
        public static void xaml()
        { 
            #region  FinalTemplate
            string temp=
            "<sdk:Page	xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
            "	xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" \n" +
            "	xmlns:d=\"http://schemas.microsoft.com/expression/blend/2008\"\n" +
            "	xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
            "	mc:Ignorable=\"d\"\n" +
            "	xmlns:sdk=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation/sdk\"	x:Class=\"NewSiteTemplate.Page1\" \n" +
            "	Title=\"Page1 Page\"\n" +
            "	d:DesignWidth=\"640\" d:DesignHeight=\"480\">\n" +
            "        <Grid FlowDirection=\"RightToLeft\" x:Name=\"LayoutRoot\">\n" +
            "		<Grid.ColumnDefinitions>\n" +
            "			<ColumnDefinition Width=\"600*\" />\n" +
            "			<ColumnDefinition Width=\"300*\"/>\n" +
            "		</Grid.ColumnDefinitions>\n" +
            "		<Grid FlowDirection=\"RightToLeft\" Grid.Column=\"0\">\n" +
            "			<Grid.RowDefinitions>\n" +
            "				<RowDefinition Height=\"Auto\" />\n" +
            "				<RowDefinition Height=\"Auto\" />\n" +
            "               <RowDefinition Height=\"Auto\"/>\n" +
            "			</Grid.RowDefinitions>\n" +
            "            <!-- \n" +
            "                Here is the place for GridView View and Buttons\n" +
            "            -->\n" +
            "            <Border Grid.Row=\"0\" Style=\"{StaticResource TopGridViewBorder}\" >\n" +
            "                <Grid></Grid>\n" +
            "            </Border>\n" +
            "           \n" +
            "           <Border Grid.Row=\"1\" Style=\"{StaticResource MiddleGridViewBorder}\">\n" +
            "\n" +
            "           </Border>\n" +
            "                <Grid></Grid>\n" +
            "            <Border Grid.Row=\"2\" Style=\"{StaticResource BottomGridViewBorder}\">\n" +
            "                <Grid></Grid>\n" +
            "            </Border>\n" +
            "		</Grid>\n" +
            "		<Grid Grid.Column=\"1\" FlowDirection=\"RightToLeft\">			\n" +
            "			<Grid.RowDefinitions>\n" +
            "                <RowDefinition Height=\"Auto\" />\n" +
            "                <RowDefinition Height=\"Auto\" />\n" +
            "                <RowDefinition Height=\"Auto\"/>\n" +
            "			</Grid.RowDefinitions>\n" +
            "            <!-- \n" +
            "                Here is the place for DataForm                     \n" +
            "            -->\n" +
            "\n" +
            "            <Border Grid.Row=\"0\" Style=\"{StaticResource TopDataFormBorder}\" >\n" +
            "                <Grid></Grid>\n" +
            "            </Border>\n" +
            "       \n" +
            "            <Border Grid.Row=\"1\" Style=\"{StaticResource MiddleDataFormBorder}\">\n" +
            "                <Grid></Grid>\n" +
            "            </Border>\n" +
            "    \n" +
            "            <Border Grid.Row=\"2\" Style=\"{StaticResource BottomDataFormBorder}\">\n" +
            "                \n" +
            "                <Grid></Grid>\n" +
            "           </Border>"+
            "        </Grid>\n" +
            "        </Grid>\n" +
            " \n" +
            "</sdk:Page>\n";

            #endregion 

        }
    }
}
