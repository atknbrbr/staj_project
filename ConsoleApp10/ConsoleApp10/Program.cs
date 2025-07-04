using ConsoleApp10.Pages;
using ConsoleApp10.Utils;

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
            konfigurasyon.ClickKonfigurasyonMenu(false);
            konfigurasyon.KonfigurasyonGonderHepsiYok();
            konfigurasyon.KonfigurasyonGonderListviewVar(false);
            konfigurasyon.KonfigurasyonListviewGoruntu();
            konfigurasyon.KonfigurasyonGonderPopUpVar();
            konfigurasyon.KonfigurasyonDurumBilgilendirme();
            konfigurasyon.KonfigurasyonGonderSekmeVar(false);

            kamera.ClickKameraListViewAcik();                   //Konfigurasyon işlemleri sonrası kamera testi
        }
    }
}


