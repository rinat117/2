using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace golovolomka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // randomizer - eto imya
        Random randomizer = new Random();

        // sozdanie peremennih
        int addent1;
        int addent2;

        // sozdanie peremennih dlya -
        int minuend;
        int subtrahend;

        // sozdanie peremennih dlya *
        int multiplicand;
        int multiplier;

        // sozdanie peremennih dlya /
        int dividend;
        int divisor;



        // sozdanie timera
        int timeLeft;

        public void StartTheQuiz()
        {

            addent1 = randomizer.Next(51);
            addent2 = randomizer.Next(51);

            plusLeftLabel.Text = addent1.ToString();
            plusRightLabel.Text = addent2.ToString();

            sum.Value = 0;
            timeLeft = 10;
            timeLabel1.Text = "10 seconds";
            timer1.Start();


            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);

            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            difference.Value = 0;


            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;



            // 10 eto kol-vo sekynd
            timer1.Start();
            timeLeft = 30;
            timeLabel1.Text = "30 seconds";
          


        }

        private bool CheckTheAnswer()
        {
            // komp sam skladivaet add1 + add2 i 
            // proveryat s hashim otvetom v sum
            if ((addent1 + addent2 == sum.Value)

                // komp sam skladivaet minuend + subtrahend i 
                // proveryat s hashim otvetom v difference
                && (minuend - subtrahend == difference.Value)

                // komp sam skladivaet minuend + subtrahend i 
                // proveryat s hashim otvetom v difference
                && (multiplicand * multiplier == product.Value)

                // komp sam skladivaet minuend + subtrahend i 
                // proveryat s hashim otvetom v difference
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // zapysk programmi
            StartTheQuiz();

            // chel ne mojet najimat' BUTTON
            startButton.Enabled = false;

            timeLabel1.BackColor = Color.YellowGreen;

        }


        private void answer_enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengtOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
            {
                if (CheckTheAnswer())
                {
                    timer1.Stop();
                    MessageBox.Show("Vi vveli vse pravil'no",
                                          "Pozdravlyuy");
                    startButton.Enabled = true;

                }

                // esli timeleft bolshe 0 to:
                else if (timeLeft > 0)
                {
                    // таймер минусует по одному (1ой секунде)
                    // и выводит оставшееся время (число + секунды)
                    timeLeft--;
                    timeLabel1.Text = timeLeft + "  seconds ";
                }

                //// esli timeleft menshe 0 to:
                else

                {

                    timer1.Stop();
                    timeLabel1.Text = "Vremya vishlo";
                    MessageBox.Show("Y tebya chto-to nepravil'no", "Sorry, bro");

                    sum.Value = addent1 + addent2;
                    difference.Value = minuend - subtrahend;
                    product.Value = multiplicand * multiplier;
                    quotient.Value = dividend / divisor;

                    startButton.Enabled = true;

                }
            }

        }
    }