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
            // Her bir sekme için obje oluşturulur.
            //
            Hazirlik hazirlik = new Hazirlik();
            Motor motor = new Motor();
            Yakit yakit = new Yakit();
            Guc guc = new Guc();
            Konfigurasyon konfigurasyon = new Konfigurasyon();
            Kamera kamera = new Kamera();

            //
            // HAZIRLIK İŞLEMLERİ
            //
            hazirlik.ClickHazirlikMenu();
            hazirlik.GorevHazirlikGuncelle("123");
            hazirlik.UcusHazirlikGuncelle("123");
            hazirlik.UcusHazirlikSıfırlaPopUp();

            // Her bir ana başlık sonrasında, alt başlıkların tekrar okunması için önceden tutulan alt başlıklar temizlenir
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

            // Her bir ana başlık sonrasında, alt başlıkların tekrar okunması için önceden tutulan alt başlıklar temizlenir
            MainHeaders.ResetSubHeaders();

            //
            // YAKIT İŞLEMLERİ
            //
            yakit.ClickYakitMenu();
            yakit.ClickYakitRadioButtons();
            yakit.ClickYakitYukle("50");

            // Her bir ana başlık sonrasında, alt başlıkların tekrar okunması için önceden tutulan alt başlıklar temizlenir
            MainHeaders.ResetSubHeaders();


            //
            // GÜÇ İŞLEMLERİ
            //
            guc.ClickGucMenu();
            guc.GucSistemBataryasi();
            guc.ClickGucAyarlarMenu();
            guc.GucAyarlarMenu();

            // Her bir ana başlık sonrasında, alt başlıkların tekrar okunması için önceden tutulan alt başlıklar temizlenir
            MainHeaders.ResetSubHeaders();


            kamera.ClickKameraHepsiYok();                       //Konfigurasyon işlemleri öncesi kamera testi
            //
            // KONFİGÜRASYON İŞLEMLERİ
            //
            konfigurasyon.ClickKonfigurasyonMenu();
            konfigurasyon.KonfigurasyonGonderHepsiYok();
            konfigurasyon.KonfigurasyonGonderListviewVar();
            konfigurasyon.KonfigurasyonListviewGoruntu();
            konfigurasyon.KonfigurasyonGonderPopUpVar();
            konfigurasyon.KonfigurasyonDurumBilgilendirme();
            konfigurasyon.KonfigurasyonGonderSekmeVar();

            kamera.ClickKameraListViewAcik();                   //Konfigurasyon işlemleri sonrası kamera testi
        }
    }
}


