using ConsoleApp10.Pages;
using ConsoleApp10.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Winium.Cruciatus.Extensions;
using System.Windows.Automation;
using System.Windows.Forms;
using Winium.Cruciatus;
using Winium.Cruciatus.Elements;
using Winium.Cruciatus.Core;

//using Winium.Cruciatus.Core;
using Winium.Cruciatus.Extensions;
using System.Runtime.InteropServices;

namespace ConsoleApp10
{
    public class Program
    {
        static void Main(string[] args)
        {
            //
            // Her bir sekme için objeler oluşturulur.
            //
            Hazirlik hazirlik = new Hazirlik();
            Motor motor = new Motor();
            Yakit yakit = new Yakit();
            Guc guc = new Guc();
            Konfigurasyon konfigurasyon = new Konfigurasyon();

            //
            // HAZIRLIK İŞLEMLERİ
            //
            hazirlik.ClickHazirlikMenu();
            hazirlik.GorevHazirlikGuncelle("123");
            hazirlik.UcusHazirlikGuncelle("123");
            hazirlik.UcusHazirlikSıfırlaPopUp();

            MainHeaders.ResetSubHeaders();


            //
            // MOTOR İŞLEMLERİ
            //
            motor.ClickMotorMenu();
            motor.ClickMotorGostergeler();
            motor.ClickMotorGostergelerTablo();
            motor.ClickMotorGostergelerSecim("irtifa_radiobuton");
            motor.ClickMotorGostergelerMotorAyarlari();
            motor.ClickMotorDiagnostikMenu();
            motor.ClickMotorAyarlarMenu();

            MainHeaders.ResetSubHeaders();

            //
            // YAKIT İŞLEMLERİ
            //
            yakit.ClickYakitMenu();
            yakit.ClickYakitRadioButtons();
            yakit.ClickYakitYukle("50");

            MainHeaders.ResetSubHeaders();


            //
            // GÜÇ İŞLEMLERİ
            //
            guc.ClickGucMenu();
            guc.GucSistemBataryasi();
            guc.ClickGucAyarlarMenu();
            guc.GucAyarlarMenu();

            MainHeaders.ResetSubHeaders();

            //
            // GÜÇ İŞLEMLERİ
            //
            konfigurasyon.ClickKonfigurasyonMenu();
            konfigurasyon.ClickKameraHepsiYok();
            konfigurasyon.KonfigurasyonGonderHepsiYok();
            konfigurasyon.ClickKameraListViewAcik();
            konfigurasyon.KonfigurasyonGonderListviewVar();
            konfigurasyon.KonfigurasyonListviewGoruntu();
            konfigurasyon.KonfigurasyonGonderPopUpVar();
            konfigurasyon.KonfigurasyonDurumBilgilendirme();
            konfigurasyon.KonfigurasyonGonderSekmeVar();
        }
    }
}


