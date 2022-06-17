using EldenRing.Logic.DataAccess;
using EldenRing.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace EldenRingPNJ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Classes> list;
        List<Weapons> list2;
        List<Shields> list3;
        int i = 0;
        Double hps = 0;
        Double fps = 0;
        Double staminas = 0;
        Double dmgStr = 0;
        Double dmgDex = 0;
        Double dmgFaith =0;
        Double dmgArc = 0;
        Double dmgInt = 0;
        Double dmgLigth = 0;
        Double dmgMind = 0;
        Double attackAmountPhy;
        Double attackAmountMag;
        Double attackAmountFire;
        Double attackAmountLigth;
        Double attackAmountHoly;
        Double DfcStr = 0;
        Double DfcDex = 0;
        Double DfcFaith =0;
        Double DfcArc = 0;
        Double DfcInt = 0;
        Double DfcLigth = 0;
        Double DfcMind = 0;
        Double DefenceAmountPhy;
        Double DefenceAmountMag;
        Double DefenceAmountFire;
        Double DefenceAmountLigth;
        Double DefenceAmountHoly;
       Boolean scaleStr  =false ;
       Boolean scaleDex = false;
       Boolean scaleArc = false;
        Boolean scaleFaith = false;
       Boolean scaleInt  =false ;
       Boolean scaleFire =false ;
       Boolean scaleLigth=false  ;
       Boolean scaleMind =false  ;

        Boolean scaleStrdfc=false ;
        Boolean scaleDexDfc=false ;
        Boolean scaleArcdfc=false ;
        Boolean scaleFaithdfc = false ;
        Boolean scaleIntdfc=false ;
        Boolean scaleMinddfc=false ;
        int level;


        Double dmgIncrement = 0;
            public MainWindow()
        {
            list = CRUD.Get(CRUD.hazConexion());
            list2 = CRUD.GetWeapons(CRUD.hazConexion());
            list3 = CRUD.GetShields(CRUD.hazConexion());
            InitializeComponent();
            start();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
         

        }

        private void start()
        {
            imgDynamic.Source = new BitmapImage(new Uri(list.ElementAt(0).Image));
            foreach (var item in list)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item.Name;
                cbselect.Items.Add(comboBoxItem);

            }
            foreach (var item in list2)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item.Name;
                cbWeapons.Items.Add(comboBoxItem);

            }
            foreach (var item in list3)
            {
                var comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item.Name;
                cbShields.Items.Add(comboBoxItem);

            }

        }

        private void cbselect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in list)
            {
                if (item.Name.Equals(((ComboBoxItem)cbselect.SelectedItem).Content))
                {

                    imgDynamic.Source = new BitmapImage(new Uri(item.Image));
                    level= Int32.Parse(item.Stats.Level);

                    lvl.Content = level;
                    vigor.Text = item.Stats.Vigor;
                    mind.Text = item.Stats.Mind;
                    endurance.Text = item.Stats.Endurance;
                    strength.Text = item.Stats.Strength;
                    dexterity.Text = item.Stats.Dexterity;
                    inteligence.Text = item.Stats.Intelligence;
                    faith.Text = item.Stats.Faith;
                    arcane.Text = item.Stats.Arcane;
                    hps = item.Hp;
                    fps = item.Fp;
                    staminas = item.Stamina;
                    calculoHP(item.Stats.Vigor, item.Stats.Strength);
                    calculoFP(item.Stats.Mind);
                    calculoStamina(item.Stats.Vigor, item.Stats.Strength);
                }
            }

        }
        public void calculoHP(string vigor, string Strength)
        {

            Double life = Math.Round(hps + (Int32.Parse(vigor) * 15.75) + (Int32.Parse(Strength) * 5.75));
            hp.Content = life;

        }
        public void calculoFP(string mind)
        {
            Double mana = Math.Round(fps + (Int32.Parse(mind) * 12.75));
            fp.Content = mana;
        }
        public void calculoStamina(string Endurance, string Strength)
        {
            Double stam = Math.Round(staminas + (Int32.Parse(Endurance) * 10.75) + (Int32.Parse(Strength) * 5.75));
            stamina.Content = stam;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(vigor.Text);
            i++;
            vigor.Text = i.ToString();
            level++;
            lvl.Content =level ;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(vigor.Text);
            i--;
            vigor.Text = i.ToString();
                 level--;
            lvl.Content = level;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(mind.Text);
            i--;
            mind.Text = i.ToString();
            level--;
            lvl.Content = level;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(mind.Text);
            i++;
            mind.Text = i.ToString();
            level++;
            lvl.Content = level;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(endurance.Text);
            i--;
            endurance.Text = i.ToString();
            lvl.Content = level--;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(endurance.Text);
            i++;
            endurance.Text = i.ToString();
            level++;
            lvl.Content = level;

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

            int i = Int32.Parse(strength.Text);
            i--;
            strength.Text = i.ToString();
            level--;
            lvl.Content = level;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(strength.Text);
            i++;
            strength.Text = i.ToString();
            level++;
            lvl.Content = level;

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(dexterity.Text);
            i--;
            dexterity.Text = i.ToString();
            level--;
            lvl.Content = level;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(dexterity.Text);
            i++;
            dexterity.Text = i.ToString();
            level++;
            lvl.Content = level;

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(inteligence.Text);
            i--;
            inteligence.Text = i.ToString();
            level--;
            lvl.Content = level;

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(inteligence.Text);
            i++;
            inteligence.Text = i.ToString();
            level++;
            lvl.Content = level;

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(faith.Text);
            i--;
            faith.Text = i.ToString();
            level--;
            lvl.Content = level;


        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(faith.Text);
            i++;
            faith.Text = i.ToString();
            level++;
            lvl.Content = level;

        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(arcane.Text);
            i--;
            arcane.Text = i.ToString();
            level--;
            lvl.Content = level;

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            int i = Int32.Parse(arcane.Text);
            i++;
            arcane.Text = i.ToString();
            level++;
            lvl.Content = level;

        }

        private void mind_TextChanged(object sender, TextChangedEventArgs e)
        {


            int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);
            Double life = Math.Round(fps + (mindAmount * 12.75));
            fp.Content = life;
        }

        private void endourance_TextChanged(object sender, TextChangedEventArgs e)
        {
            int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
            int enduranceAmount = endurance.Text == "" ? 0 : Int32.Parse(endurance.Text);
            Double sta = Math.Round(staminas + (enduranceAmount * 10.75) + (strengthAmount * 3.75));
            stamina.Content = sta;

        }

        private void strength_TextChanged(object sender, TextChangedEventArgs e)
        {
            int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
            int vigorAmount = vigor.Text == "" ? 0 : Int32.Parse(vigor.Text);
            int enduranceAmount = endurance.Text == "" ? 0 : Int32.Parse(endurance.Text);
            Double sta = Math.Round(staminas + (enduranceAmount * 10.75) + (strengthAmount * 3.75));
            stamina.Content = sta;
            Double life = Math.Round(hps + (vigorAmount * 15.75) + (strengthAmount * 5.75));
            hp.Content = life;
            if (scaleStr)
            {
                dmgStr = Math.Round((strengthAmount * 3.55));
                DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
            }
            if (scaleStrdfc) {
                DfcStr = Math.Round((strengthAmount * 5.55));
                DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);
            }

        }
        private void vigor_TextChanged(object sender, TextChangedEventArgs e)
        {
            int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
            int vigorAmount = vigor.Text == "" ? 0 : Int32.Parse(vigor.Text);
            Double life = Math.Round(hps + (vigorAmount * 15.75) + (strengthAmount * 5.75));
            hp.Content = life;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach (var item in list2)
            {
                if (item.Name.Equals(((ComboBoxItem)cbWeapons.SelectedItem).Content))
                {

                    imgWeapon.Source = new BitmapImage(new Uri(item.Image));
                    cbWeapons.Visibility = Visibility.Hidden;
                    foreach (var attack in item.Attack)
                    {
                        if (attack.Name.Equals("Phy"))
                        {
                            attackAmountPhy = attack.Amount;
                            DmgPhysStrike.Content = attackAmountPhy;
                            DmgTotalStrike.Content = attackAmountPhy;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Str"))
                                {
                                    scaleStr = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        dmgStr = Math.Round((strengthAmount * 3.55));
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr+ dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        dmgStr = Math.Round((strengthAmount * 3.55));                                        
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);
                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        dmgStr = Math.Round((strengthAmount * 3.55));                                        
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);
                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        dmgStr = Math.Round((strengthAmount * 3.55));                                        
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);
                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        dmgStr = Math.Round((strengthAmount * 3.55));                                       
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        dmgStr = Math.Round((strengthAmount * 3.55));
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);
                                    }
                                }
                                if (scale.Name.Equals("Dex"))
                                {
                                    scaleDex = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        dmgDex = Math.Round((dexterityAmount * 3.55));
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + dmgDex;

                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        dmgDex = Math.Round((dexterityAmount * 3.55));                                  
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);


                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        dmgDex = Math.Round((dexterityAmount * 3.55));
                                        
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        dmgDex = Math.Round((dexterityAmount * 3.55));
                                        
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);


                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        dmgDex = Math.Round((dexterityAmount * 3.55));
                                        
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        dmgDex = Math.Round((dexterityAmount * 3.55));
                                    
                                        DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);
                                        DmgTotalStrike.Content = attackAmountPhy + (dmgStr + dmgDex);


                                    }
                                }
                            }

                        }
                        if (attack.Name.Equals("Mag"))
                        {
                            attackAmountMag = attack.Amount;
                            DmgMagiStrike.Content = attackAmountMag;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Int"))
                                {
                                    scaleInt = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt+dmgArc);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }
                                }
                                if (scale.Name.Equals("Arc"))
                                {
                                    scaleArc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        dmgArc = Math.Round((arcaneAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " +(dmgInt+ dmgArc);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        dmgArc = Math.Round((arcaneAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        dmgArc = Math.Round((arcaneAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        dmgArc = Math.Round((arcaneAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {

                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        dmgArc = Math.Round((arcaneAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        dmgArc = Math.Round((arcaneAmount * 3.55));
                                        DmgMagiStrike.Content = attackAmountMag + " + " + (dmgInt + dmgArc);
                                    }
                                }
                            }
                        }
                        if (attack.Name.Equals("Fire"))
                        {
                            attackAmountFire = attack.Amount;
                            DmgFireStrike.Content = attackAmountFire;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Int"))
                                {
                                    scaleInt = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round( (intelligenceAmount * 3.55));
                                        DmgFireStrike.Content = attackAmountFire + " + " + dmgInt;
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgFireStrike.Content = attackAmountFire + " + " + dmgInt;

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgFireStrike.Content = attackAmountFire + " + " + dmgInt;
                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgFireStrike.Content = attackAmountFire + " + " + dmgInt;
                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgFireStrike.Content = attackAmountFire + " + " + dmgInt;
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        dmgInt = Math.Round((intelligenceAmount * 3.55));
                                        DmgFireStrike.Content = attackAmountFire + " + " + dmgInt;

                                    }
                                }
                            }
                        }
                        if (attack.Name.Equals("Ligt"))
                        {
                            attackAmountLigth = attack.Amount;
                            DmgLightStrike.Content = attackAmountLigth;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Fai"))
                                {
                                    scaleFaith = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int ligthAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);

                                        dmgFaith = Math.Round( (ligthAmount * 3.55));
                                        DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int ligthAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);

                                        dmgFaith = Math.Round((ligthAmount * 3.55));
                                        DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {

                                        int ligthAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);

                                        dmgFaith = Math.Round((ligthAmount * 3.55));
                                        DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {

                                        int ligthAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);

                                        dmgFaith = Math.Round((ligthAmount * 3.55));
                                        DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;
                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {

                                        int ligthAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);

                                        dmgFaith = Math.Round((ligthAmount * 3.55));
                                        DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {

                                        int ligthAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);

                                        dmgFaith = Math.Round((ligthAmount * 3.55));
                                        DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;
                                    }
                                }
                            }
                        }
                        if (attack.Name.Equals("Holy"))
                        {
                            attackAmountHoly = attack.Amount;
                            DmgHolyStrike.Content = attackAmountHoly;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Min"))
                                {

                                    scaleMind = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        dmgMind = Math.Round( (mindAmount * 3.55));
                                        DmgHolyStrike.Content = attackAmountHoly + " + " + dmgMind;
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        dmgMind = Math.Round( (mindAmount * 3.55));
                                        DmgHolyStrike.Content = attackAmountHoly + " + " + dmgMind;

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        dmgMind = Math.Round((mindAmount * 3.55));
                                        DmgHolyStrike.Content = attackAmountHoly + " + " + dmgMind;

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        dmgMind = Math.Round((mindAmount * 3.55));
                                        DmgHolyStrike.Content = attackAmountHoly + " + " + dmgMind;

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        dmgMind = Math.Round((mindAmount * 3.55));
                                        DmgHolyStrike.Content = attackAmountHoly + " + " + dmgMind;

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        dmgMind = Math.Round((mindAmount * 3.55));
                                        DmgHolyStrike.Content = attackAmountHoly + " + " + dmgMind;

                                    }
                                }
                            }
                        }
                        if (attack.Name.Equals("Crit"))
                        {
                            DmgCritStrike.Content = attack.Amount;
                        }
                       
                    }

                }
            }
        }

        private void cbShields_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in list3)
            {
                if (item.Name.Equals(((ComboBoxItem)cbShields.SelectedItem).Content))
                {

                    imgShields.Source = new BitmapImage(new Uri(item.Image));
                    cbShields.Visibility = Visibility.Hidden;
                    foreach (var defence in item.Defence)
                    {
                        if (defence.Name.Equals("Phy"))
                        {
                            DefenceAmountPhy = defence.Amount;
                            DfcPhysAmount.Content = DefenceAmountPhy;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Str"))
                                {
                                     scaleStrdfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        DfcStr = Math.Round((strengthAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        DfcStr = Math.Round((strengthAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        DfcStr = Math.Round((strengthAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);
                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        DfcStr = Math.Round((strengthAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        DfcStr = Math.Round((strengthAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int strengthAmount = strength.Text == "" ? 0 : Int32.Parse(strength.Text);
                                        DfcStr = Math.Round((strengthAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);
                                    }
                                }
                                if (scale.Name.Equals("Dex"))
                                {
                                    scaleDexDfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        DfcDex = Math.Round((dexterityAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        DfcDex = Math.Round((dexterityAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);


                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        DfcDex = Math.Round((dexterityAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        DfcDex = Math.Round((dexterityAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);


                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        DfcDex = Math.Round((dexterityAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                                        DfcDex = Math.Round((dexterityAmount * 5.55));
                                        DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);


                                    }
                                }
                            }

                        }
                        if (defence.Name.Equals("Mag"))
                        {
                            DefenceAmountMag = defence.Amount;
                            DfcMagicAmount.Content = DefenceAmountMag;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Int"))
                                {
                                    scaleIntdfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt+DfcArc);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt + DfcArc);

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt + DfcArc);

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt + DfcArc);

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {

                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt + DfcArc);
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt + DfcArc);

                                    }
                                }
                                if (scale.Name.Equals("Arc"))
                                {
                                    scaleArcdfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        DfcArc = Math.Round((arcaneAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc+DfcInt);
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        DfcArc = Math.Round((arcaneAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc + DfcInt);

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        DfcArc = Math.Round((arcaneAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc + DfcInt);

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        DfcArc = Math.Round((arcaneAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc + DfcInt);

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        DfcArc = Math.Round((arcaneAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc + DfcInt);
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                                        DfcArc = Math.Round((arcaneAmount * 5.55));
                                        DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc + DfcInt);
                                    }
                                }
                            }
                        }
                        if (defence.Name.Equals("Fire"))
                        {
                            DefenceAmountFire = defence.Amount;
                            DfcFireAmount.Content = DefenceAmountFire;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Int"))
                                {
                                    scaleIntdfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round( (intelligenceAmount * 3.55));
                                        DfcFireAmount.Content = DefenceAmountFire + " + " + DfcInt;
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round((intelligenceAmount * 3.55));
                                        DfcFireAmount.Content = DefenceAmountFire + " + " + DfcInt;

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round((intelligenceAmount * 3.55));
                                        DfcFireAmount.Content = DefenceAmountFire + " + " + DfcInt;
                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round((intelligenceAmount * 3.55));
                                        DfcFireAmount.Content = DefenceAmountFire + " + " + DfcInt;
                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round((intelligenceAmount * 3.55));
                                        DfcFireAmount.Content = DefenceAmountFire + " + " + DfcInt;

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                                        DfcInt = Math.Round((intelligenceAmount * 3.55));
                                        DfcFireAmount.Content = DefenceAmountFire + " + " + DfcInt;

                                    }
                                }
                            }
                        }
                        if (defence.Name.Equals("Ligt"))
                        {
                            DefenceAmountLigth = defence.Amount;
                            DfcLightAmount.Content = DefenceAmountLigth;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Fai"))
                                {
                                    scaleFaithdfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                                        DfcFaith = Math.Round((faithAmount * 3.55));
                                        DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                                        DfcFaith = Math.Round((faithAmount * 3.55));
                                        DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                                        DfcFaith = Math.Round((faithAmount * 3.55));
                                        DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                                        DfcFaith = Math.Round((faithAmount * 3.55));
                                        DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;
                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {

                                        int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                                        DfcFaith = Math.Round((faithAmount * 3.55));
                                        DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;
                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                                        DfcFaith = Math.Round((faithAmount * 3.55));
                                        DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;
                                    }
                                }
                            }
                        }
                        if (defence.Name.Equals("Holy"))
                        {
                            DefenceAmountHoly = defence.Amount;
                            DfcHolyAmount.Content = DefenceAmountHoly;
                            foreach (var scale in item.ScalesWith)
                            {
                                if (scale.Name.Equals("Min"))
                                {

                                    scaleMinddfc = true;
                                    if (scale.Scaling.Equals("S"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        DfcMind = Math.Round( (mindAmount * 3.55));
                                        DfcHolyAmount.Content = DefenceAmountHoly + " + " + DfcMind;
                                    }

                                    if (scale.Scaling.Equals("A"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        DfcMind = Math.Round((mindAmount * 3.55));
                                        DfcHolyAmount.Content = DefenceAmountHoly + " + " + DfcMind;

                                    }

                                    if (scale.Scaling.Equals("B"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        DfcMind = Math.Round((mindAmount * 3.55));
                                        DfcHolyAmount.Content = DefenceAmountHoly + " + " + DfcMind;

                                    }

                                    if (scale.Scaling.Equals("C"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        DfcMind = Math.Round((mindAmount * 3.55));
                                        DfcHolyAmount.Content = DefenceAmountHoly + " + " + DfcMind;

                                    }

                                    if (scale.Scaling.Equals("D"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        DfcMind = Math.Round((mindAmount * 3.55));
                                        DfcHolyAmount.Content = DefenceAmountHoly + " + " + DfcMind;

                                    }

                                    if (scale.Scaling.Equals("E"))
                                    {
                                        int mindAmount = mind.Text == "" ? 0 : Int32.Parse(mind.Text);

                                        DfcMind = Math.Round((mindAmount * 3.55));
                                        DfcHolyAmount.Content = DefenceAmountHoly + " + " + DfcMind;

                                    }
                                }
                            }
                        }
                        

                    }

                }
            }

        }

        private void btnSearch_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cbWeapons.IsDropDownOpen = true;
        }

        private void imgShields_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cbShields.IsDropDownOpen = true;
        }

        private void inteligence_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (scaleInt)
            {
                int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                dmgInt = Math.Round((intelligenceAmount * 3.55));
                DmgMagiStrike.Content = attackAmountMag + " + " + dmgInt;
            }
            if (scaleIntdfc) {
                int intelligenceAmount = inteligence.Text == "" ? 0 : Int32.Parse(inteligence.Text);
                DfcInt = Math.Round(intelligenceAmount + (intelligenceAmount * 5.55));
                DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcInt + DfcArc);
            }
        }


        private void dexterity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (scaleDex)
            {
                int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                dmgDex = Math.Round( (dexterityAmount * 3.55));
                DmgPhysStrike.Content = attackAmountPhy + " + " + (dmgStr + dmgDex);

            }
            if (scaleDexDfc) {
                int dexterityAmount = dexterity.Text == "" ? 0 : Int32.Parse(dexterity.Text);
                DfcDex = Math.Round((dexterityAmount * 5.55));
                DfcPhysAmount.Content = DefenceAmountPhy + " + " + (DfcStr + DfcDex);
            }
        }

        private void arcane_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (scaleArc)
            {
                int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                dmgArc = Math.Round((arcaneAmount * 3.55));
                DmgMagiStrike.Content = attackAmountMag + " + " + dmgArc;

            }
            if (scaleArcdfc)
            {
                int arcaneAmount = arcane.Text == "" ? 0 : Int32.Parse(arcane.Text);
                DfcArc = Math.Round((arcaneAmount * 5.55));
                DfcMagicAmount.Content = DefenceAmountMag + " + " + (DfcArc + DfcInt);
            }
        }

        private void faith_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (scaleFaith)
            {
                int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                dmgFaith = Math.Round((faithAmount * 3.55));
                DmgLightStrike.Content = attackAmountLigth + " + " + dmgFaith;

            }
            if (scaleFaithdfc)
            {
                int faithAmount = faith.Text == "" ? 0 : Int32.Parse(faith.Text);
                DfcFaith = Math.Round((faithAmount * 3.55));
                DfcLightAmount.Content = DefenceAmountLigth + " + " + DfcFaith;
            }

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}