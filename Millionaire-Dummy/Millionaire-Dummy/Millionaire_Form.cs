/********************************************************************************************************************
* Team Members : Ravishka Rathnasuriya & Sabin Dheke
* Professor    : Dr. Catherine Stringfellow  
* Class        : CMPS 4143
* Assignment   : Assignment 4- Who wants to be the millionaire 
* Date         : 09/28/2020
* Description  :
  The assignment is a team work that has to design the game Who wants to be the millionaire.    
  The game is consited of 15 rounds with 4 lifelines options, 50-50, Ask the audience, phone a friend, and walk away.
  The game also consist of 3 safe havens. complete level 5 to win $1,000. Complete level 10 to win $32,000. Complete level 15 to win $1 Million.
 *The game has used entire paths for directories of files. For example Directory.GetCurrentDirectory() + "/Resources/sound/start_game.wav" 
  or Directory.GetCurrentDirectory() + "/Resources/images/green_button.wav"
 *If the user wants to change the file, he/she should change the path name and used it. 
 
 Applied Concepts: 
 1. Rename form and controls - Completed
 2. Prompt for input file name : Sampler.cs file storedata() method
 3. Reading from file: Sampler.cs file storedata() method
 4. Message box : several places, User will see while playing the game
 5. Has more than one class : Yes, class in this file, in .cs file Question class and Sampler class
 6. use array and array methods: arrays in .cs file AskTheAudience(), Lifelife50_50(),
                                 current class - FiftyFityLifeline() method, AskTheAdudienceLifeline()
                                 array method - current class - AskTheAudienceLifeLine() method
 7. Use Random class: Several placces in both .cs files. 
 8. Use ? operator : Sampler.cs class AskTheAudience() method.
 9. Using a do-while loop : Done. In sampler.cs class for storedata() function. 

Extra Concepts:
 1. Images : Done
 2. Sounds : Done
 3. Additional Lifelines : Total 4 lifelines
 4. Timer : Not Done

Requirements:
1. Instructions: Implemented. MessageBox pops up at the beginning
2. Fifteen rounds : Implemented
3. Current rounds : Implemented
4. Safe Havens : Implemented 3 safe havens
5. Identifies correct answer: Implemented
6. 50:50 lifeline: Implemented
7. Walk away lifeline : Implemented
8. Plays another game : Yes, after win or loose a game, it automatically starts a new game. click 'X' to exit in the form. 
                                                        

*********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Millionaire_Dummy
{
    public partial class Millionaire_Form : Form
    {
        //Make an object of the sampler class to accessn its properties
        Sampler game = new Sampler();

        

        public Millionaire_Form()
        {
            InitializeComponent();
        }

        /**********************************************************************************************
        Function name : private void Millionaire_Form_Load(object sender, EventArgs e)
        Return Type   : void
        This function is the load eventhandler for the program It will implement the game beginning sound 
        and write to a MessageBox about the game rules
        ***********************************************************************************************/
        private void Millionaire_Form_Load(object sender, EventArgs e)
        {
            
            System.Media.SoundPlayer gameStartSound = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/start_game.wav");
            gameStartSound.Play();
             string output = "Welcome to the Who Wants to be the Millionaire Game. \n The Game rules are as follows. \n\n" +
                "Click \"Click for Questions\" button for next question. \nOnce you select an answer, it will give you the correct result.\n\n" +
                "If you are correct you will move to next round, if not your game is over and you win the money you won.\n\n" +
                "You have three safe havens.\n 1. When you answered level 5 - you will win $1,000 \n 2. When you answered level 10 - you will win $32,000 " +
                "\n 3. When you answered level 15 - you will win $ 1 MILLION. \n\n" +
                "You have four lifeline options.\n" +
                "1. 50-50 \t  2. Ask The Audience \t 3. Call A Friend\t 4. Walk Away\n\n" +
                "The Round number will be indicated in the top left corner and you will see how much you have won while you play the game.\n\n" +
                "Once you finish the game, it will let you play again after disposing the form automatically.\n If you do not want to play the game click \'X\' sign.\n\n" +
                "Good Luck with your game. Hope you win the $ Million dollar.\n";
           

            
            MessageBox.Show(output, "Game Rules", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        /********************************************************************************************************
        function name: private voide Lifeline50x50btn_Click(object sender, EventArds e)
        return type: void
        This class is for 50:50 lifeline. It will play the sound for 50:50 lifeline and disabled the button.
        And change the background Image. 
        Also,it will call the FiftyFiftyLifeLine method that calls Lifeline50_50() method from Sampler class that will return an array. 
        ********************************************************************************************************/
        private void Lifeline50x50btn_Click(object sender, EventArgs e)
        {
            
                System.Media.SoundPlayer sounds;
                sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/_50x50.wav");
                sounds.Play();
                this.Lifeline50x50btn.BackgroundImage = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/50-50Block.png");
                this.Lifeline50x50btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                Lifeline50x50btn.Enabled = false;

            FiftyFityLifeline(game.Lifeline50_50());
        }

        /*************************************************************************************************************
         function name: private void LifelineATAbtn_Click(object sender, EventArgs e)
         Return Type: void
        This class is for ask the audience lifeline button.
        It will play the sound for the lifeline and change the background image and disable the button.
        Then it will call the  AskTheAudienceLifeLine that will call the AskTheAudience from the sampler class which return an array
        *************************************************************************************************************/
        private void LifelineATAbtn_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sounds;
            sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/ATA.wav");
            sounds.Play();
            this.LifelineATAbtn.BackgroundImage = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/AsktheAudienceBlock.png");
            this.LifelineATAbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            LifelineATAbtn.Enabled = false;
            AskTheAudienceLifeLine(game.AskTheAudience());
         
        }

        /**************************************************************************************************************
        function name: private void LifelineCAFbtn_Click(object sender, EventArgs e)
        return type: void
        This function is for the call a friend button. 
        It will play the sound for the lifeline and disable the button while changing its background Image. 
        It will call a PhoneAfriend function from sampler class thatw ould return an randome answer. 
        1 for A, 2 for B, 3 for C, and 4 for D respectively and print in a MessageBox. 
        **************************************************************************************************************/
        private void LifelineCAFbtn_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer sounds;
            sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/callAfriend.wav");
            sounds.Play();
            this.LifelineCAFbtn.BackgroundImage = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/phoneaFriendBlocked.png");
            this.LifelineCAFbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            LifelineCAFbtn.Enabled = false;
            int answer = game.PhoneAFriend();

            string output = " Your Friend Answered: \t" + answer + " \n";
            MessageBox.Show(output, "Call A Friend Answer ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /****************************************************************************************************************
         function name: private void WalkAWayLifeline_Click(object sender, EventArgs e)
         Return Type : Void
        This is for the walk away lifeline button.
        It will diable the button and prints the amount of money that the player has earned so far.
        Player should see the new question before decides to try this lifeline. 
        Whenever the lifeline is used, the game is over and a new game is started. 
        The game levels are decided using if statments. 
        *****************************************************************************************************************/

        private void WalkAWayLifeline_Click(object sender, EventArgs e)
        {
            WalkAWayLifeline.Enabled = false;

            if(game.level == 1)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 0", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 2)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 100", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 3)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 200", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 4)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 300", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 5)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 500", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 6)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 1,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 7)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 2,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 8)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 4,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 9)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 8,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 10)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 16,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 11)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 32,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 12)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 64,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 13)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 125,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 14)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 250,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (game.level == 15)
            {
                MessageBox.Show("GAME OVER \n Walking Away \n You won $ 500,000", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Dispose();
            Application.Restart();

        }

        /*******************************************************************************************************************************************
         function name: private void buttonAnswer1_Click(object sender, EventsArgs e)
         Return Type : void 
        The function is for Answer A. When clicked it will chnage the colour to yellow and call the checking() to see if te answer is corect. 
        *******************************************************************************************************************************************/
        private void buttonAnswer1_Click(object sender, EventArgs e)
        {
            
            this.buttonAnswer1.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/yellowImage.jpg");
            
            checking(buttonAnswer1.Text);
          
        }

        /*******************************************************************************************************************************************
         * function name: private void buttonAnswer2_Click(object sender, EventsArgs e)
         Return Type : void 
        The function is for Answer B. When clicked it will chnage the colour to yellow and call the checking() to see if te answer is corect.
        *******************************************************************************************************************************************/
        private void buttonAnswer2_Click(object sender, EventArgs e)
        {
            this.buttonAnswer2.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/yellowImage.jpg");
          
            checking(buttonAnswer2.Text);
          

        }

        /*******************************************************************************************************************************************
         * function name: private void buttonAnswer3_Click(object sender, EventsArgs e)
         Return Type : void 
        The function is for Answer C. When clicked it will chnage the colour to yellow and call the checking() to see if te answer is corect.
       *******************************************************************************************************************************************/
        private void buttonAnswer3_Click(object sender, EventArgs e)
        {
            this.buttonAnswer3.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/yellowImage.jpg");

            
            checking(buttonAnswer3.Text);
            
          
        }

        /*******************************************************************************************************************************************
         fucntion name: private void buttonAnswer4_Click(object sender, EventsArgs e)
         Return Type : void 
        The function is for Answer D. When clicked it will chnage the colour to yellow and call the checking() to see if te answer is corect.
       *******************************************************************************************************************************************/
        private void buttonAnswer4_Click(object sender, EventArgs e)
        {
            this.buttonAnswer4.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/yellowImage.jpg");
            checking(buttonAnswer4.Text);
            
            
            
        }

        /*******************************************************************************************************************************************
         Function name: private void StartButton_Click(object sender, EventArgs e)
         Return Type: void
        This the button for "Click for Questions" When ever it clicked by the user, it will display a question and then store them
        in the question label - the answer, 
        buttonAnswer labels - the answers for A,B,C,D respectively. It will also play the game sound, and everytime it will call
        the initialproperties() method to reset the properties of the events. 

       *******************************************************************************************************************************************/
        private void StartButton_Click(object sender, EventArgs e)
        {

            System.Media.SoundPlayer sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/GAME.wav");
            sounds.Play();
            game.CreateRanQandA();
            QuestionLabel.Text = " " + game.level + ". " + game.Cur_Question.question;
            buttonAnswer1.Text = game.Cur_Question.answer1;
            buttonAnswer2.Text = game.Cur_Question.answer2;
            buttonAnswer3.Text = game.Cur_Question.answer3;
            buttonAnswer4.Text = game.Cur_Question.answer4;
            RoundNumber.Text = "Round:  " + game.level;
            initialproperties();
            
        }

        /*******************************************************************************************************************************************
        function name :  public void initialpropoerties()
        return type : void
        This function will reset the events' properties after user enters an answer. 
        It will reset the 4 answer buttons back to enable mode and reset the Images back to black color. 
       *******************************************************************************************************************************************/
        public void initialproperties()
        {
            buttonAnswer3.Enabled = true;
            buttonAnswer1.Enabled = true;
            buttonAnswer2.Enabled = true;
            buttonAnswer4.Enabled = true;
            this.buttonAnswer1.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/black_button1.jpg");
            this.buttonAnswer2.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/black_button1.jpg");
            this.buttonAnswer3.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/black_button1.jpg");
            this.buttonAnswer4.Image = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/black_button1.jpg");
        }

        /*******************************************************************************************************************************************
         function name: public void checking(string check)
        return type : void
        parameters: string
        This function is to check the correct answer. First it will call the DisplayCorrectAnswer() method. 
        The it will check if the string passed is equal to the current question answer. 
        if equal, then call the MoneyBoxes(game.level) method and increase the game level, whenever it reaches the level 16, the game ends making
        the player win $1 million, 
        if not equal it will call the LostGame() function since the answer is wrong. 
       *******************************************************************************************************************************************/
        public void checking(string check)
        {
            DisplayCorrectAnswer();
            
           

            if (check == game.Cur_Question.key)
            {
                MoneyBoxes(game.level);
                game.level++;
                CorrectAnswer();
                if (game.level == 16)
                {
                    Winner(); return;
                }

            }
            else
            {
                LostGame();
            }
        }

        /*******************************************************************************************************************************************
        function name: public void DisplayCorrectAnswer()
        return type: void
        This function identifies the correct answer. Then it will change the Button Image of the correct answer to green color
        Use if statements to compare with 4 button
       *******************************************************************************************************************************************/
        public void DisplayCorrectAnswer()
        {
            Image green = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/green_button.jpg");
            if (buttonAnswer1.Text == game.Cur_Question.key)
            {
                buttonAnswer1.Image = green;
            }
            if (buttonAnswer2.Text == game.Cur_Question.key)
            {
                buttonAnswer2.Image = green;
            }
            if (buttonAnswer3.Text == game.Cur_Question.key)
            {
                buttonAnswer3.Image = green;
            }
            if (buttonAnswer4.Text == game.Cur_Question.key)
            {
                buttonAnswer4.Image = green;
            }
            Refresh();
        }

        /*******************************************************************************************************************************************
        function name: public void CorrectAnswer()
        return type:  void
        This function will play the correct answer sound and keep playing the game sound in a loop
       *******************************************************************************************************************************************/
        public void CorrectAnswer()
        {
            System.Media.SoundPlayer sounds;
            sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/correct_answer.wav");
            sounds.Play();
            System.Threading.Thread.Sleep(3800);
            sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/GAME.wav");
            sounds.PlayLooping();
        }


        /*******************************************************************************************************************************************
         * function name : public void Winner()
           return type: void
           This function is used to pop up the winning message saying the player won the $1 Million 
           And keep playing again the start game sound.
           After the messgae the game ends, and the form disposed and a new game is restarted. 
       *******************************************************************************************************************************************/
        public void Winner()
        {
            MessageBox.Show("Congratulations! \nYou won $ 1 MILLION", "Winner" , MessageBoxButtons.OK,MessageBoxIcon.Information);
            System.Media.SoundPlayer sounds;
            sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/start_game.wav");
            sounds.Play();
            System.Threading.Thread.Sleep(3800);
            
            Dispose();
            Application.Restart();
            
            

        }

        /*******************************************************************************************************************************************
         function name: public void LostGame()
         return type: void
         This function is used when the player has answered an incorrect answer. 
        It will play the lost game sound, and will display a message with respected amount of money that the player has won.
        The the form will be disposed anda new game is restarted. 
       *******************************************************************************************************************************************/
        public void LostGame()
        {
            System.Media.SoundPlayer sounds;
            sounds = new System.Media.SoundPlayer(Directory.GetCurrentDirectory() + "/Resources/sound/wrong_answer.wav");
            sounds.Play();
            if (game.level < 5)
            {
                MessageBox.Show("GAME OVER \n You won $ 0", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else if (game.level >= 5 && game.level <= 10)
            {
                MessageBox.Show("GAME OVER \n You won $1,000 ", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("GAME OVER \n You won $32,000 ", "Game Ends", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            System.Threading.Thread.Sleep(3800);
            Dispose();
            Application.Restart();
        }


        /*******************************************************************************************************************************************
         function name : public void FiftyFiftyLifeline(string [] fifty)
        return type: void
        parameters: array of strings
        This function will eliminate two answers for the 50-50 option using the array of strings.
        If statements to will be used to compare the answer buttons to be eliminated an those buttons will be disabled. 
       *******************************************************************************************************************************************/
        public void FiftyFityLifeline(string [] fifty)
        {
            if(fifty[0] == buttonAnswer1.Text  || fifty[1] == buttonAnswer1.Text)
            {
                buttonAnswer1.Enabled = false;
            }
            if (fifty[0] == buttonAnswer2.Text || fifty[1] == buttonAnswer2.Text)
            {
                buttonAnswer2.Enabled = false;
            }
            if (fifty[0] == buttonAnswer3.Text || fifty[1] == buttonAnswer3.Text)
            {
                buttonAnswer3.Enabled = false;
            }
            if (fifty[0] == buttonAnswer4.Text || fifty[1] == buttonAnswer4.Text)
            {
                buttonAnswer4.Enabled = false;
            }
        }

        /*******************************************************************************************************************************************
        Function name: public void AskTheAudienceLifeLine(int[] votes)
        return type: void
        parameters: array of integers
        This function is used when the player wants to use the ask the audience lifeline. 
        The function has used an array method to get the length and the votes of the audience for respected answer is displayed in a messagebox. 
       *******************************************************************************************************************************************/
        public void AskTheAudienceLifeLine(int[] votes)
        {
            string vote = "A\tB\tC\tD\n";
            for(int i = 0; i < votes.Length; i++)
            {
                vote += ""+votes[i]+"%\t";
            }
           
            MessageBox.Show(vote, "Ask The Audience Votes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /*******************************************************************************************************************************************
         * Function name: public void MoneyBoxes(int i)
           return type : void
           parameters: integer
          This function will update the money boxes when the player wins a round. /
          Two images have been used. Yellow for regular rounds and green for safe haven rounds
          Used case statements to compare the round number and highlight the necessary color for each moneyBoxes used. 
       *******************************************************************************************************************************************/
        public void MoneyBoxes(int i)
        {
            Image yellow = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/yellowImage.jpg");
            Image green = System.Drawing.Image.FromFile(Directory.GetCurrentDirectory() + "/Resources/Images/green_button.jpg");
            switch (i)
            {
                case 1:
                    Money1.Image = yellow;
                    break;
                case 2:
                    Money2.Image = yellow;
                    break;
                case 3:
                    Money3.Image = yellow;
                    break;
                case 4:
                    Money4.Image = yellow;
                    break;
                case 5:
                    Money5.Image = green;
                    break;
                case 6:
                    Money6.Image = yellow;
                    break;
                case 7:
                    Money7.Image = yellow;
                    break;
                case 8:
                    Money8.Image = yellow;
                    break;
                case 9:
                    Money9.Image = yellow;
                    break;
                case 10:
                    Money10.Image = green;
                    break;
                case 11:
                    Money11.Image = yellow;
                    break;
                case 12:
                    Money12.Image = yellow;
                    break;
                case 13:
                    Money13.Image = yellow;
                    break;
                case 14:
                    Money14.Image = yellow;
                    break;
                case 15:
                    Money15.Image = green;
                    break;
            }


        }

        
    }
}
