using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class TTN
    {
        public string Sentence { get; set; }
    }

    public class Success
    {
        public string Output { get; private set; }
        public string Stage(string Sentence)
        {
            
            var liste = new Dictionary<string, int>();
            liste.Add("bir", 1);
            liste.Add("iki", 2);
            liste.Add("üç", 3);
            liste.Add("dört", 4);
            liste.Add("beş", 5);
            liste.Add("altı", 6);
            liste.Add("yedi", 7);
            liste.Add("sekiz", 8);
            liste.Add("dokuz", 9);
            liste.Add("on", 10);
            liste.Add("yirmi", 20);
            liste.Add("otuz", 30);
            liste.Add("kırk", 40);
            liste.Add("elli", 50);
            liste.Add("altmış", 60);
            liste.Add("yetmiş", 70);
            liste.Add("seksen", 80);
            liste.Add("doksan", 90);
            liste.Add("yüz", 100);
            liste.Add("bin", 1000);
            liste.Add("yüz bin", 100000);
            string yeni = Sentence.ToLower();
            string cumle = "";
            string[] bol1 = yeni.Split(' ');
            int sonuc = 0;
            Boolean yuzdenSonra = false;
            int devamSayac = 0;
            int yuzbinler = 0;
            int binler = 0;
            int yuzler = 0;

            for (int i = 0; i < bol1.Length; i++) 
            {
                foreach (string key in liste.Keys) 
                {

                    if (bol1[i].Contains(key)) 
                    {
                        string yeniKey = " " + key + " "; // key bulursan başına ve sonuna boşluk koy
                        bol1[i] = bol1[i].Replace(key, yeniKey);

                    }
                }
                cumle = cumle + bol1[i] + " ";
            }
            cumle = cumle.Replace("  ", " "); // 2 boşluk olursa tek boşluk yap
            string[] bol2 = cumle.Split(' ');
            cumle = "";

            for (int i = 0; i < bol2.Length; i++)
            {
                foreach (int value in liste.Values)
                {

                    if (bol2[i].Contains(Convert.ToString(value)))
                    {
                        string yeniValue = liste.FirstOrDefault(x => x.Value == Convert.ToInt32(bol2[i])).Key;
                        bol2[i] = yeniValue;

                    }
                }
                cumle = cumle + bol2[i] + " ";
            }

            cumle = cumle.Replace("  ", " ");
            string[] bol = cumle.Split(' ');
            cumle = "";

            for (int i = 0; i < bol.Length; i++)
            {
                if (liste.ContainsKey(bol[i]))
                {
                    if (bol[i].Equals("bin"))
                    {
                        if (yuzdenSonra)
                        {
                            sonuc = (yuzler + sonuc) * 1000;
                            devamSayac = 0;
                            binler = sonuc;
                            sonuc = 0;
                            yuzler = 0;
                        }
                        else
                        {
                            if (devamSayac == 0)
                            {
                                sonuc = sonuc + 1000;
                                binler = sonuc;
                                sonuc = 0;
                                devamSayac = 0;
                            }
                            else
                            {
                                sonuc = sonuc * 1000;
                                devamSayac = 0;
                                binler = sonuc;
                                sonuc = 0;
                            }

                        }

                    }
                    else if (bol[i].Equals("yüz"))
                    {
                        yuzdenSonra = true;
                        if (devamSayac == 0)
                        {
                            sonuc = sonuc + 100;
                            yuzler = sonuc;
                            sonuc = 0;
                            devamSayac = 0;
                        }
                        else
                        {
                            sonuc = sonuc * 100;
                            yuzler = sonuc;
                            sonuc = 0;
                            devamSayac = 0;
                        }

                    }
                    else
                    {
                        sonuc = sonuc + liste[bol[i]];
                    }

                    devamSayac++;
                    if (i == bol.Length - 1)
                    {
                        if (liste.ContainsKey(bol[i]))
                        {
                            sonuc = yuzbinler + binler + yuzler + sonuc;
                            cumle = Convert.ToString(sonuc);
                            this.Output = cumle;
                        }
                    }
                }
                else
                {
                    sonuc = yuzbinler + binler + yuzler + sonuc;
                    if (sonuc != 0)
                    {
                        cumle = cumle + Convert.ToString(sonuc) + " " + bol[i] + " ";
                        this.Output = cumle;
                    }
                    else
                    {
                        cumle = cumle + bol[i] + " ";
                        this.Output = cumle;

                    }

                    devamSayac = 0;
                    sonuc = 0;
                    yuzbinler = 0;
                    binler = 0;
                    yuzler = 0;

                }

            }
            return this.Output;
            
        }
    }
}
